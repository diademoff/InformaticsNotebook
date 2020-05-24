namespace MyNotebook.Forms
{
    partial class FormStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatistics));
            this.lbl_numOfUsers = new System.Windows.Forms.Label();
            this.lbl_numOfTests = new System.Windows.Forms.Label();
            this.gb_marks = new System.Windows.Forms.GroupBox();
            this.num_ofMark2 = new System.Windows.Forms.Label();
            this.num_ofMark3 = new System.Windows.Forms.Label();
            this.num_ofMark4 = new System.Windows.Forms.Label();
            this.num_ofMark5 = new System.Windows.Forms.Label();
            this.lbl_bestUser = new System.Windows.Forms.Label();
            this.lbl_hardestMission = new System.Windows.Forms.Label();
            this.lbl_numOfMissions = new System.Windows.Forms.Label();
            this.lbl_averageTimeSpanOnMission = new System.Windows.Forms.Label();
            this.btn_export = new System.Windows.Forms.Button();
            this.dg_missions = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mistakes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.right = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_leaderBoard = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_marks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_missions)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_numOfUsers
            // 
            this.lbl_numOfUsers.AutoSize = true;
            this.lbl_numOfUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lbl_numOfUsers.Location = new System.Drawing.Point(12, 9);
            this.lbl_numOfUsers.Name = "lbl_numOfUsers";
            this.lbl_numOfUsers.Size = new System.Drawing.Size(198, 17);
            this.lbl_numOfUsers.TabIndex = 0;
            this.lbl_numOfUsers.Text = "Количество пользователей: ";
            // 
            // lbl_numOfTests
            // 
            this.lbl_numOfTests.AutoSize = true;
            this.lbl_numOfTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lbl_numOfTests.Location = new System.Drawing.Point(12, 37);
            this.lbl_numOfTests.Name = "lbl_numOfTests";
            this.lbl_numOfTests.Size = new System.Drawing.Size(218, 17);
            this.lbl_numOfTests.TabIndex = 1;
            this.lbl_numOfTests.Text = "Количество пройденых тестов: ";
            // 
            // gb_marks
            // 
            this.gb_marks.Controls.Add(this.num_ofMark2);
            this.gb_marks.Controls.Add(this.num_ofMark3);
            this.gb_marks.Controls.Add(this.num_ofMark4);
            this.gb_marks.Controls.Add(this.num_ofMark5);
            this.gb_marks.Location = new System.Drawing.Point(15, 123);
            this.gb_marks.Name = "gb_marks";
            this.gb_marks.Size = new System.Drawing.Size(238, 110);
            this.gb_marks.TabIndex = 2;
            this.gb_marks.TabStop = false;
            this.gb_marks.Text = "Оценки";
            // 
            // num_ofMark2
            // 
            this.num_ofMark2.AutoSize = true;
            this.num_ofMark2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.num_ofMark2.Location = new System.Drawing.Point(6, 76);
            this.num_ofMark2.Name = "num_ofMark2";
            this.num_ofMark2.Size = new System.Drawing.Size(136, 17);
            this.num_ofMark2.TabIndex = 4;
            this.num_ofMark2.Text = "Количество двоек: ";
            // 
            // num_ofMark3
            // 
            this.num_ofMark3.AutoSize = true;
            this.num_ofMark3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.num_ofMark3.Location = new System.Drawing.Point(6, 56);
            this.num_ofMark3.Name = "num_ofMark3";
            this.num_ofMark3.Size = new System.Drawing.Size(136, 17);
            this.num_ofMark3.TabIndex = 3;
            this.num_ofMark3.Text = "Количество троек: ";
            // 
            // num_ofMark4
            // 
            this.num_ofMark4.AutoSize = true;
            this.num_ofMark4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.num_ofMark4.Location = new System.Drawing.Point(6, 36);
            this.num_ofMark4.Name = "num_ofMark4";
            this.num_ofMark4.Size = new System.Drawing.Size(159, 17);
            this.num_ofMark4.TabIndex = 2;
            this.num_ofMark4.Text = "Количество четвёрок: ";
            // 
            // num_ofMark5
            // 
            this.num_ofMark5.AutoSize = true;
            this.num_ofMark5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.num_ofMark5.Location = new System.Drawing.Point(6, 16);
            this.num_ofMark5.Name = "num_ofMark5";
            this.num_ofMark5.Size = new System.Drawing.Size(152, 17);
            this.num_ofMark5.TabIndex = 1;
            this.num_ofMark5.Text = "Количество пятёрок: ";
            // 
            // lbl_bestUser
            // 
            this.lbl_bestUser.AutoSize = true;
            this.lbl_bestUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lbl_bestUser.Location = new System.Drawing.Point(12, 237);
            this.lbl_bestUser.Name = "lbl_bestUser";
            this.lbl_bestUser.Size = new System.Drawing.Size(118, 17);
            this.lbl_bestUser.TabIndex = 3;
            this.lbl_bestUser.Text = "Лучший ученик: ";
            // 
            // lbl_hardestMission
            // 
            this.lbl_hardestMission.AutoSize = true;
            this.lbl_hardestMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lbl_hardestMission.Location = new System.Drawing.Point(12, 257);
            this.lbl_hardestMission.Name = "lbl_hardestMission";
            this.lbl_hardestMission.Size = new System.Drawing.Size(177, 17);
            this.lbl_hardestMission.TabIndex = 4;
            this.lbl_hardestMission.Text = "Самое сложное задание: ";
            // 
            // lbl_numOfMissions
            // 
            this.lbl_numOfMissions.AutoSize = true;
            this.lbl_numOfMissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lbl_numOfMissions.Location = new System.Drawing.Point(12, 64);
            this.lbl_numOfMissions.Name = "lbl_numOfMissions";
            this.lbl_numOfMissions.Size = new System.Drawing.Size(153, 17);
            this.lbl_numOfMissions.TabIndex = 5;
            this.lbl_numOfMissions.Text = "Количество заданий: ";
            // 
            // lbl_averageTimeSpanOnMission
            // 
            this.lbl_averageTimeSpanOnMission.AutoSize = true;
            this.lbl_averageTimeSpanOnMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lbl_averageTimeSpanOnMission.Location = new System.Drawing.Point(12, 91);
            this.lbl_averageTimeSpanOnMission.Name = "lbl_averageTimeSpanOnMission";
            this.lbl_averageTimeSpanOnMission.Size = new System.Drawing.Size(294, 17);
            this.lbl_averageTimeSpanOnMission.TabIndex = 6;
            this.lbl_averageTimeSpanOnMission.Text = "Затраченное время на задание в среднем:";
            // 
            // btn_export
            // 
            this.btn_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_export.Location = new System.Drawing.Point(969, 463);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(120, 26);
            this.btn_export.TabIndex = 7;
            this.btn_export.Text = "Экспорт статистики";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // dg_missions
            // 
            this.dg_missions.AllowUserToDeleteRows = false;
            this.dg_missions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_missions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_missions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.mistakes,
            this.right,
            this.percent,
            this.time});
            this.dg_missions.Location = new System.Drawing.Point(541, 12);
            this.dg_missions.Name = "dg_missions";
            this.dg_missions.ReadOnly = true;
            this.dg_missions.Size = new System.Drawing.Size(548, 273);
            this.dg_missions.TabIndex = 8;
            // 
            // name
            // 
            this.name.HeaderText = "Название задания";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // mistakes
            // 
            this.mistakes.HeaderText = "Допущено ошибок";
            this.mistakes.Name = "mistakes";
            this.mistakes.ReadOnly = true;
            // 
            // right
            // 
            this.right.HeaderText = "Правильных ответов";
            this.right.Name = "right";
            this.right.ReadOnly = true;
            // 
            // percent
            // 
            this.percent.HeaderText = "Процент успеха";
            this.percent.Name = "percent";
            this.percent.ReadOnly = true;
            // 
            // time
            // 
            this.time.HeaderText = "Времяни затрачено (мин)";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // pnl_leaderBoard
            // 
            this.pnl_leaderBoard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_leaderBoard.AutoScroll = true;
            this.pnl_leaderBoard.Location = new System.Drawing.Point(15, 308);
            this.pnl_leaderBoard.Name = "pnl_leaderBoard";
            this.pnl_leaderBoard.Size = new System.Drawing.Size(497, 181);
            this.pnl_leaderBoard.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(12, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Лучшие ученики";
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 528);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnl_leaderBoard);
            this.Controls.Add(this.dg_missions);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.lbl_averageTimeSpanOnMission);
            this.Controls.Add(this.lbl_numOfMissions);
            this.Controls.Add(this.lbl_hardestMission);
            this.Controls.Add(this.lbl_bestUser);
            this.Controls.Add(this.gb_marks);
            this.Controls.Add(this.lbl_numOfTests);
            this.Controls.Add(this.lbl_numOfUsers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статистика";
            this.gb_marks.ResumeLayout(false);
            this.gb_marks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_missions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_numOfUsers;
        private System.Windows.Forms.Label lbl_numOfTests;
        private System.Windows.Forms.GroupBox gb_marks;
        private System.Windows.Forms.Label num_ofMark2;
        private System.Windows.Forms.Label num_ofMark3;
        private System.Windows.Forms.Label num_ofMark4;
        private System.Windows.Forms.Label num_ofMark5;
        private System.Windows.Forms.Label lbl_bestUser;
        private System.Windows.Forms.Label lbl_hardestMission;
        private System.Windows.Forms.Label lbl_numOfMissions;
        private System.Windows.Forms.Label lbl_averageTimeSpanOnMission;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.DataGridView dg_missions;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn mistakes;
        private System.Windows.Forms.DataGridViewTextBoxColumn right;
        private System.Windows.Forms.DataGridViewTextBoxColumn percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.Panel pnl_leaderBoard;
        private System.Windows.Forms.Label label1;
    }
}