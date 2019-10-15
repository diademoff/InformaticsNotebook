namespace MyNotebook
{
    partial class UsersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtbx_name = new System.Windows.Forms.TextBox();
            this.txtbx_class = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listbx_users = new System.Windows.Forms.ListBox();
            this.btn_chooseTest = new System.Windows.Forms.Button();
            this.btn_folderImport = new System.Windows.Forms.Button();
            this.lbl_about = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_createTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.3F);
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО";
            // 
            // txtbx_name
            // 
            this.txtbx_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.31F);
            this.txtbx_name.Location = new System.Drawing.Point(112, 10);
            this.txtbx_name.Name = "txtbx_name";
            this.txtbx_name.Size = new System.Drawing.Size(676, 38);
            this.txtbx_name.TabIndex = 1;
            // 
            // txtbx_class
            // 
            this.txtbx_class.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.31F);
            this.txtbx_class.Location = new System.Drawing.Point(112, 61);
            this.txtbx_class.Name = "txtbx_class";
            this.txtbx_class.Size = new System.Drawing.Size(190, 38);
            this.txtbx_class.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.3F);
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Класс";
            // 
            // listbx_users
            // 
            this.listbx_users.FormattingEnabled = true;
            this.listbx_users.Location = new System.Drawing.Point(18, 119);
            this.listbx_users.Name = "listbx_users";
            this.listbx_users.Size = new System.Drawing.Size(770, 264);
            this.listbx_users.TabIndex = 4;
            // 
            // btn_chooseTest
            // 
            this.btn_chooseTest.Location = new System.Drawing.Point(621, 389);
            this.btn_chooseTest.Name = "btn_chooseTest";
            this.btn_chooseTest.Size = new System.Drawing.Size(167, 49);
            this.btn_chooseTest.TabIndex = 5;
            this.btn_chooseTest.Text = "Выбрать тест ->";
            this.btn_chooseTest.UseVisualStyleBackColor = true;
            this.btn_chooseTest.Click += new System.EventHandler(this.Btn_choose_Click);
            // 
            // btn_folderImport
            // 
            this.btn_folderImport.Location = new System.Drawing.Point(682, 90);
            this.btn_folderImport.Name = "btn_folderImport";
            this.btn_folderImport.Size = new System.Drawing.Size(106, 23);
            this.btn_folderImport.TabIndex = 6;
            this.btn_folderImport.Text = "Импорт из папки";
            this.btn_folderImport.UseVisualStyleBackColor = true;
            this.btn_folderImport.Click += new System.EventHandler(this.Btn_folderImport_Click);
            // 
            // lbl_about
            // 
            this.lbl_about.AutoSize = true;
            this.lbl_about.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_about.Location = new System.Drawing.Point(2, 0);
            this.lbl_about.Name = "lbl_about";
            this.lbl_about.Size = new System.Drawing.Size(13, 13);
            this.lbl_about.TabIndex = 8;
            this.lbl_about.Text = "?";
            this.lbl_about.Click += new System.EventHandler(this.Lbl_about_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(540, 90);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(136, 23);
            this.btn_update.TabIndex = 9;
            this.btn_update.Text = "Проверить обновления";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.Btn_update_Click);
            // 
            // btn_createTest
            // 
            this.btn_createTest.Location = new System.Drawing.Point(457, 389);
            this.btn_createTest.Name = "btn_createTest";
            this.btn_createTest.Size = new System.Drawing.Size(158, 47);
            this.btn_createTest.TabIndex = 10;
            this.btn_createTest.Text = "Создать тест";
            this.btn_createTest.UseVisualStyleBackColor = true;
            this.btn_createTest.Click += new System.EventHandler(this.Btn_createTest_Click);
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_createTest);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.lbl_about);
            this.Controls.Add(this.btn_folderImport);
            this.Controls.Add(this.btn_chooseTest);
            this.Controls.Add(this.listbx_users);
            this.Controls.Add(this.txtbx_class);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbx_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbx_name;
        private System.Windows.Forms.TextBox txtbx_class;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listbx_users;
        private System.Windows.Forms.Button btn_chooseTest;
        private System.Windows.Forms.Button btn_folderImport;
        private System.Windows.Forms.Label lbl_about;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_createTest;
    }
}

