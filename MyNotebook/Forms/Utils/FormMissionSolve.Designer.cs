namespace MyNotebook.Forms
{
    partial class FormMissionSolve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMissionSolve));
            this.lbl_user = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.lbl_isCalcBlockEnabled = new System.Windows.Forms.Label();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.btn_finishTest = new System.Windows.Forms.Button();
            this.lbl_isTopMost = new System.Windows.Forms.Label();
            this.lbl_missionLeft = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lbl_user.Location = new System.Drawing.Point(8, 9);
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
            this.tabControl.Size = new System.Drawing.Size(899, 465);
            this.tabControl.TabIndex = 1;
            // 
            // lbl_isCalcBlockEnabled
            // 
            this.lbl_isCalcBlockEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_isCalcBlockEnabled.AutoSize = true;
            this.lbl_isCalcBlockEnabled.Location = new System.Drawing.Point(-1, 502);
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
            this.lbl_timer.Location = new System.Drawing.Point(847, 498);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(50, 17);
            this.lbl_timer.TabIndex = 3;
            this.lbl_timer.Text = "TIMER";
            // 
            // btn_finishTest
            // 
            this.btn_finishTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_finishTest.Location = new System.Drawing.Point(750, 2);
            this.btn_finishTest.Name = "btn_finishTest";
            this.btn_finishTest.Size = new System.Drawing.Size(151, 26);
            this.btn_finishTest.TabIndex = 4;
            this.btn_finishTest.Text = "Завершить тест";
            this.btn_finishTest.UseVisualStyleBackColor = true;
            this.btn_finishTest.Click += new System.EventHandler(this.Btn_finishTest_Click);
            // 
            // lbl_isTopMost
            // 
            this.lbl_isTopMost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_isTopMost.AutoSize = true;
            this.lbl_isTopMost.Location = new System.Drawing.Point(278, 502);
            this.lbl_isTopMost.Name = "lbl_isTopMost";
            this.lbl_isTopMost.Size = new System.Drawing.Size(57, 13);
            this.lbl_isTopMost.TabIndex = 5;
            this.lbl_isTopMost.Text = "IsTopMost";
            // 
            // lbl_missionLeft
            // 
            this.lbl_missionLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_missionLeft.AutoSize = true;
            this.lbl_missionLeft.Location = new System.Drawing.Point(489, 502);
            this.lbl_missionLeft.Name = "lbl_missionLeft";
            this.lbl_missionLeft.Size = new System.Drawing.Size(99, 13);
            this.lbl_missionLeft.TabIndex = 6;
            this.lbl_missionLeft.Text = "Осталось решить:";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(492, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(252, 26);
            this.progressBar.TabIndex = 7;
            // 
            // FormMissionSolve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 521);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbl_missionLeft);
            this.Controls.Add(this.lbl_isTopMost);
            this.Controls.Add(this.btn_finishTest);
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.lbl_isCalcBlockEnabled);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lbl_user);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMissionSolve";
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
        private System.Windows.Forms.Label lbl_isTopMost;
        private System.Windows.Forms.Label lbl_missionLeft;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}