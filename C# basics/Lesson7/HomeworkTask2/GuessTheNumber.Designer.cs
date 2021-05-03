
namespace HomeworkTask2
{
    partial class GuessTheNumber
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
            this.labelQuestion = new System.Windows.Forms.Label();
            this.txtBoxNumber = new System.Windows.Forms.TextBox();
            this.bttnCheck = new System.Windows.Forms.Button();
            this.bttnPlay = new System.Windows.Forms.Button();
            this.lblCheck = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQuestion.Location = new System.Drawing.Point(290, 69);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(222, 31);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "Enter the number";
            // 
            // txtBoxNumber
            // 
            this.txtBoxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxNumber.Location = new System.Drawing.Point(291, 104);
            this.txtBoxNumber.Name = "txtBoxNumber";
            this.txtBoxNumber.Size = new System.Drawing.Size(221, 38);
            this.txtBoxNumber.TabIndex = 1;
            // 
            // bttnCheck
            // 
            this.bttnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttnCheck.Location = new System.Drawing.Point(361, 164);
            this.bttnCheck.Name = "bttnCheck";
            this.bttnCheck.Size = new System.Drawing.Size(151, 39);
            this.bttnCheck.TabIndex = 2;
            this.bttnCheck.Text = "Check";
            this.bttnCheck.UseVisualStyleBackColor = true;
            this.bttnCheck.Click += new System.EventHandler(this.bttnCheck_Click);
            // 
            // bttnPlay
            // 
            this.bttnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttnPlay.Location = new System.Drawing.Point(18, 69);
            this.bttnPlay.Name = "bttnPlay";
            this.bttnPlay.Size = new System.Drawing.Size(151, 39);
            this.bttnPlay.TabIndex = 5;
            this.bttnPlay.Text = "Play";
            this.bttnPlay.UseVisualStyleBackColor = true;
            this.bttnPlay.Click += new System.EventHandler(this.bttnPlay_Click);
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCheck.Location = new System.Drawing.Point(12, 22);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(437, 31);
            this.lblCheck.TabIndex = 6;
            this.lblCheck.Text = "Press Play button to start the game";
            // 
            // GuessTheNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 232);
            this.Controls.Add(this.lblCheck);
            this.Controls.Add(this.bttnPlay);
            this.Controls.Add(this.bttnCheck);
            this.Controls.Add(this.txtBoxNumber);
            this.Controls.Add(this.labelQuestion);
            this.Name = "GuessTheNumber";
            this.Text = "GuessTheNumber";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.TextBox txtBoxNumber;
        private System.Windows.Forms.Button bttnCheck;
        private System.Windows.Forms.Button bttnPlay;
        private System.Windows.Forms.Label lblCheck;
    }
}

