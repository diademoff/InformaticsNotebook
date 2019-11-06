namespace MyNotebook.Forms
{
    partial class TeacherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherForm));
            this.btn_info = new System.Windows.Forms.Button();
            this.btn_createTest = new System.Windows.Forms.Button();
            this.listbx_users = new System.Windows.Forms.ListBox();
            this.btn_folderImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_info
            // 
            this.btn_info.Location = new System.Drawing.Point(12, 12);
            this.btn_info.Name = "btn_info";
            this.btn_info.Size = new System.Drawing.Size(96, 29);
            this.btn_info.TabIndex = 14;
            this.btn_info.Text = "Информация";
            this.btn_info.UseVisualStyleBackColor = true;
            this.btn_info.Click += new System.EventHandler(this.btn_info_Click);
            // 
            // btn_createTest
            // 
            this.btn_createTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_createTest.Location = new System.Drawing.Point(624, 403);
            this.btn_createTest.Name = "btn_createTest";
            this.btn_createTest.Size = new System.Drawing.Size(167, 49);
            this.btn_createTest.TabIndex = 13;
            this.btn_createTest.Text = "Создать тест";
            this.btn_createTest.UseVisualStyleBackColor = true;
            this.btn_createTest.Click += new System.EventHandler(this.Btn_createTest_Click);
            // 
            // listbx_users
            // 
            this.listbx_users.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listbx_users.FormattingEnabled = true;
            this.listbx_users.Location = new System.Drawing.Point(12, 42);
            this.listbx_users.Name = "listbx_users";
            this.listbx_users.Size = new System.Drawing.Size(779, 355);
            this.listbx_users.TabIndex = 12;
            // 
            // btn_folderImport
            // 
            this.btn_folderImport.Location = new System.Drawing.Point(114, 12);
            this.btn_folderImport.Name = "btn_folderImport";
            this.btn_folderImport.Size = new System.Drawing.Size(106, 29);
            this.btn_folderImport.TabIndex = 15;
            this.btn_folderImport.Text = "Импорт из папки";
            this.btn_folderImport.UseVisualStyleBackColor = true;
            this.btn_folderImport.Click += new System.EventHandler(this.btn_folderImport_Click);
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 464);
            this.Controls.Add(this.btn_folderImport);
            this.Controls.Add(this.btn_info);
            this.Controls.Add(this.btn_createTest);
            this.Controls.Add(this.listbx_users);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TeacherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма учителя";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_info;
        private System.Windows.Forms.Button btn_createTest;
        private System.Windows.Forms.ListBox listbx_users;
        private System.Windows.Forms.Button btn_folderImport;
    }
}