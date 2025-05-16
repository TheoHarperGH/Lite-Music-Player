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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            lblCredits = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblCredits
            // 
            lblCredits.Font = new Font("Bahnschrift Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCredits.ForeColor = Color.White;
            lblCredits.Location = new Point(0, 9);
            lblCredits.Name = "lblCredits";
            lblCredits.Size = new Size(383, 91);
            lblCredits.TabIndex = 0;
            lblCredits.Text = "Lite Music Player DEV By Theo Harper";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 121);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(383, 245);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(384, 361);
            Controls.Add(pictureBox1);
            Controls.Add(lblCredits);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form2";
            Text = "About Lite Music Player";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblCredits;
        private PictureBox pictureBox1;
    }
}