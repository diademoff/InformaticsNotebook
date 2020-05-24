namespace MyNotebook.Forms
{
    partial class FormSelectStartType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectStartType));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.lbl_score = new System.Windows.Forms.Label();
            this.cb_style = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.button1.Location = new System.Drawing.Point(133, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 100);
            this.button1.TabIndex = 0;
            this.button1.Text = "Я ученик";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.button2.Location = new System.Drawing.Point(133, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 100);
            this.button2.TabIndex = 1;
            this.button2.Text = "Я учитель";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(372, 356);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(136, 23);
            this.btn_update.TabIndex = 10;
            this.btn_update.Text = "Обновить";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Visible = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // lbl_score
            // 
            this.lbl_score.AutoSize = true;
            this.lbl_score.Location = new System.Drawing.Point(12, 9);
            this.lbl_score.Name = "lbl_score";
            this.lbl_score.Size = new System.Drawing.Size(38, 13);
            this.lbl_score.TabIndex = 11;
            this.lbl_score.Text = "Очки: ";
            this.lbl_score.Visible = false;
            // 
            // cb_style
            // 
            this.cb_style.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_style.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_style.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb_style.FormattingEnabled = true;
            this.cb_style.Location = new System.Drawing.Point(12, 358);
            this.cb_style.Name = "cb_style";
            this.cb_style.Size = new System.Drawing.Size(150, 21);
            this.cb_style.TabIndex = 12;
            // 
            // FormSelectStartType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 391);
            this.Controls.Add(this.cb_style);
            this.Controls.Add(this.lbl_score);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSelectStartType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите тип запуска";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Label lbl_score;
        private System.Windows.Forms.ComboBox cb_style;
    }
}