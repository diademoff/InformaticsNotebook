namespace MyNotebook.Forms
{
    partial class FormTeacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTeacher));
            this.btn_info = new System.Windows.Forms.Button();
            this.btn_createTest = new System.Windows.Forms.Button();
            this.listbx_users = new System.Windows.Forms.ListBox();
            this.btn_union = new System.Windows.Forms.Button();
            this.txtbx_name = new System.Windows.Forms.TextBox();
            this.txtbx_class = new System.Windows.Forms.TextBox();
            this.lbl_newUser = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
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
            this.listbx_users.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listbx_users.FormattingEnabled = true;
            this.listbx_users.Location = new System.Drawing.Point(12, 42);
            this.listbx_users.Name = "listbx_users";
            this.listbx_users.Size = new System.Drawing.Size(779, 355);
            this.listbx_users.TabIndex = 12;
            // 
            // btn_union
            // 
            this.btn_union.Location = new System.Drawing.Point(114, 12);
            this.btn_union.Name = "btn_union";
            this.btn_union.Size = new System.Drawing.Size(142, 29);
            this.btn_union.TabIndex = 15;
            this.btn_union.Text = "Объеденить учеников";
            this.btn_union.UseVisualStyleBackColor = true;
            this.btn_union.Click += new System.EventHandler(this.btn_union_Click);
            // 
            // txtbx_name
            // 
            this.txtbx_name.Location = new System.Drawing.Point(356, 17);
            this.txtbx_name.Name = "txtbx_name";
            this.txtbx_name.Size = new System.Drawing.Size(183, 20);
            this.txtbx_name.TabIndex = 16;
            this.txtbx_name.Visible = false;
            // 
            // txtbx_class
            // 
            this.txtbx_class.Location = new System.Drawing.Point(545, 17);
            this.txtbx_class.Name = "txtbx_class";
            this.txtbx_class.Size = new System.Drawing.Size(100, 20);
            this.txtbx_class.TabIndex = 17;
            this.txtbx_class.Visible = false;
            // 
            // lbl_newUser
            // 
            this.lbl_newUser.AutoSize = true;
            this.lbl_newUser.Location = new System.Drawing.Point(272, 20);
            this.lbl_newUser.Name = "lbl_newUser";
            this.lbl_newUser.Size = new System.Drawing.Size(78, 13);
            this.lbl_newUser.TabIndex = 18;
            this.lbl_newUser.Text = "Новый ученик";
            this.lbl_newUser.Visible = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(714, 15);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 19;
            this.btn_cancel.Text = "Отменить";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Visible = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(451, 403);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(167, 49);
            this.btn_send.TabIndex = 20;
            this.btn_send.Text = "Отправить тест ученикам";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // FormTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 464);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.lbl_newUser);
            this.Controls.Add(this.txtbx_class);
            this.Controls.Add(this.txtbx_name);
            this.Controls.Add(this.btn_union);
            this.Controls.Add(this.btn_info);
            this.Controls.Add(this.btn_createTest);
            this.Controls.Add(this.listbx_users);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма учителя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_info;
        private System.Windows.Forms.Button btn_createTest;
        private System.Windows.Forms.ListBox listbx_users;
        private System.Windows.Forms.Button btn_union;
        private System.Windows.Forms.TextBox txtbx_name;
        private System.Windows.Forms.TextBox txtbx_class;
        private System.Windows.Forms.Label lbl_newUser;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_send;
    }
}