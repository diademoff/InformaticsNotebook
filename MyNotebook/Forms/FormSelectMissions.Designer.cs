namespace MyNotebook.Forms
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
            this.gb_settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите задания";
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(843, 516);
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
            this.lbl_numOfMissionsSelected.Location = new System.Drawing.Point(510, 20);
            this.lbl_numOfMissionsSelected.Name = "lbl_numOfMissionsSelected";
            this.lbl_numOfMissionsSelected.Size = new System.Drawing.Size(109, 13);
            this.lbl_numOfMissionsSelected.TabIndex = 9;
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
            this.panel_missions.Location = new System.Drawing.Point(17, 37);
            this.panel_missions.Name = "panel_missions";
            this.panel_missions.Size = new System.Drawing.Size(956, 407);
            this.panel_missions.TabIndex = 11;
            // 
            // checkbx_onebyoneBlocks
            // 
            this.checkbx_onebyoneBlocks.AutoSize = true;
            this.checkbx_onebyoneBlocks.Location = new System.Drawing.Point(188, 23);
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
            this.checkbx_randomOrder.Location = new System.Drawing.Point(188, 46);
            this.checkbx_randomOrder.Name = "checkbx_randomOrder";
            this.checkbx_randomOrder.Size = new System.Drawing.Size(126, 17);
            this.checkbx_randomOrder.TabIndex = 13;
            this.checkbx_randomOrder.Text = "Случайный порядок";
            this.checkbx_randomOrder.UseVisualStyleBackColor = true;
            // 
            // btn_load
            // 
            this.btn_load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_load.Location = new System.Drawing.Point(716, 516);
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
            this.btn_preview.Location = new System.Drawing.Point(374, 46);
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
            this.checkbx_onebyoneMissions.Location = new System.Drawing.Point(374, 23);
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
            this.gb_settings.Controls.Add(this.checkbx_onebyoneMissions);
            this.gb_settings.Controls.Add(this.btn_preview);
            this.gb_settings.Controls.Add(this.checkbx_onebyoneBlocks);
            this.gb_settings.Controls.Add(this.checkbx_topMost);
            this.gb_settings.Controls.Add(this.checkbx_disableCalc);
            this.gb_settings.Controls.Add(this.checkbx_randomOrder);
            this.gb_settings.Controls.Add(this.checkbx_showAnswerAtOnce);
            this.gb_settings.Location = new System.Drawing.Point(17, 444);
            this.gb_settings.Name = "gb_settings";
            this.gb_settings.Size = new System.Drawing.Size(566, 105);
            this.gb_settings.TabIndex = 17;
            this.gb_settings.TabStop = false;
            this.gb_settings.Text = "Настройки";
            // 
            // SelectMissionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 555);
            this.Controls.Add(this.gb_settings);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.panel_missions);
            this.Controls.Add(this.lbl_numOfMissionsSelected);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectMissionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите задания";
            this.gb_settings.ResumeLayout(false);
            this.gb_settings.PerformLayout();
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
    }
}