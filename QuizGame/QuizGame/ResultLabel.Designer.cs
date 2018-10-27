namespace QuizGame
{
    partial class ResultLabel
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.rightResultPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.rightAnswerLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rightResultPanel
            // 
            this.rightResultPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightResultPanel.Location = new System.Drawing.Point(100, 140);
            this.rightResultPanel.Name = "rightResultPanel";
            this.rightResultPanel.Size = new System.Drawing.Size(600, 550);
            this.rightResultPanel.TabIndex = 0;
            // 
            // rightAnswerLabel
            // 
            this.rightAnswerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rightAnswerLabel.Location = new System.Drawing.Point(100, 20);
            this.rightAnswerLabel.Name = "rightAnswerLabel";
            this.rightAnswerLabel.Size = new System.Drawing.Size(600, 100);
            this.rightAnswerLabel.TabIndex = 1;
            this.rightAnswerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(582, 696);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(118, 37);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // ResultLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.rightAnswerLabel);
            this.Controls.Add(this.rightResultPanel);
            this.Name = "ResultLabel";
            this.Size = new System.Drawing.Size(800, 750);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel rightResultPanel;
        private System.Windows.Forms.Label rightAnswerLabel;
        private System.Windows.Forms.Button okButton;
    }
}
