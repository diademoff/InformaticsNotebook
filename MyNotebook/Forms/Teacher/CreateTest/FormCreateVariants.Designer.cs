namespace MyNotebook.Forms.Teacher.CreateTest
{
    partial class FormCreateVariants
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateVariants));
            this.lbl_numOfVariants = new System.Windows.Forms.Label();
            this.ud_numOfVariants = new System.Windows.Forms.NumericUpDown();
            this.checkbx_saveDifferentFiles = new System.Windows.Forms.CheckBox();
            this.btn_create = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ud_numOfVariants)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_numOfVariants
            // 
            this.lbl_numOfVariants.AutoSize = true;
            this.lbl_numOfVariants.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_numOfVariants.Location = new System.Drawing.Point(12, 23);
            this.lbl_numOfVariants.Name = "lbl_numOfVariants";
            this.lbl_numOfVariants.Size = new System.Drawing.Size(204, 20);
            this.lbl_numOfVariants.TabIndex = 0;
            this.lbl_numOfVariants.Text = "Количество вариантов";
            // 
            // ud_numOfVariants
            // 
            this.ud_numOfVariants.Location = new System.Drawing.Point(222, 26);
            this.ud_numOfVariants.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
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
            // checkbx_saveDifferentFiles
            // 
            this.checkbx_saveDifferentFiles.AutoSize = true;
            this.checkbx_saveDifferentFiles.Location = new System.Drawing.Point(16, 60);
            this.checkbx_saveDifferentFiles.Name = "checkbx_saveDifferentFiles";
            this.checkbx_saveDifferentFiles.Size = new System.Drawing.Size(166, 17);
            this.checkbx_saveDifferentFiles.TabIndex = 2;
            this.checkbx_saveDifferentFiles.Text = "Сохранить в разные файлы";
            this.checkbx_saveDifferentFiles.UseVisualStyleBackColor = true;
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(670, 403);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(112, 34);
            this.btn_create.TabIndex = 3;
            this.btn_create.Text = "Создать";
            this.btn_create.UseVisualStyleBackColor = true;
            // 
            // FormCreateVariants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 449);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.checkbx_saveDifferentFiles);
            this.Controls.Add(this.ud_numOfVariants);
            this.Controls.Add(this.lbl_numOfVariants);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCreateVariants";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание вариантов";
            ((System.ComponentModel.ISupportInitialize)(this.ud_numOfVariants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_numOfVariants;
        private System.Windows.Forms.NumericUpDown ud_numOfVariants;
        private System.Windows.Forms.CheckBox checkbx_saveDifferentFiles;
        private System.Windows.Forms.Button btn_create;
    }
}