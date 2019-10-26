namespace MyNotebook.Forms
{
    partial class SelectMissionsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectMissionsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.checkbx_topMost = new System.Windows.Forms.CheckBox();
            this.checkbx_disableCalc = new System.Windows.Forms.CheckBox();
            this.lbl_numOfMissionsSelected = new System.Windows.Forms.Label();
            this.updateUI = new System.Windows.Forms.Timer(this.components);
            this.checkbx_showAnswerAtOnce = new System.Windows.Forms.CheckBox();
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
            this.btn_save.Location = new System.Drawing.Point(640, 396);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(148, 42);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.Btn_save_Click);
            // 
            // checkbx_topMost
            // 
            this.checkbx_topMost.AutoSize = true;
            this.checkbx_topMost.Location = new System.Drawing.Point(12, 396);
            this.checkbx_topMost.Name = "checkbx_topMost";
            this.checkbx_topMost.Size = new System.Drawing.Size(126, 17);
            this.checkbx_topMost.TabIndex = 7;
            this.checkbx_topMost.Text = "Поверх других окон";
            this.checkbx_topMost.UseVisualStyleBackColor = true;
            // 
            // checkbx_disableCalc
            // 
            this.checkbx_disableCalc.AutoSize = true;
            this.checkbx_disableCalc.Checked = true;
            this.checkbx_disableCalc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbx_disableCalc.Location = new System.Drawing.Point(12, 373);
            this.checkbx_disableCalc.Name = "checkbx_disableCalc";
            this.checkbx_disableCalc.Size = new System.Drawing.Size(146, 17);
            this.checkbx_disableCalc.TabIndex = 8;
            this.checkbx_disableCalc.Text = "Запретить калькулятор";
            this.checkbx_disableCalc.UseVisualStyleBackColor = true;
            // 
            // lbl_numOfMissionsSelected
            // 
            this.lbl_numOfMissionsSelected.AutoSize = true;
            this.lbl_numOfMissionsSelected.Location = new System.Drawing.Point(520, 40);
            this.lbl_numOfMissionsSelected.Name = "lbl_numOfMissionsSelected";
            this.lbl_numOfMissionsSelected.Size = new System.Drawing.Size(103, 13);
            this.lbl_numOfMissionsSelected.TabIndex = 9;
            this.lbl_numOfMissionsSelected.Text = "Заданий выбрано: ";
            // 
            // updateUI
            // 
            this.updateUI.Enabled = true;
            this.updateUI.Interval = 250;
            this.updateUI.Tick += new System.EventHandler(this.updateUI_Tick);
            // 
            // checkbx_showAnswerAtOnce
            // 
            this.checkbx_showAnswerAtOnce.AutoSize = true;
            this.checkbx_showAnswerAtOnce.Location = new System.Drawing.Point(12, 421);
            this.checkbx_showAnswerAtOnce.Name = "checkbx_showAnswerAtOnce";
            this.checkbx_showAnswerAtOnce.Size = new System.Drawing.Size(151, 17);
            this.checkbx_showAnswerAtOnce.TabIndex = 10;
            this.checkbx_showAnswerAtOnce.Text = "Сразу показывать ответ";
            this.checkbx_showAnswerAtOnce.UseVisualStyleBackColor = true;
            // 
            // SelectMissionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkbx_showAnswerAtOnce);
            this.Controls.Add(this.lbl_numOfMissionsSelected);
            this.Controls.Add(this.checkbx_disableCalc);
            this.Controls.Add(this.checkbx_topMost);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectMissionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите задания";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.CheckBox checkbx_topMost;
        private System.Windows.Forms.CheckBox checkbx_disableCalc;
        private System.Windows.Forms.Label lbl_numOfMissionsSelected;
        private System.Windows.Forms.Timer updateUI;
        private System.Windows.Forms.CheckBox checkbx_showAnswerAtOnce;
    }
}