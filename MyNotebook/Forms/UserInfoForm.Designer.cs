namespace MyNotebook.Forms
{
    partial class UserInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfoForm));
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_class = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btn_moreInfo = new System.Windows.Forms.Button();
            this.btn_OpenHTML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_name.Location = new System.Drawing.Point(12, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(42, 20);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Имя";
            // 
            // lbl_class
            // 
            this.lbl_class.AutoSize = true;
            this.lbl_class.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_class.Location = new System.Drawing.Point(452, 9);
            this.lbl_class.Name = "lbl_class";
            this.lbl_class.Size = new System.Drawing.Size(58, 20);
            this.lbl_class.TabIndex = 1;
            this.lbl_class.Text = "Класс";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тесты";
            // 
            // listBox
            // 
            this.listBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 104);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(776, 303);
            this.listBox.TabIndex = 3;
            // 
            // btn_moreInfo
            // 
            this.btn_moreInfo.Location = new System.Drawing.Point(12, 415);
            this.btn_moreInfo.Name = "btn_moreInfo";
            this.btn_moreInfo.Size = new System.Drawing.Size(75, 23);
            this.btn_moreInfo.TabIndex = 4;
            this.btn_moreInfo.Text = "Подробнее";
            this.btn_moreInfo.UseVisualStyleBackColor = true;
            this.btn_moreInfo.Click += new System.EventHandler(this.btn_moreInfo_Click);
            // 
            // btn_OpenHTML
            // 
            this.btn_OpenHTML.Location = new System.Drawing.Point(93, 415);
            this.btn_OpenHTML.Name = "btn_OpenHTML";
            this.btn_OpenHTML.Size = new System.Drawing.Size(148, 23);
            this.btn_OpenHTML.TabIndex = 5;
            this.btn_OpenHTML.Text = "Посмотреть информацию";
            this.btn_OpenHTML.UseVisualStyleBackColor = true;
            this.btn_OpenHTML.Click += new System.EventHandler(this.btn_OpenHTML_Click);
            // 
            // UserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_OpenHTML);
            this.Controls.Add(this.btn_moreInfo);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_class);
            this.Controls.Add(this.lbl_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_class;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button btn_moreInfo;
        private System.Windows.Forms.Button btn_OpenHTML;
    }
}