
namespace HomeworkTask2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBox = new System.Windows.Forms.TextBox();
            this.nmrcUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBox
            // 
            this.txtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox.Location = new System.Drawing.Point(12, 95);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(133, 38);
            this.txtBox.TabIndex = 0;
            this.txtBox.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // nmrcUpDown
            // 
            this.nmrcUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nmrcUpDown.Location = new System.Drawing.Point(12, 26);
            this.nmrcUpDown.Name = "nmrcUpDown";
            this.nmrcUpDown.Size = new System.Drawing.Size(133, 38);
            this.nmrcUpDown.TabIndex = 1;
            this.nmrcUpDown.ValueChanged += new System.EventHandler(this.nmrcUpDown_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 173);
            this.Controls.Add(this.nmrcUpDown);
            this.Controls.Add(this.txtBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.NumericUpDown nmrcUpDown;
    }
}

