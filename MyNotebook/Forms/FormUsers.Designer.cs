namespace MyNotebook
{
    partial class FormUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsers));
            this.label1 = new System.Windows.Forms.Label();
            this.txtbx_name = new System.Windows.Forms.TextBox();
            this.txtbx_class = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listbx_users = new System.Windows.Forms.ListBox();
            this.btn_chooseTest = new System.Windows.Forms.Button();
            this.lbl_about = new System.Windows.Forms.Label();
            this.txtbx_searchUsers = new System.Windows.Forms.TextBox();
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
            this.txtbx_class.MaxLength = 3;
            this.txtbx_class.Name = "txtbx_class";
            this.txtbx_class.Size = new System.Drawing.Size(190, 38);
            this.txtbx_class.TabIndex = 3;
            this.txtbx_class.TextChanged += new System.EventHandler(this.txtbx_class_TextChanged);
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
            this.listbx_users.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listbx_users.FormattingEnabled = true;
            this.listbx_users.Location = new System.Drawing.Point(12, 129);
            this.listbx_users.Name = "listbx_users";
            this.listbx_users.Size = new System.Drawing.Size(779, 264);
            this.listbx_users.TabIndex = 4;
            // 
            // btn_chooseTest
            // 
            this.btn_chooseTest.Location = new System.Drawing.Point(624, 399);
            this.btn_chooseTest.Name = "btn_chooseTest";
            this.btn_chooseTest.Size = new System.Drawing.Size(167, 49);
            this.btn_chooseTest.TabIndex = 5;
            this.btn_chooseTest.Text = "Выбрать тест ->";
            this.btn_chooseTest.UseVisualStyleBackColor = true;
            this.btn_chooseTest.Click += new System.EventHandler(this.Btn_choose_Click);
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
            // txtbx_searchUsers
            // 
            this.txtbx_searchUsers.Location = new System.Drawing.Point(12, 102);
            this.txtbx_searchUsers.Name = "txtbx_searchUsers";
            this.txtbx_searchUsers.Size = new System.Drawing.Size(423, 20);
            this.txtbx_searchUsers.TabIndex = 12;
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtbx_searchUsers);
            this.Controls.Add(this.lbl_about);
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
        private System.Windows.Forms.Label lbl_about;
        private System.Windows.Forms.TextBox txtbx_searchUsers;
    }
}

