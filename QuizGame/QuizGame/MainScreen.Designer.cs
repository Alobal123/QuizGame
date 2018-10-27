using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace QuizGame
{
    partial class MainScreen
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

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TurnPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.teamLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ipLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TurnPanel
            // 
            this.TurnPanel.AutoSize = true;
            this.TurnPanel.Location = new System.Drawing.Point(21, 40);
            this.TurnPanel.Name = "TurnPanel";
            this.TurnPanel.Size = new System.Drawing.Size(1053, 295);
            this.TurnPanel.TabIndex = 0;
            // 
            // teamLabel
            // 
            this.teamLabel.AutoSize = true;
            this.teamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.teamLabel.Location = new System.Drawing.Point(16, 366);
            this.teamLabel.Name = "teamLabel";
            this.teamLabel.Size = new System.Drawing.Size(236, 29);
            this.teamLabel.TabIndex = 1;
            this.teamLabel.Text = "Registered Teams:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ipLabel
            // 
            this.ipLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ipLabel.AutoSize = true;
            this.ipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ipLabel.Location = new System.Drawing.Point(488, 429);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(247, 73);
            this.ipLabel.TabIndex = 2;
            this.ipLabel.Text = "ipLabel";
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 688);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.teamLabel);
            this.Controls.Add(this.TurnPanel);
            this.Name = "MainScreen";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreen_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel TurnPanel;
        private Label teamLabel;
        private Timer timer1;
        private Label ipLabel;
    }
}

