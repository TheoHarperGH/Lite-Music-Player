namespace MusicPlayerTH
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
            lblCredits = new Label();
            SuspendLayout();
            // 
            // lblCredits
            // 
            lblCredits.Font = new Font("Bahnschrift", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCredits.ForeColor = Color.White;
            lblCredits.Location = new Point(0, 9);
            lblCredits.Name = "lblCredits";
            lblCredits.Size = new Size(383, 351);
            lblCredits.TabIndex = 0;
            lblCredits.Text = "Lite Music Player v1.0 By Theo Harper";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(384, 361);
            Controls.Add(lblCredits);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form2";
            Text = "About Lite Music Player";
            ResumeLayout(false);
        }

        #endregion

        private Label lblCredits;
    }
}