﻿namespace MyNotebook.Forms
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_task1 = new System.Windows.Forms.CheckBox();
            this.btn_next = new System.Windows.Forms.Button();
            this.cb_task2 = new System.Windows.Forms.CheckBox();
            this.cb_task3 = new System.Windows.Forms.CheckBox();
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
            // cb_task1
            // 
            this.cb_task1.AutoSize = true;
            this.cb_task1.Location = new System.Drawing.Point(17, 61);
            this.cb_task1.Name = "cb_task1";
            this.cb_task1.Size = new System.Drawing.Size(256, 17);
            this.cb_task1.TabIndex = 1;
            this.cb_task1.Text = "1. Перевод между двоичной и десятичной с.с";
            this.cb_task1.UseVisualStyleBackColor = true;
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(640, 396);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(148, 42);
            this.btn_next.TabIndex = 6;
            this.btn_next.Text = "Далее ->";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.Btn_next_Click);
            // 
            // cb_task2
            // 
            this.cb_task2.AutoSize = true;
            this.cb_task2.Location = new System.Drawing.Point(17, 84);
            this.cb_task2.Name = "cb_task2";
            this.cb_task2.Size = new System.Drawing.Size(209, 17);
            this.cb_task2.TabIndex = 7;
            this.cb_task2.Text = "2. Единицы измерения информации";
            this.cb_task2.UseVisualStyleBackColor = true;
            // 
            // cb_task3
            // 
            this.cb_task3.AutoSize = true;
            this.cb_task3.Location = new System.Drawing.Point(17, 107);
            this.cb_task3.Name = "cb_task3";
            this.cb_task3.Size = new System.Drawing.Size(353, 17);
            this.cb_task3.TabIndex = 8;
            this.cb_task3.Text = "3. Линейный алгоритм, записанный на алгоритмическом языке";
            this.cb_task3.UseVisualStyleBackColor = true;
            // 
            // SelectMissionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cb_task3);
            this.Controls.Add(this.cb_task2);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.cb_task1);
            this.Controls.Add(this.label1);
            this.Name = "SelectMissionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите задания";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_task1;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.CheckBox cb_task2;
        private System.Windows.Forms.CheckBox cb_task3;
    }
}