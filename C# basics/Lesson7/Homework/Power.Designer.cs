
namespace Homework
{
    partial class Power
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
            this.labelNumber = new System.Windows.Forms.Label();
            this.bttnPlus1 = new System.Windows.Forms.Button();
            this.bttnReset = new System.Windows.Forms.Button();
            this.bttnX2 = new System.Windows.Forms.Button();
            this.bttnPlay = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelGoal = new System.Windows.Forms.Label();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNumber.Location = new System.Drawing.Point(12, 9);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(29, 31);
            this.labelNumber.TabIndex = 0;
            this.labelNumber.Text = "0";
            // 
            // bttnPlus1
            // 
            this.bttnPlus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttnPlus1.Location = new System.Drawing.Point(106, 12);
            this.bttnPlus1.Name = "bttnPlus1";
            this.bttnPlus1.Size = new System.Drawing.Size(153, 42);
            this.bttnPlus1.TabIndex = 1;
            this.bttnPlus1.Text = "+1";
            this.bttnPlus1.UseVisualStyleBackColor = true;
            this.bttnPlus1.Click += new System.EventHandler(this.bttnPlus1_Click);
            // 
            // bttnReset
            // 
            this.bttnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttnReset.Location = new System.Drawing.Point(106, 133);
            this.bttnReset.Name = "bttnReset";
            this.bttnReset.Size = new System.Drawing.Size(153, 42);
            this.bttnReset.TabIndex = 2;
            this.bttnReset.Text = "Reset";
            this.bttnReset.UseVisualStyleBackColor = true;
            this.bttnReset.Click += new System.EventHandler(this.bttnReset_Click);
            // 
            // bttnX2
            // 
            this.bttnX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttnX2.Location = new System.Drawing.Point(106, 73);
            this.bttnX2.Name = "bttnX2";
            this.bttnX2.Size = new System.Drawing.Size(153, 42);
            this.bttnX2.TabIndex = 3;
            this.bttnX2.Text = "x2";
            this.bttnX2.UseVisualStyleBackColor = true;
            this.bttnX2.Click += new System.EventHandler(this.bttnX2_Click);
            // 
            // bttnPlay
            // 
            this.bttnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttnPlay.Location = new System.Drawing.Point(106, 191);
            this.bttnPlay.Name = "bttnPlay";
            this.bttnPlay.Size = new System.Drawing.Size(153, 42);
            this.bttnPlay.TabIndex = 4;
            this.bttnPlay.Text = "Play";
            this.bttnPlay.UseVisualStyleBackColor = true;
            this.bttnPlay.Click += new System.EventHandler(this.bttnPlay_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCount.Location = new System.Drawing.Point(12, 316);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(29, 31);
            this.labelCount.TabIndex = 5;
            this.labelCount.Text = "0";
            // 
            // labelGoal
            // 
            this.labelGoal.AutoSize = true;
            this.labelGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGoal.Location = new System.Drawing.Point(12, 73);
            this.labelGoal.Name = "labelGoal";
            this.labelGoal.Size = new System.Drawing.Size(0, 31);
            this.labelGoal.TabIndex = 6;
            // 
            // bttnCancel
            // 
            this.bttnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttnCancel.Location = new System.Drawing.Point(106, 251);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(153, 42);
            this.bttnCancel.TabIndex = 7;
            this.bttnCancel.Text = "Cancel";
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // Power
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 409);
            this.Controls.Add(this.bttnCancel);
            this.Controls.Add(this.labelGoal);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.bttnPlay);
            this.Controls.Add(this.bttnX2);
            this.Controls.Add(this.bttnReset);
            this.Controls.Add(this.bttnPlus1);
            this.Controls.Add(this.labelNumber);
            this.Name = "Power";
            this.Text = "Power";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Button bttnPlus1;
        private System.Windows.Forms.Button bttnReset;
        private System.Windows.Forms.Button bttnX2;
        private System.Windows.Forms.Button bttnPlay;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelGoal;
        private System.Windows.Forms.Button bttnCancel;
    }
}

