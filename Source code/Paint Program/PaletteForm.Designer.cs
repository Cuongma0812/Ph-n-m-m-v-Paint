﻿namespace Paint_Program
{
    partial class PaletteForm
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
            AddToPaletteButton = new Button();
            SuspendLayout();
            // 
            // AddToPaletteButton
            // 
            AddToPaletteButton.Anchor = AnchorStyles.Bottom;
            AddToPaletteButton.Location = new Point(302, 398);
            AddToPaletteButton.Name = "AddToPaletteButton";
            AddToPaletteButton.Size = new Size(138, 29);
            AddToPaletteButton.TabIndex = 0;
            AddToPaletteButton.Text = "Custom Color";
            AddToPaletteButton.UseVisualStyleBackColor = true;
            AddToPaletteButton.Click += AddToPaletteButton_Click_1;
            // 
            // PaletteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddToPaletteButton);
            Name = "PaletteForm";
            Text = "PaletteForm";
            ResumeLayout(false);
        }

        #endregion

        private Button AddToPaletteButton;
    }
}