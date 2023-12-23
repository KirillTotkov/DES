using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SymmetricCipherTask
{
    public partial class Form1 : Form
    {
        private CryptologyType cryptologyType;
        private InputType inputType;
        private List<string> files;

        public Form1()
        {
            InitializeComponent();
            SetDefaults();
        }

        private void SetDefaults()
        {
            cmbInputType.SelectedIndex = 0;
            tbResult.Text = "";
            cryptologyType = CryptologyType.Encryption;
            inputType = InputType.Text;
            files = new List<string>();
            btnGenerateKey1.Click += (sender, args) => tbKey1.Text = GenerateKeys_Click(sender, args);
            btnGenerateKey2.Click += (sender, args) => tbKey2.Text = GenerateKeys_Click(sender, args);
            btnGenerateKey3.Click += (sender, args) => tbKey3.Text = GenerateKeys_Click(sender, args);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            var keys = new[] { tbKey1.Text, tbKey2.Text, tbKey3.Text };

            if (inputType == InputType.Text)
            {
                var message = tbMesage.Text;
                tbResult.Text = ProcessText(message, keys);
            }
            else if (inputType is InputType.File or InputType.Directory)
            {
                ProcessFiles(keys);
            }
        }

        private string ProcessText(string message, string[] keys)
        {
            return cryptologyType == CryptologyType.Encryption
                ? TripleDes.Encrypt(message, keys[0], keys[1], keys[2])
                : TripleDes.Decrypt(message, keys[2], keys[1], keys[0]);
        }

        private void ProcessFiles(string[] keys)
        {
            foreach (var file in files)
            {
                var bytes = File.ReadAllBytes(file);

                var processedFile = cryptologyType == CryptologyType.Encryption
                    ? TripleDes.Encrypt(bytes, keys[0], keys[1], keys[2])
                    : TripleDes.Decrypt(bytes, keys[2], keys[1], keys[0]);

                var path = Path.GetDirectoryName(file);

                if (cryptologyType == CryptologyType.Encryption)
                {
                    path += "\\enc_" + Path.GetFileName(file);
                }
                else
                {
                    path += "\\dec_" + Path.GetFileName(file);
                }

                File.WriteAllBytes(path, processedFile);
            }

            MessageBox.Show("Файлы сохранены");
        }

        private void rbEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            cryptologyType = ((RadioButton)sender).Checked ? CryptologyType.Encryption : CryptologyType.Decryption;
            UpdateUI();
        }

        private void UpdateUI()
        {
            lblTextHint.Text = cryptologyType == CryptologyType.Encryption ? "Текст:" : "Текст (base64):";
            btnGo.Text = cryptologyType == CryptologyType.Encryption ? "Шифровать" : "Дешифровать";
            if (cryptologyType == CryptologyType.Decryption)
            {
                files.Clear();
                lbSelectedFiles.DataSource = files;
            }
        }

        private void cmbInputType_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputType = (InputType)cmbInputType.SelectedIndex;
            UpdateInputUI();
        }

        private void UpdateInputUI()
        {
            panelText.Visible = inputType == InputType.Text;
            panelFile_s.Visible = inputType != InputType.Text;
            if (inputType != InputType.Text)
            {
                panelFile_s.Location = panelText.Location;
                files.Clear();
                lbSelectedFiles.DataSource = files;
                //var btnOpenResult = CreateOpenResultFileBtn();
                //btnOpenResult.Location = tbResult.Location;
                //btnOpenResult.Visible = true;
                tbResult.Visible = false;
                //Controls.Add(btnOpenResult);
                lblFilesHint.Text = inputType == InputType.File ? "Файл:" : "Директория";
                label7.Visible = false;
            }
            else
            {
                tbResult.Visible = true;
            }
        }


        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            if (inputType == InputType.Directory)
            {
                SelectDirectory();
            }
            else
            {
                SelectFiles();
            }

            lbSelectedFiles.DataSource = files.Select(file => Path.GetFileName(file)).ToList();
        }

        private void SelectDirectory()
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                files = Directory.GetFiles(fbd.SelectedPath).ToList();
            }
        }

        private void SelectFiles()
        {
            var openFileDialog1 = new OpenFileDialog { Filter = "All files (*.*)|*.*" };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                if (!files.Contains(fileName))
                {
                    files.Add(fileName);
                }
            }
        }

        private Button CreateOpenResultFileBtn()
        {
            return new Button
            {
                Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204),
                Name = "btnOpenResult",
                Size = new Size(126, 30),
                TabIndex = 20,
                Text = "Открыть",
                UseVisualStyleBackColor = true
            };
        }

        private bool ValidateInput()
        {
            if (inputType == InputType.Text && string.IsNullOrWhiteSpace(tbMesage.Text))
            {
                MessageBox.Show("Введите текст");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbKey1.Text) || string.IsNullOrWhiteSpace(tbKey2.Text) ||
                string.IsNullOrWhiteSpace(tbKey3.Text))
            {
                MessageBox.Show("Введите ключи");
                return false;
            }

            if (inputType != InputType.Text && files.Count == 0)
            {
                MessageBox.Show("Выберите файлы");
                return false;
            }

            return true;
        }

        private string GenerateKeys_Click(object sender, EventArgs e)
        {
            return Path.GetRandomFileName().Replace(".", "").Substring(0, 8);
        }

        private void lbSelectedFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                files = new List<string>(filePaths);
                lbSelectedFiles.DataSource = files.Select(file => Path.GetFileName(file)).ToList();
            }
        }

        private void lbSelectedFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        enum CryptologyType
        {
            Encryption,
            Decryption
        }

        enum InputType
        {
            Text,
            File,
            Directory
        }
    }
}