namespace MyNotebook.Forms
{
    partial class FormSendTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSendTest));
            this.lbl_ip = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_chooseTest = new System.Windows.Forms.Button();
            this.listbx_userGotTest = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.lbl_ip.Location = new System.Drawing.Point(12, 9);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(55, 31);
            this.lbl_ip.TabIndex = 0;
            this.lbl_ip.Text = "IP: ";
            // 
            // btn_send
            // 
            this.btn_send.Enabled = false;
            this.btn_send.Location = new System.Drawing.Point(713, 416);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(109, 33);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "Раздать";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_chooseTest
            // 
            this.btn_chooseTest.Location = new System.Drawing.Point(600, 416);
            this.btn_chooseTest.Name = "btn_chooseTest";
            this.btn_chooseTest.Size = new System.Drawing.Size(107, 33);
            this.btn_chooseTest.TabIndex = 3;
            this.btn_chooseTest.Text = "Выбрать тест";
            this.btn_chooseTest.UseVisualStyleBackColor = true;
            this.btn_chooseTest.Click += new System.EventHandler(this.btn_chooseTest_Click);
            // 
            // listbx_userGotTest
            // 
            this.listbx_userGotTest.FormattingEnabled = true;
            this.listbx_userGotTest.Location = new System.Drawing.Point(18, 55);
            this.listbx_userGotTest.Name = "listbx_userGotTest";
            this.listbx_userGotTest.Size = new System.Drawing.Size(804, 355);
            this.listbx_userGotTest.TabIndex = 4;
            // 
            // FormSendTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.listbx_userGotTest);
            this.Controls.Add(this.btn_chooseTest);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.lbl_ip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSendTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отправить тест";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ip;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_chooseTest;
        private System.Windows.Forms.ListBox listbx_userGotTest;
    }
}