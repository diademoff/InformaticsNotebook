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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectMissionsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.cb_topMost = new System.Windows.Forms.CheckBox();
            this.cb_disableCalc = new System.Windows.Forms.CheckBox();
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
            // cb_topMost
            // 
            this.cb_topMost.AutoSize = true;
            this.cb_topMost.Location = new System.Drawing.Point(12, 421);
            this.cb_topMost.Name = "cb_topMost";
            this.cb_topMost.Size = new System.Drawing.Size(126, 17);
            this.cb_topMost.TabIndex = 7;
            this.cb_topMost.Text = "Поверх других окон";
            this.cb_topMost.UseVisualStyleBackColor = true;
            // 
            // cb_disableCalc
            // 
            this.cb_disableCalc.AutoSize = true;
            this.cb_disableCalc.Checked = true;
            this.cb_disableCalc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_disableCalc.Location = new System.Drawing.Point(12, 398);
            this.cb_disableCalc.Name = "cb_disableCalc";
            this.cb_disableCalc.Size = new System.Drawing.Size(146, 17);
            this.cb_disableCalc.TabIndex = 8;
            this.cb_disableCalc.Text = "Запретить калькулятор";
            this.cb_disableCalc.UseVisualStyleBackColor = true;
            // 
            // SelectMissionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cb_disableCalc);
            this.Controls.Add(this.cb_topMost);
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
        private System.Windows.Forms.CheckBox cb_topMost;
        private System.Windows.Forms.CheckBox cb_disableCalc;
    }
}