﻿namespace MyNotebook.Forms
{
    partial class FormSelectMissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectMissions));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.checkbx_topMost = new System.Windows.Forms.CheckBox();
            this.checkbx_disableCalc = new System.Windows.Forms.CheckBox();
            this.lbl_numOfMissionsSelected = new System.Windows.Forms.Label();
            this.checkbx_showAnswerAtOnce = new System.Windows.Forms.CheckBox();
            this.panel_missions = new System.Windows.Forms.Panel();
            this.checkbx_onebyoneBlocks = new System.Windows.Forms.CheckBox();
            this.checkbx_randomOrder = new System.Windows.Forms.CheckBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_preview = new System.Windows.Forms.Button();
            this.checkbx_onebyoneMissions = new System.Windows.Forms.CheckBox();
            this.gb_settings = new System.Windows.Forms.GroupBox();
            this.checkbx_mistakesCorrect = new System.Windows.Forms.CheckBox();
            this.lbl_timeNeed = new System.Windows.Forms.Label();
            this.gb_showType = new System.Windows.Forms.GroupBox();
            this.gb_print = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ud_numOfVariants = new System.Windows.Forms.NumericUpDown();
            this.btn_print = new System.Windows.Forms.Button();
            this.checkbx_breakpage = new System.Windows.Forms.CheckBox();
            this.gb_settings.SuspendLayout();
            this.gb_showType.SuspendLayout();
            this.gb_print.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_numOfVariants)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 25);
            this.label1.TabIndex = 0;
            this.label1.Tag = "";
            this.label1.Text = "Выберите задания";
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(843, 581);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(130, 31);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.Btn_save_Click);
            // 
            // checkbx_topMost
            // 
            this.checkbx_topMost.AutoSize = true;
            this.checkbx_topMost.Location = new System.Drawing.Point(6, 46);
            this.checkbx_topMost.Name = "checkbx_topMost";
            this.checkbx_topMost.Size = new System.Drawing.Size(126, 17);
            this.checkbx_topMost.TabIndex = 7;
            this.checkbx_topMost.Text = "Поверх других окон";
            this.checkbx_topMost.UseVisualStyleBackColor = true;
            // 
            // checkbx_disableCalc
            // 
            this.checkbx_disableCalc.AutoSize = true;
            this.checkbx_disableCalc.Location = new System.Drawing.Point(6, 23);
            this.checkbx_disableCalc.Name = "checkbx_disableCalc";
            this.checkbx_disableCalc.Size = new System.Drawing.Size(146, 17);
            this.checkbx_disableCalc.TabIndex = 8;
            this.checkbx_disableCalc.Text = "Запретить калькулятор";
            this.checkbx_disableCalc.UseVisualStyleBackColor = true;
            // 
            // lbl_numOfMissionsSelected
            // 
            this.lbl_numOfMissionsSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_numOfMissionsSelected.AutoSize = true;
            this.lbl_numOfMissionsSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lbl_numOfMissionsSelected.Location = new System.Drawing.Point(510, 20);
            this.lbl_numOfMissionsSelected.Name = "lbl_numOfMissionsSelected";
            this.lbl_numOfMissionsSelected.Size = new System.Drawing.Size(109, 13);
            this.lbl_numOfMissionsSelected.TabIndex = 9;
            this.lbl_numOfMissionsSelected.Tag = "";
            this.lbl_numOfMissionsSelected.Text = "Заданий выбрано: 0";
            // 
            // checkbx_showAnswerAtOnce
            // 
            this.checkbx_showAnswerAtOnce.AutoSize = true;
            this.checkbx_showAnswerAtOnce.Location = new System.Drawing.Point(6, 71);
            this.checkbx_showAnswerAtOnce.Name = "checkbx_showAnswerAtOnce";
            this.checkbx_showAnswerAtOnce.Size = new System.Drawing.Size(151, 17);
            this.checkbx_showAnswerAtOnce.TabIndex = 10;
            this.checkbx_showAnswerAtOnce.Text = "Сразу показывать ответ";
            this.checkbx_showAnswerAtOnce.UseVisualStyleBackColor = true;
            // 
            // panel_missions
            // 
            this.panel_missions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_missions.AutoScroll = true;
            this.panel_missions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.panel_missions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_missions.Location = new System.Drawing.Point(17, 37);
            this.panel_missions.Name = "panel_missions";
            this.panel_missions.Size = new System.Drawing.Size(956, 434);
            this.panel_missions.TabIndex = 11;
            this.panel_missions.Tag = "";
            // 
            // checkbx_onebyoneBlocks
            // 
            this.checkbx_onebyoneBlocks.AutoSize = true;
            this.checkbx_onebyoneBlocks.Location = new System.Drawing.Point(6, 17);
            this.checkbx_onebyoneBlocks.Name = "checkbx_onebyoneBlocks";
            this.checkbx_onebyoneBlocks.Size = new System.Drawing.Size(174, 17);
            this.checkbx_onebyoneBlocks.TabIndex = 12;
            this.checkbx_onebyoneBlocks.Text = "Поочерёдно выдывать блоки";
            this.checkbx_onebyoneBlocks.UseVisualStyleBackColor = true;
            this.checkbx_onebyoneBlocks.CheckedChanged += new System.EventHandler(this.checkbx_onebyoneBlocks_CheckedChanged);
            // 
            // checkbx_randomOrder
            // 
            this.checkbx_randomOrder.AutoSize = true;
            this.checkbx_randomOrder.Enabled = false;
            this.checkbx_randomOrder.Location = new System.Drawing.Point(6, 40);
            this.checkbx_randomOrder.Name = "checkbx_randomOrder";
            this.checkbx_randomOrder.Size = new System.Drawing.Size(126, 17);
            this.checkbx_randomOrder.TabIndex = 13;
            this.checkbx_randomOrder.Text = "Случайный порядок";
            this.checkbx_randomOrder.UseVisualStyleBackColor = true;
            // 
            // btn_load
            // 
            this.btn_load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_load.Location = new System.Drawing.Point(716, 581);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(121, 31);
            this.btn_load.TabIndex = 14;
            this.btn_load.Text = "Загрузить";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_preview
            // 
            this.btn_preview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_preview.Location = new System.Drawing.Point(163, 46);
            this.btn_preview.Name = "btn_preview";
            this.btn_preview.Size = new System.Drawing.Size(180, 48);
            this.btn_preview.TabIndex = 15;
            this.btn_preview.Text = "Посмотреть тест";
            this.btn_preview.UseVisualStyleBackColor = true;
            this.btn_preview.Click += new System.EventHandler(this.btn_preview_Click);
            // 
            // checkbx_onebyoneMissions
            // 
            this.checkbx_onebyoneMissions.AutoSize = true;
            this.checkbx_onebyoneMissions.Location = new System.Drawing.Point(192, 17);
            this.checkbx_onebyoneMissions.Name = "checkbx_onebyoneMissions";
            this.checkbx_onebyoneMissions.Size = new System.Drawing.Size(186, 17);
            this.checkbx_onebyoneMissions.TabIndex = 16;
            this.checkbx_onebyoneMissions.Text = "Поочерёдно выдывать задания";
            this.checkbx_onebyoneMissions.UseVisualStyleBackColor = true;
            this.checkbx_onebyoneMissions.CheckedChanged += new System.EventHandler(this.checkbx_onebyoneMissions_CheckedChanged);
            // 
            // gb_settings
            // 
            this.gb_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_settings.Controls.Add(this.checkbx_mistakesCorrect);
            this.gb_settings.Controls.Add(this.btn_preview);
            this.gb_settings.Controls.Add(this.checkbx_topMost);
            this.gb_settings.Controls.Add(this.checkbx_disableCalc);
            this.gb_settings.Controls.Add(this.checkbx_showAnswerAtOnce);
            this.gb_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb_settings.ForeColor = System.Drawing.Color.Black;
            this.gb_settings.Location = new System.Drawing.Point(17, 475);
            this.gb_settings.Name = "gb_settings";
            this.gb_settings.Size = new System.Drawing.Size(349, 105);
            this.gb_settings.TabIndex = 17;
            this.gb_settings.TabStop = false;
            this.gb_settings.Text = "Настройки";
            // 
            // checkbx_mistakesCorrect
            // 
            this.checkbx_mistakesCorrect.AutoSize = true;
            this.checkbx_mistakesCorrect.Location = new System.Drawing.Point(169, 19);
            this.checkbx_mistakesCorrect.Name = "checkbx_mistakesCorrect";
            this.checkbx_mistakesCorrect.Size = new System.Drawing.Size(161, 17);
            this.checkbx_mistakesCorrect.TabIndex = 17;
            this.checkbx_mistakesCorrect.Text = "Вкл. работу над ошибками";
            this.checkbx_mistakesCorrect.UseVisualStyleBackColor = true;
            // 
            // lbl_timeNeed
            // 
            this.lbl_timeNeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_timeNeed.AutoSize = true;
            this.lbl_timeNeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lbl_timeNeed.Location = new System.Drawing.Point(236, 18);
            this.lbl_timeNeed.Name = "lbl_timeNeed";
            this.lbl_timeNeed.Size = new System.Drawing.Size(130, 13);
            this.lbl_timeNeed.TabIndex = 18;
            this.lbl_timeNeed.Tag = "";
            this.lbl_timeNeed.Text = "Времяни потребуется: 0";
            // 
            // gb_showType
            // 
            this.gb_showType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_showType.Controls.Add(this.checkbx_onebyoneBlocks);
            this.gb_showType.Controls.Add(this.checkbx_onebyoneMissions);
            this.gb_showType.Controls.Add(this.checkbx_randomOrder);
            this.gb_showType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb_showType.Location = new System.Drawing.Point(369, 475);
            this.gb_showType.Name = "gb_showType";
            this.gb_showType.Size = new System.Drawing.Size(384, 66);
            this.gb_showType.TabIndex = 19;
            this.gb_showType.TabStop = false;
            this.gb_showType.Text = "Отображение";
            // 
            // gb_print
            // 
            this.gb_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_print.Controls.Add(this.label2);
            this.gb_print.Controls.Add(this.ud_numOfVariants);
            this.gb_print.Controls.Add(this.btn_print);
            this.gb_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb_print.Location = new System.Drawing.Point(757, 475);
            this.gb_print.Name = "gb_print";
            this.gb_print.Size = new System.Drawing.Size(216, 100);
            this.gb_print.TabIndex = 20;
            this.gb_print.TabStop = false;
            this.gb_print.Text = "Распечатать";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Вариантов: ";
            // 
            // ud_numOfVariants
            // 
            this.ud_numOfVariants.Location = new System.Drawing.Point(86, 17);
            this.ud_numOfVariants.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_numOfVariants.Name = "ud_numOfVariants";
            this.ud_numOfVariants.Size = new System.Drawing.Size(120, 20);
            this.ud_numOfVariants.TabIndex = 1;
            this.ud_numOfVariants.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(48, 64);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(120, 29);
            this.btn_print.TabIndex = 0;
            this.btn_print.Text = "Открыть для печати";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // checkbx_breakpage
            // 
            this.checkbx_breakpage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkbx_breakpage.AutoSize = true;
            this.checkbx_breakpage.Location = new System.Drawing.Point(769, 516);
            this.checkbx_breakpage.Name = "checkbx_breakpage";
            this.checkbx_breakpage.Size = new System.Drawing.Size(200, 17);
            this.checkbx_breakpage.TabIndex = 21;
            this.checkbx_breakpage.Text = "Разрыв страницы после варианта";
            this.checkbx_breakpage.UseVisualStyleBackColor = true;
            // 
            // FormSelectMissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 643);
            this.Controls.Add(this.checkbx_breakpage);
            this.Controls.Add(this.gb_print);
            this.Controls.Add(this.gb_showType);
            this.Controls.Add(this.lbl_timeNeed);
            this.Controls.Add(this.gb_settings);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.panel_missions);
            this.Controls.Add(this.lbl_numOfMissionsSelected);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSelectMissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "no";
            this.Text = "Выберите задания";
            this.gb_settings.ResumeLayout(false);
            this.gb_settings.PerformLayout();
            this.gb_showType.ResumeLayout(false);
            this.gb_showType.PerformLayout();
            this.gb_print.ResumeLayout(false);
            this.gb_print.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_numOfVariants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.CheckBox checkbx_topMost;
        private System.Windows.Forms.CheckBox checkbx_disableCalc;
        private System.Windows.Forms.Label lbl_numOfMissionsSelected;
        private System.Windows.Forms.CheckBox checkbx_showAnswerAtOnce;
        private System.Windows.Forms.Panel panel_missions;
        private System.Windows.Forms.CheckBox checkbx_onebyoneBlocks;
        private System.Windows.Forms.CheckBox checkbx_randomOrder;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_preview;
        private System.Windows.Forms.CheckBox checkbx_onebyoneMissions;
        private System.Windows.Forms.GroupBox gb_settings;
        private System.Windows.Forms.CheckBox checkbx_mistakesCorrect;
        private System.Windows.Forms.Label lbl_timeNeed;
        private System.Windows.Forms.GroupBox gb_showType;
        private System.Windows.Forms.GroupBox gb_print;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ud_numOfVariants;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.CheckBox checkbx_breakpage;
    }
}