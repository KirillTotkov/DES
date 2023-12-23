namespace SymmetricCipherTask
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label4 = new Label();
            cmbInputType = new ComboBox();
            rbEncrypt = new RadioButton();
            rbDecrypt = new RadioButton();
            label2 = new Label();
            tbKey1 = new TextBox();
            tbKey2 = new TextBox();
            label3 = new Label();
            tbKey3 = new TextBox();
            label5 = new Label();
            lblTextHint = new Label();
            tbMesage = new TextBox();
            label7 = new Label();
            btnGo = new Button();
            tbResult = new TextBox();
            panelText = new Panel();
            panelFile_s = new Panel();
            lbSelectedFiles = new ListBox();
            label8 = new Label();
            btnSelectFiles = new Button();
            lblFilesHint = new Label();
            btnGenerateKey1 = new Button();
            btnGenerateKey2 = new Button();
            btnGenerateKey3 = new Button();
            panelText.SuspendLayout();
            panelFile_s.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(130, 9);
            label1.Name = "label1";
            label1.Size = new Size(398, 31);
            label1.TabIndex = 0;
            label1.Text = "Шифрование и дешифрование 3DES\r\n";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 102);
            label4.Name = "label4";
            label4.Size = new Size(100, 25);
            label4.TabIndex = 3;
            label4.Text = "Тип ввода:";
            // 
            // cmbInputType
            // 
            cmbInputType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInputType.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbInputType.FormattingEnabled = true;
            cmbInputType.Items.AddRange(new object[] { "Текст", "Файл", "Директория" });
            cmbInputType.Location = new Point(118, 102);
            cmbInputType.Name = "cmbInputType";
            cmbInputType.Size = new Size(151, 31);
            cmbInputType.TabIndex = 3;
            cmbInputType.SelectedIndexChanged += cmbInputType_SelectedIndexChanged;
            // 
            // rbEncrypt
            // 
            rbEncrypt.AutoSize = true;
            rbEncrypt.Checked = true;
            rbEncrypt.Font = new Font("Segoe UI", 10.8F);
            rbEncrypt.Location = new Point(44, 55);
            rbEncrypt.Name = "rbEncrypt";
            rbEncrypt.Size = new Size(142, 29);
            rbEncrypt.TabIndex = 1;
            rbEncrypt.TabStop = true;
            rbEncrypt.Text = "Шифрование";
            rbEncrypt.UseVisualStyleBackColor = true;
            rbEncrypt.CheckedChanged += rbEncrypt_CheckedChanged;
            // 
            // rbDecrypt
            // 
            rbDecrypt.AutoSize = true;
            rbDecrypt.Font = new Font("Segoe UI", 10.8F);
            rbDecrypt.Location = new Point(229, 55);
            rbDecrypt.Name = "rbDecrypt";
            rbDecrypt.Size = new Size(160, 29);
            rbDecrypt.TabIndex = 2;
            rbDecrypt.Text = "Дешифрование";
            rbDecrypt.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 403);
            label2.Name = "label2";
            label2.Size = new Size(71, 23);
            label2.TabIndex = 6;
            label2.Text = "Ключ 1:";
            // 
            // tbKey1
            // 
            tbKey1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbKey1.Location = new Point(89, 403);
            tbKey1.Multiline = true;
            tbKey1.Name = "tbKey1";
            tbKey1.Size = new Size(258, 27);
            tbKey1.TabIndex = 6;
            // 
            // tbKey2
            // 
            tbKey2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbKey2.Location = new Point(89, 441);
            tbKey2.Multiline = true;
            tbKey2.Name = "tbKey2";
            tbKey2.Size = new Size(258, 27);
            tbKey2.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 441);
            label3.Name = "label3";
            label3.Size = new Size(71, 23);
            label3.TabIndex = 8;
            label3.Text = "Ключ 2:";
            // 
            // tbKey3
            // 
            tbKey3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbKey3.Location = new Point(89, 480);
            tbKey3.Multiline = true;
            tbKey3.Name = "tbKey3";
            tbKey3.Size = new Size(258, 27);
            tbKey3.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(12, 480);
            label5.Name = "label5";
            label5.Size = new Size(71, 23);
            label5.TabIndex = 10;
            label5.Text = "Ключ 3:";
            // 
            // lblTextHint
            // 
            lblTextHint.AutoSize = true;
            lblTextHint.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTextHint.Location = new Point(3, 9);
            lblTextHint.Name = "lblTextHint";
            lblTextHint.Size = new Size(58, 25);
            lblTextHint.TabIndex = 12;
            lblTextHint.Text = "Текст:";
            // 
            // tbMesage
            // 
            tbMesage.Location = new Point(18, 37);
            tbMesage.Multiline = true;
            tbMesage.Name = "tbMesage";
            tbMesage.Size = new Size(546, 188);
            tbMesage.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(12, 570);
            label7.Name = "label7";
            label7.Size = new Size(90, 23);
            label7.TabIndex = 14;
            label7.Text = "Результат:";
            // 
            // btnGo
            // 
            btnGo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnGo.Location = new Point(252, 515);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(155, 38);
            btnGo.TabIndex = 15;
            btnGo.Text = "Шифровать";
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += btnGo_Click;
            // 
            // tbResult
            // 
            tbResult.Location = new Point(116, 570);
            tbResult.Multiline = true;
            tbResult.Name = "tbResult";
            tbResult.ReadOnly = true;
            tbResult.ScrollBars = ScrollBars.Vertical;
            tbResult.Size = new Size(472, 69);
            tbResult.TabIndex = 20;
            // 
            // panelText
            // 
            panelText.Controls.Add(lblTextHint);
            panelText.Controls.Add(tbMesage);
            panelText.Location = new Point(12, 139);
            panelText.Name = "panelText";
            panelText.Size = new Size(579, 249);
            panelText.TabIndex = 4;
            // 
            // panelFile_s
            // 
            panelFile_s.Controls.Add(lbSelectedFiles);
            panelFile_s.Controls.Add(label8);
            panelFile_s.Controls.Add(btnSelectFiles);
            panelFile_s.Controls.Add(lblFilesHint);
            panelFile_s.Location = new Point(405, 117);
            panelFile_s.Name = "panelFile_s";
            panelFile_s.RightToLeft = RightToLeft.No;
            panelFile_s.Size = new Size(469, 247);
            panelFile_s.TabIndex = 4;
            // 
            // lbSelectedFiles
            // 
            lbSelectedFiles.AllowDrop = true;
            lbSelectedFiles.FormattingEnabled = true;
            lbSelectedFiles.Location = new Point(15, 95);
            lbSelectedFiles.Name = "lbSelectedFiles";
            lbSelectedFiles.Size = new Size(332, 144);
            lbSelectedFiles.TabIndex = 3;
            lbSelectedFiles.TabStop = false;
            lbSelectedFiles.DragDrop += lbSelectedFiles_DragDrop;
            lbSelectedFiles.DragEnter += lbSelectedFiles_DragEnter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new Point(3, 69);
            label8.Name = "label8";
            label8.Size = new Size(163, 23);
            label8.TabIndex = 2;
            label8.Text = "Выбранные файлы:";
            // 
            // btnSelectFiles
            // 
            btnSelectFiles.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSelectFiles.Location = new Point(15, 36);
            btnSelectFiles.Name = "btnSelectFiles";
            btnSelectFiles.Size = new Size(126, 30);
            btnSelectFiles.TabIndex = 5;
            btnSelectFiles.Text = "Выбрать";
            btnSelectFiles.UseVisualStyleBackColor = true;
            btnSelectFiles.Click += btnSelectFiles_Click;
            // 
            // lblFilesHint
            // 
            lblFilesHint.AutoSize = true;
            lblFilesHint.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFilesHint.Location = new Point(3, 11);
            lblFilesHint.Name = "lblFilesHint";
            lblFilesHint.Size = new Size(54, 23);
            lblFilesHint.TabIndex = 0;
            lblFilesHint.Text = "Файл:";
            // 
            // btnGenerateKey1
            // 
            btnGenerateKey1.Image = (Image)resources.GetObject("btnGenerateKey1.Image");
            btnGenerateKey1.Location = new Point(363, 401);
            btnGenerateKey1.Name = "btnGenerateKey1";
            btnGenerateKey1.Size = new Size(35, 35);
            btnGenerateKey1.TabIndex = 21;
            btnGenerateKey1.UseVisualStyleBackColor = true;
            // 
            // btnGenerateKey2
            // 
            btnGenerateKey2.Image = (Image)resources.GetObject("btnGenerateKey2.Image");
            btnGenerateKey2.Location = new Point(363, 439);
            btnGenerateKey2.Name = "btnGenerateKey2";
            btnGenerateKey2.Size = new Size(35, 35);
            btnGenerateKey2.TabIndex = 22;
            btnGenerateKey2.UseVisualStyleBackColor = true;
            // 
            // btnGenerateKey3
            // 
            btnGenerateKey3.Image = (Image)resources.GetObject("btnGenerateKey3.Image");
            btnGenerateKey3.Location = new Point(363, 478);
            btnGenerateKey3.Name = "btnGenerateKey3";
            btnGenerateKey3.Size = new Size(35, 35);
            btnGenerateKey3.TabIndex = 23;
            btnGenerateKey3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 672);
            Controls.Add(btnGenerateKey3);
            Controls.Add(btnGenerateKey2);
            Controls.Add(btnGenerateKey1);
            Controls.Add(panelFile_s);
            Controls.Add(panelText);
            Controls.Add(label3);
            Controls.Add(tbResult);
            Controls.Add(label2);
            Controls.Add(tbKey3);
            Controls.Add(btnGo);
            Controls.Add(tbKey1);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(rbDecrypt);
            Controls.Add(tbKey2);
            Controls.Add(rbEncrypt);
            Controls.Add(cmbInputType);
            Controls.Add(label4);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "3DES";
            panelText.ResumeLayout(false);
            panelText.PerformLayout();
            panelFile_s.ResumeLayout(false);
            panelFile_s.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label4;
        private ComboBox cmbInputType;
        private RadioButton rbEncrypt;
        private RadioButton rbDecrypt;
        private Label label2;
        private TextBox tbKey1;
        private TextBox tbKey2;
        private Label label3;
        private TextBox tbKey3;
        private Label label5;
        private Label lblTextHint;
        private TextBox tbMesage;
        private Label label7;
        private Button btnGo;
        private TextBox tbResult;
        private Panel panelText;
        private Panel panelFile_s;
        private Label label8;
        private Button btnSelectFiles;
        private Label lblFilesHint;
        private ListBox lbSelectedFiles;
        private Button btnGenerateKey1;
        private Button btnGenerateKey2;
        private Button btnGenerateKey3;
    }
}
