namespace Statistics
{
    partial class FormSelectTests
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
            this.lbl_totalTests = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbx_percentSolveMin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbx_percentSolveMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_done = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_totalTests
            // 
            this.lbl_totalTests.AutoSize = true;
            this.lbl_totalTests.Location = new System.Drawing.Point(12, 9);
            this.lbl_totalTests.Name = "lbl_totalTests";
            this.lbl_totalTests.Size = new System.Drawing.Size(35, 13);
            this.lbl_totalTests.TabIndex = 0;
            this.lbl_totalTests.Text = "label1";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(15, 74);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберете даты выполнения теста";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Процентов решено:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "от";
            // 
            // txtbx_percentSolveMin
            // 
            this.txtbx_percentSolveMin.Location = new System.Drawing.Point(36, 268);
            this.txtbx_percentSolveMin.MaxLength = 2;
            this.txtbx_percentSolveMin.Name = "txtbx_percentSolveMin";
            this.txtbx_percentSolveMin.Size = new System.Drawing.Size(47, 20);
            this.txtbx_percentSolveMin.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "до";
            // 
            // txtbx_percentSolveMax
            // 
            this.txtbx_percentSolveMax.Location = new System.Drawing.Point(114, 268);
            this.txtbx_percentSolveMax.MaxLength = 3;
            this.txtbx_percentSolveMax.Name = "txtbx_percentSolveMax";
            this.txtbx_percentSolveMax.Size = new System.Drawing.Size(47, 20);
            this.txtbx_percentSolveMax.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "%";
            // 
            // btn_done
            // 
            this.btn_done.Location = new System.Drawing.Point(713, 415);
            this.btn_done.Name = "btn_done";
            this.btn_done.Size = new System.Drawing.Size(75, 23);
            this.btn_done.TabIndex = 9;
            this.btn_done.Text = "Готово";
            this.btn_done.UseVisualStyleBackColor = true;
            this.btn_done.Click += new System.EventHandler(this.btn_done_Click);
            // 
            // FormSelectTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_done);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtbx_percentSolveMax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbx_percentSolveMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.lbl_totalTests);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSelectTests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSelectTests";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_totalTests;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbx_percentSolveMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbx_percentSolveMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_done;
    }
}