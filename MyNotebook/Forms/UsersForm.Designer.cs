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
            this.label1 = new System.Windows.Forms.Label();
            this.txtbx_name = new System.Windows.Forms.TextBox();
            this.txtbx_class = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listbx_users = new System.Windows.Forms.ListBox();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_folderImport = new System.Windows.Forms.Button();
            this.cb_disableCalc = new System.Windows.Forms.CheckBox();
            this.lbl_about = new System.Windows.Forms.Label();
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
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(598, 385);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(190, 53);
            this.btn_next.TabIndex = 5;
            this.btn_next.Text = "Далее ->";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.Btn_next_Click);
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
            // cb_disableCalc
            // 
            this.cb_disableCalc.AutoSize = true;
            this.cb_disableCalc.Checked = true;
            this.cb_disableCalc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_disableCalc.Location = new System.Drawing.Point(18, 421);
            this.cb_disableCalc.Name = "cb_disableCalc";
            this.cb_disableCalc.Size = new System.Drawing.Size(146, 17);
            this.cb_disableCalc.TabIndex = 7;
            this.cb_disableCalc.Text = "Запретить калькулятор";
            this.cb_disableCalc.UseVisualStyleBackColor = true;
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
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_about);
            this.Controls.Add(this.cb_disableCalc);
            this.Controls.Add(this.btn_folderImport);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.listbx_users);
            this.Controls.Add(this.txtbx_class);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbx_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_folderImport;
        private System.Windows.Forms.CheckBox cb_disableCalc;
        private System.Windows.Forms.Label lbl_about;
    }
}

