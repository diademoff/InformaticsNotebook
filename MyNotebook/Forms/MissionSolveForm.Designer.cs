namespace MyNotebook.Forms
{
    partial class MissionSolveForm
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
            this.lbl_user = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.lbl_isCalcBlockEnabled = new System.Windows.Forms.Label();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.btn_finishTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lbl_user.Location = new System.Drawing.Point(-1, 9);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(102, 17);
            this.lbl_user.TabIndex = 0;
            this.lbl_user.Text = "USER STRING";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(2, 29);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(796, 407);
            this.tabControl.TabIndex = 1;
            // 
            // lbl_isCalcBlockEnabled
            // 
            this.lbl_isCalcBlockEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_isCalcBlockEnabled.AutoSize = true;
            this.lbl_isCalcBlockEnabled.Location = new System.Drawing.Point(-1, 444);
            this.lbl_isCalcBlockEnabled.Name = "lbl_isCalcBlockEnabled";
            this.lbl_isCalcBlockEnabled.Size = new System.Drawing.Size(102, 13);
            this.lbl_isCalcBlockEnabled.TabIndex = 2;
            this.lbl_isCalcBlockEnabled.Text = "IsCalcBlockEnabled";
            // 
            // lbl_timer
            // 
            this.lbl_timer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lbl_timer.Location = new System.Drawing.Point(744, 440);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(50, 17);
            this.lbl_timer.TabIndex = 3;
            this.lbl_timer.Text = "TIMER";
            // 
            // btn_finishTest
            // 
            this.btn_finishTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_finishTest.Location = new System.Drawing.Point(647, 2);
            this.btn_finishTest.Name = "btn_finishTest";
            this.btn_finishTest.Size = new System.Drawing.Size(151, 26);
            this.btn_finishTest.TabIndex = 4;
            this.btn_finishTest.Text = "Завершить тест";
            this.btn_finishTest.UseVisualStyleBackColor = true;
            this.btn_finishTest.Click += new System.EventHandler(this.Btn_finishTest_Click);
            // 
            // MissionSolveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 463);
            this.Controls.Add(this.btn_finishTest);
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.lbl_isCalcBlockEnabled);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lbl_user);
            this.Name = "MissionSolveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Решение заданий";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label lbl_isCalcBlockEnabled;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Button btn_finishTest;
    }
}