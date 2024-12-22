namespace Paint_Program
{
    partial class Form2
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
            numericUpDownWidth = new NumericUpDown();
            numericUpDownHeight = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            btn_ok = new Button();
            btn_cancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHeight).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownWidth
            // 
            numericUpDownWidth.Location = new Point(135, 43);
            numericUpDownWidth.Name = "numericUpDownWidth";
            numericUpDownWidth.Size = new Size(150, 27);
            numericUpDownWidth.TabIndex = 0;
            // 
            // numericUpDownHeight
            // 
            numericUpDownHeight.Location = new Point(135, 113);
            numericUpDownHeight.Name = "numericUpDownHeight";
            numericUpDownHeight.Size = new Size(150, 27);
            numericUpDownHeight.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 45);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 2;
            label1.Text = "Width:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 115);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 3;
            label2.Text = "Height:";
            // 
            // btn_ok
            // 
            btn_ok.DialogResult = DialogResult.OK;
            btn_ok.Location = new Point(40, 159);
            btn_ok.Name = "btn_ok";
            btn_ok.Size = new Size(94, 29);
            btn_ok.TabIndex = 4;
            btn_ok.Text = "Ok";
            btn_ok.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            btn_cancel.DialogResult = DialogResult.Cancel;
            btn_cancel.Location = new Point(191, 159);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(94, 29);
            btn_cancel.TabIndex = 5;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AcceptButton = btn_ok;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_cancel;
            ClientSize = new Size(322, 211);
            Controls.Add(btn_cancel);
            Controls.Add(btn_ok);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDownHeight);
            Controls.Add(numericUpDownWidth);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)numericUpDownWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDownWidth;
        private NumericUpDown numericUpDownHeight;
        private Label label1;
        private Label label2;
        private Button btn_ok;
        private Button btn_cancel;
    }
}