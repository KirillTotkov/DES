using System.Collections;
using System.Text;

namespace SymmetricCipherTask;

public static class TripleDes
{
    private const int SizeBlock = 64;
    private const int BlockSizeInBytes = SizeBlock / 8;
    private static readonly BitArray[,,] GeneratedSBoxes = GenerateSBox();

    public static string Encrypt(string text, string key1, string key2, string key3)
    {
        return Convert.ToBase64String(EncryptDecrypt(PadMessage(Encoding.UTF8.GetBytes(text)), key1, key2, key3,
            false));
    }

    public static byte[] Encrypt(byte[] file, string key1, string key2, string key3)
    {
        return EncryptDecrypt(PadMessage(file), key1, key2, key3, false);
    }

    public static string Decrypt(string base64, string key1, string key2, string key3)
    {
        var decrypted = EncryptDecrypt(Convert.FromBase64String(base64), key1, key2, key3, true);
        return Encoding.UTF8.GetString(RemovePadding(decrypted));
    }

    public static byte[] Decrypt(byte[] file, string key1, string key2, string key3)
    {
        return RemovePadding(EncryptDecrypt(file, key1, key2, key3, true));
    }

    private static byte[] EncryptDecrypt(byte[] input, string key1, string key2, string key3, bool decrypt)
    {
        var processed1 = ProcessMessage(input, key1, decrypt);
        var processed2 = ProcessMessage(processed1, key2, !decrypt);
        var processed3 = ProcessMessage(processed2, key3, decrypt);

        return processed3;
    }

    private static byte[] ProcessMessage(byte[] input, string keyString, bool decrypt)
    {
        var blocksMessage = input.Chunk(BlockSizeInBytes).ToList();

        var key = ByteArrayToBitArray(PadMessage(Encoding.UTF8.GetBytes(keyString)));
        var generatedKeys = GenerateKeys(key);
        if (decrypt)
        {
            Array.Reverse(generatedKeys);
        }

        var result = ProcessBlocks(blocksMessage, generatedKeys);

        return BitArrayToByteArray(result);
    }


    private static BitArray ProcessBlocks(List<byte[]> blocksMessage, BitArray[] keys)
    {
        var result = new BitArray(blocksMessage.Count * SizeBlock);

        Parallel.For(0, blocksMessage.Count, blockIndex =>
        {
            var block = blocksMessage[blockIndex];

            // Initial Permutation
            var bitBlock = ByteArrayToBitArray(block);
            var ipBlock = Permutation(bitBlock, Constants.IP);
            var (left, right) = SplitHalf(ipBlock);

            for (int round = 0; round < 16; round++)
            {
                var tmp = right;
                // Expansion (32bits to 48bits)
                right = Permutation(right, Constants.E);
                // Key mixing
                right = right.Xor(keys[round]);
                // Substitution (48bits to 32bits)
                right = Substitution(right);
                // P
                right = Permutation(right, Constants.P);
                right = right.Xor(left);
                left = tmp;
            }

            // Concat right and left
            var cipherChunk = ConcatBitArray(right, left);

            // FP
            var fpBlock = Permutation(cipherChunk, Constants.FP);

            for (int i = 0; i < fpBlock.Length; i++)
            {
                result[blockIndex * SizeBlock + i] = fpBlock[i];
            }
        });

        return result;
    }

    private static BitArray[] GenerateKeys(BitArray key)
    {
        var keys = new BitArray[16];

        // PC1 (64 bits to 56 bits) 
        var newKey = Permutation(key, Constants.PC1);
        var (left, right) = SplitHalf(newKey);

        for (int round = 0; round < 16; round++)
        {
            left = LeftRotate(left, Constants.SHIFTS[round]);
            right = LeftRotate(right, Constants.SHIFTS[round]);
            var concat = ConcatBitArray(left, right);
            // PC2 (56bits to 48bits)
            var keyCompressed = Permutation(concat, Constants.PC2);
            keys[round] = keyCompressed;
        }

        return keys;
    }


    /// <summary>
    /// Выполняет операцию подстановки в алгоритме шифрования DES.
    /// </summary>
    /// <param name="array">48-битный входной блок</param>
    /// <returns>32-битный выходной блок после замены.</returns>
    /// <remarks>
    /// Входной блок разбивается на 8 блоков по 6 бит.
    /// Каждый из них подается на вход соответствующего S-блока.
    /// Результаты подстановки объединяются в 32-битный блок.
    /// </remarks>
    private static BitArray Substitution(BitArray array)
    {
        var sBlocksBites = new BitArray(32);

        for (int i = 0; i < 8; i++)
        {
            int rowNumber = (array[i * 6] ? 2 : 0) + (array[i * 6 + 5] ? 1 : 0);
            int columnNumber = (array[i * 6 + 1] ? 8 : 0) + (array[i * 6 + 2] ? 4 : 0) + (array[i * 6 + 3] ? 2 : 0) +
                               (array[i * 6 + 4] ? 1 : 0);
            var sBlockValue = GetSBoxValue(i, rowNumber, columnNumber);
            for (int j = 0; j < 4; j++)
            {
                sBlocksBites[i * 4 + j] = sBlockValue[j];
            }
        }

        return sBlocksBites;
    }

    private static BitArray Permutation(BitArray array, int[] table)
    {
        var result = new BitArray(table.Length);

        for (var i = 0; i < table.Length; i++)
        {
            result[i] = array[table[i] - 1];
        }

        return result;
    }

    private static BitArray GetSBoxValue(int sBoxNumber, int row, int col)
    {
        return GeneratedSBoxes[sBoxNumber, row, col];
    }

    private static (BitArray, BitArray) SplitHalf(BitArray source)
    {
        BitArray left = new BitArray(source.Length / 2);
        BitArray right = new BitArray(source.Length / 2);

        for (int i = 0; i < source.Length / 2; i++)
        {
            left[i] = source[i];
            right[i] = source[i + source.Length / 2];
        }

        return (left, right);
    }

    private static byte[] PadMessage(byte[] messageBytes)
    {
        int blockSize = BlockSizeInBytes;
        int paddingLength = blockSize - (messageBytes.Length % blockSize);
        byte paddingByte = (byte)paddingLength;

        byte[] paddedMessage = new byte[messageBytes.Length + paddingLength];
        Array.Copy(messageBytes, paddedMessage, messageBytes.Length);

        for (int i = messageBytes.Length; i < paddedMessage.Length; i++)
        {
            paddedMessage[i] = paddingByte;
        }

        return paddedMessage;
    }

    private static byte[] RemovePadding(byte[] paddedMessage)
    {
        int paddingLength = paddedMessage[^1];
        byte[] originalMessage = new byte[paddedMessage.Length - paddingLength];
        Array.Copy(paddedMessage, originalMessage, originalMessage.Length);

        return originalMessage;
    }

    private static BitArray ByteArrayToBitArray(byte[] bytes)
    {
        return Reverse(new BitArray(bytes));
    }

    private static byte[] BitArrayToByteArray(BitArray bits)
    {
        byte[] bytes = new byte[bits.Length / 8];
        Reverse(bits).CopyTo(bytes, 0);
        return bytes;
    }

    private static BitArray Reverse(BitArray original)
    {
        BitArray reversed = new BitArray(original.Length);

        for (int i = 0; i < original.Length; i += 8)
        {
            for (int j = 0; j < 8; j++)
            {
                reversed[i + j] = original[i + 8 - j - 1];
            }
        }

        return reversed;
    }

    private static BitArray IntToBitArray(int intValue)
    {
        var bits = new BitArray(4);
        for (int i = 0; i < 4; i++)
        {
            bits[3 - i] = (intValue & (1 << i)) != 0;
        }

        return bits;
    }

    private static BitArray[,,] GenerateSBox()
    {
        var sBoxes = new BitArray[8, 4, 16];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 16; k++)
                {
                    int value = Constants.SBoxes[i][j, k];
                    sBoxes[i, j, k] = IntToBitArray(value);
                }
            }
        }

        return sBoxes;
    }

    private static BitArray LeftRotate(BitArray array, int positions)
    {
        BitArray rotatedBits = new BitArray(array);

        for (int i = 0; i < array.Length; i++)
        {
            int newIndex = (i + positions) % array.Length;
            rotatedBits[i] = array[newIndex];
        }

        return rotatedBits;
    }

    private static BitArray ConcatBitArray(BitArray left, BitArray right)
    {
        var result = new BitArray(left.Length + right.Length);
        for (int i = 0; i < left.Length; i++)
        {
            result[i] = left[i];
        }

        for (int i = 0; i < right.Length; i++)
        {
            result[left.Length + i] = right[i];
        }

        return result;
    }
}