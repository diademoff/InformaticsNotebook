namespace MyNotebook.Forms
{
    partial class TestResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestResultForm));
            this.lbl_state = new System.Windows.Forms.Label();
            this.lbl_timeStart = new System.Windows.Forms.Label();
            this.lbl_timeEnd = new System.Windows.Forms.Label();
            this.lbl_wasCalcDiabled = new System.Windows.Forms.Label();
            this.txtbx_log = new System.Windows.Forms.RichTextBox();
            this.lbl_mark = new System.Windows.Forms.Label();
            this.lbl_solvedPercent = new System.Windows.Forms.Label();
            this.lbl_timeSpend = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_state
            // 
            this.lbl_state.AutoSize = true;
            this.lbl_state.Location = new System.Drawing.Point(12, 9);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(47, 13);
            this.lbl_state.TabIndex = 0;
            this.lbl_state.Text = "Статус: ";
            // 
            // lbl_timeStart
            // 
            this.lbl_timeStart.AutoSize = true;
            this.lbl_timeStart.Location = new System.Drawing.Point(12, 35);
            this.lbl_timeStart.Name = "lbl_timeStart";
            this.lbl_timeStart.Size = new System.Drawing.Size(84, 13);
            this.lbl_timeStart.TabIndex = 1;
            this.lbl_timeStart.Text = "Время начала: ";
            // 
            // lbl_timeEnd
            // 
            this.lbl_timeEnd.AutoSize = true;
            this.lbl_timeEnd.Location = new System.Drawing.Point(12, 63);
            this.lbl_timeEnd.Name = "lbl_timeEnd";
            this.lbl_timeEnd.Size = new System.Drawing.Size(111, 13);
            this.lbl_timeEnd.TabIndex = 2;
            this.lbl_timeEnd.Text = "Время завершения: ";
            // 
            // lbl_wasCalcDiabled
            // 
            this.lbl_wasCalcDiabled.AutoSize = true;
            this.lbl_wasCalcDiabled.Location = new System.Drawing.Point(12, 116);
            this.lbl_wasCalcDiabled.Name = "lbl_wasCalcDiabled";
            this.lbl_wasCalcDiabled.Size = new System.Drawing.Size(75, 13);
            this.lbl_wasCalcDiabled.TabIndex = 3;
            this.lbl_wasCalcDiabled.Text = "Калькулятор:";
            // 
            // txtbx_log
            // 
            this.txtbx_log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbx_log.Location = new System.Drawing.Point(295, 6);
            this.txtbx_log.Name = "txtbx_log";
            this.txtbx_log.ReadOnly = true;
            this.txtbx_log.Size = new System.Drawing.Size(493, 432);
            this.txtbx_log.TabIndex = 4;
            this.txtbx_log.Text = "";
            // 
            // lbl_mark
            // 
            this.lbl_mark.AutoSize = true;
            this.lbl_mark.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.lbl_mark.Location = new System.Drawing.Point(9, 166);
            this.lbl_mark.Name = "lbl_mark";
            this.lbl_mark.Size = new System.Drawing.Size(110, 31);
            this.lbl_mark.TabIndex = 5;
            this.lbl_mark.Text = "Оценка";
            // 
            // lbl_solvedPercent
            // 
            this.lbl_solvedPercent.AutoSize = true;
            this.lbl_solvedPercent.Location = new System.Drawing.Point(12, 143);
            this.lbl_solvedPercent.Name = "lbl_solvedPercent";
            this.lbl_solvedPercent.Size = new System.Drawing.Size(49, 13);
            this.lbl_solvedPercent.TabIndex = 6;
            this.lbl_solvedPercent.Text = "Решено:";
            // 
            // lbl_timeSpend
            // 
            this.lbl_timeSpend.AutoSize = true;
            this.lbl_timeSpend.Location = new System.Drawing.Point(12, 90);
            this.lbl_timeSpend.Name = "lbl_timeSpend";
            this.lbl_timeSpend.Size = new System.Drawing.Size(101, 13);
            this.lbl_timeSpend.TabIndex = 7;
            this.lbl_timeSpend.Text = "Время затрачено: ";
            // 
            // TestResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_timeSpend);
            this.Controls.Add(this.lbl_solvedPercent);
            this.Controls.Add(this.lbl_mark);
            this.Controls.Add(this.txtbx_log);
            this.Controls.Add(this.lbl_wasCalcDiabled);
            this.Controls.Add(this.lbl_timeEnd);
            this.Controls.Add(this.lbl_timeStart);
            this.Controls.Add(this.lbl_state);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestResultForm";
            this.Text = "Результат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_state;
        private System.Windows.Forms.Label lbl_timeStart;
        private System.Windows.Forms.Label lbl_timeEnd;
        private System.Windows.Forms.Label lbl_wasCalcDiabled;
        private System.Windows.Forms.RichTextBox txtbx_log;
        private System.Windows.Forms.Label lbl_mark;
        private System.Windows.Forms.Label lbl_solvedPercent;
        private System.Windows.Forms.Label lbl_timeSpend;
    }
}