
namespace HomeworkTask3
{
    partial class BelieveOrNotBelieve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BelieveOrNotBelieve));
            this.tsFile = new System.Windows.Forms.ToolStrip();
            this.tsddButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBoxQuestion = new System.Windows.Forms.TextBox();
            this.bttnAdd = new System.Windows.Forms.Button();
            this.bttnDel = new System.Windows.Forms.Button();
            this.bttnSave = new System.Windows.Forms.Button();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.cbTruth = new System.Windows.Forms.CheckBox();
            this.tsFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // tsFile
            // 
            this.tsFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddButton});
            this.tsFile.Location = new System.Drawing.Point(0, 0);
            this.tsFile.Name = "tsFile";
            this.tsFile.Size = new System.Drawing.Size(797, 25);
            this.tsFile.TabIndex = 0;
            this.tsFile.Text = "toolStrip";
            // 
            // tsddButton
            // 
            this.tsddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.miOpen,
            this.miSave,
            this.miSaveAs,
            this.miExit,
            this.miAbout});
            this.tsddButton.Image = ((System.Drawing.Image)(resources.GetObject("tsddButton.Image")));
            this.tsddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddButton.Name = "tsddButton";
            this.tsddButton.Size = new System.Drawing.Size(38, 22);
            this.tsddButton.Text = "File";
            // 
            // miNew
            // 
            this.miNew.Name = "miNew";
            this.miNew.Size = new System.Drawing.Size(114, 22);
            this.miNew.Text = "New";
            this.miNew.Click += new System.EventHandler(this.miNew_Click);
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.Size = new System.Drawing.Size(114, 22);
            this.miOpen.Text = "Open";
            this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.Size = new System.Drawing.Size(114, 22);
            this.miSave.Text = "Save";
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            // 
            // miSaveAs
            // 
            this.miSaveAs.Name = "miSaveAs";
            this.miSaveAs.Size = new System.Drawing.Size(114, 22);
            this.miSaveAs.Text = "Save As";
            this.miSaveAs.Click += new System.EventHandler(this.miSaveAs_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(114, 22);
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(114, 22);
            this.miAbout.Text = "About";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // txtBoxQuestion
            // 
            this.txtBoxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxQuestion.Location = new System.Drawing.Point(0, 28);
            this.txtBoxQuestion.Name = "txtBoxQuestion";
            this.txtBoxQuestion.Size = new System.Drawing.Size(788, 38);
            this.txtBoxQuestion.TabIndex = 1;
            // 
            // bttnAdd
            // 
            this.bttnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttnAdd.Location = new System.Drawing.Point(12, 72);
            this.bttnAdd.Name = "bttnAdd";
            this.bttnAdd.Size = new System.Drawing.Size(101, 32);
            this.bttnAdd.TabIndex = 2;
            this.bttnAdd.Text = "Add";
            this.bttnAdd.UseVisualStyleBackColor = true;
            this.bttnAdd.Click += new System.EventHandler(this.bttnAdd_Click);
            // 
            // bttnDel
            // 
            this.bttnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttnDel.Location = new System.Drawing.Point(137, 72);
            this.bttnDel.Name = "bttnDel";
            this.bttnDel.Size = new System.Drawing.Size(101, 32);
            this.bttnDel.TabIndex = 3;
            this.bttnDel.Text = "Delete";
            this.bttnDel.UseVisualStyleBackColor = true;
            this.bttnDel.Click += new System.EventHandler(this.bttnDel_Click);
            // 
            // bttnSave
            // 
            this.bttnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttnSave.Location = new System.Drawing.Point(259, 72);
            this.bttnSave.Name = "bttnSave";
            this.bttnSave.Size = new System.Drawing.Size(101, 32);
            this.bttnSave.TabIndex = 4;
            this.bttnSave.Text = "Save";
            this.bttnSave.UseVisualStyleBackColor = true;
            this.bttnSave.Click += new System.EventHandler(this.bttnSave_Click);
            // 
            // nudNumber
            // 
            this.nudNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudNumber.Location = new System.Drawing.Point(477, 72);
            this.nudNumber.Name = "nudNumber";
            this.nudNumber.Size = new System.Drawing.Size(120, 29);
            this.nudNumber.TabIndex = 5;
            this.nudNumber.ValueChanged += new System.EventHandler(this.nudNumber_ValueChanged);
            // 
            // cbTruth
            // 
            this.cbTruth.AutoSize = true;
            this.cbTruth.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbTruth.Location = new System.Drawing.Point(621, 72);
            this.cbTruth.Name = "cbTruth";
            this.cbTruth.Size = new System.Drawing.Size(88, 33);
            this.cbTruth.TabIndex = 6;
            this.cbTruth.Text = "Truth";
            this.cbTruth.UseVisualStyleBackColor = true;
            // 
            // BelieveOrNotBelieve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 133);
            this.Controls.Add(this.cbTruth);
            this.Controls.Add(this.nudNumber);
            this.Controls.Add(this.bttnSave);
            this.Controls.Add(this.bttnDel);
            this.Controls.Add(this.bttnAdd);
            this.Controls.Add(this.txtBoxQuestion);
            this.Controls.Add(this.tsFile);
            this.Name = "BelieveOrNotBelieve";
            this.Text = "BelieveOrNotBelieve";
            this.tsFile.ResumeLayout(false);
            this.tsFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsFile;
        private System.Windows.Forms.ToolStripDropDownButton tsddButton;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.TextBox txtBoxQuestion;
        private System.Windows.Forms.Button bttnAdd;
        private System.Windows.Forms.Button bttnDel;
        private System.Windows.Forms.Button bttnSave;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.CheckBox cbTruth;
        private System.Windows.Forms.ToolStripMenuItem miSaveAs;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
    }
}

