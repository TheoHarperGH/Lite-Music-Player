namespace MusicPlayerTH
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listBoxPlaylist = new ListBox();
            btnOpen = new Button();
            btnPlayPause = new Button();
            btnStop = new Button();
            btnExport = new Button();
            btnImport = new Button();
            btnAbout = new Button();
            TrackBarVolume = new TrackBar();
            progressBarTrack = new ProgressBar();
            timerProgress = new System.Windows.Forms.Timer(components);
            pnlTL = new Panel();
            pnlTR = new Panel();
            pnlB = new Panel();
            pictureBoxSpectrum = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)TrackBarVolume).BeginInit();
            pnlTL.SuspendLayout();
            pnlTR.SuspendLayout();
            pnlB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSpectrum).BeginInit();
            SuspendLayout();
            // 
            // listBoxPlaylist
            // 
            listBoxPlaylist.BackColor = Color.FromArgb(16, 16, 16);
            listBoxPlaylist.BorderStyle = BorderStyle.None;
            listBoxPlaylist.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxPlaylist.ForeColor = SystemColors.Window;
            listBoxPlaylist.FormattingEnabled = true;
            listBoxPlaylist.Location = new Point(175, 4);
            listBoxPlaylist.Name = "listBoxPlaylist";
            listBoxPlaylist.Size = new Size(403, 513);
            listBoxPlaylist.TabIndex = 0;
            listBoxPlaylist.SelectedIndexChanged += listBoxPlaylist_SelectedIndexChanged;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(0, 47);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(110, 50);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Open Files";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnPlayPause
            // 
            btnPlayPause.Font = new Font("Bahnschrift Light", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPlayPause.Location = new Point(586, 56);
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.Size = new Size(75, 75);
            btnPlayPause.TabIndex = 2;
            btnPlayPause.Text = "⏯";
            btnPlayPause.UseVisualStyleBackColor = true;
            btnPlayPause.Click += btnPlayPause_Click;
            // 
            // btnStop
            // 
            btnStop.Font = new Font("Bahnschrift Light", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStop.Location = new Point(3, 56);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 75);
            btnStop.TabIndex = 3;
            btnStop.Text = "⏹";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(110, 50);
            btnExport.TabIndex = 4;
            btnExport.Text = "Save To File";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(3, 60);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(110, 50);
            btnImport.TabIndex = 5;
            btnImport.Text = "Load From File";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnAbout
            // 
            btnAbout.Location = new Point(3, 3);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(56, 24);
            btnAbout.TabIndex = 6;
            btnAbout.Text = "About";
            btnAbout.UseVisualStyleBackColor = true;
            btnAbout.Click += btnAbout_Click;
            // 
            // TrackBarVolume
            // 
            TrackBarVolume.LargeChange = 10;
            TrackBarVolume.Location = new Point(1192, 50);
            TrackBarVolume.Maximum = 100;
            TrackBarVolume.Name = "TrackBarVolume";
            TrackBarVolume.Orientation = Orientation.Vertical;
            TrackBarVolume.Size = new Size(45, 95);
            TrackBarVolume.SmallChange = 5;
            TrackBarVolume.TabIndex = 7;
            TrackBarVolume.Value = 50;
            TrackBarVolume.Scroll += TrackBarVolume_Scroll;
            // 
            // progressBarTrack
            // 
            progressBarTrack.Location = new Point(0, 21);
            progressBarTrack.Maximum = 1000;
            progressBarTrack.Name = "progressBarTrack";
            progressBarTrack.Size = new Size(1240, 23);
            progressBarTrack.TabIndex = 8;
            // 
            // timerProgress
            // 
            timerProgress.Tick += timerProgress_Tick;
            // 
            // pnlTL
            // 
            pnlTL.Controls.Add(btnOpen);
            pnlTL.Controls.Add(btnAbout);
            pnlTL.Location = new Point(12, 12);
            pnlTL.Name = "pnlTL";
            pnlTL.Size = new Size(110, 106);
            pnlTL.TabIndex = 10;
            // 
            // pnlTR
            // 
            pnlTR.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlTR.Controls.Add(btnExport);
            pnlTR.Controls.Add(btnImport);
            pnlTR.Controls.Add(listBoxPlaylist);
            pnlTR.Location = new Point(679, 12);
            pnlTR.Name = "pnlTR";
            pnlTR.Size = new Size(581, 520);
            pnlTR.TabIndex = 11;
            // 
            // pnlB
            // 
            pnlB.Anchor = AnchorStyles.Bottom;
            pnlB.Controls.Add(progressBarTrack);
            pnlB.Controls.Add(btnPlayPause);
            pnlB.Controls.Add(btnStop);
            pnlB.Controls.Add(TrackBarVolume);
            pnlB.Location = new Point(12, 538);
            pnlB.Name = "pnlB";
            pnlB.Size = new Size(1240, 145);
            pnlB.TabIndex = 12;
            // 
            // pictureBoxSpectrum
            // 
            pictureBoxSpectrum.Anchor = AnchorStyles.Bottom;
            pictureBoxSpectrum.BackColor = Color.Transparent;
            pictureBoxSpectrum.Location = new Point(12, 146);
            pictureBoxSpectrum.Name = "pictureBoxSpectrum";
            pictureBoxSpectrum.Size = new Size(661, 370);
            pictureBoxSpectrum.TabIndex = 13;
            pictureBoxSpectrum.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1264, 681);
            Controls.Add(pictureBoxSpectrum);
            Controls.Add(pnlB);
            Controls.Add(pnlTR);
            Controls.Add(pnlTL);
            Name = "Form1";
            Text = "Lite Music Player";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)TrackBarVolume).EndInit();
            pnlTL.ResumeLayout(false);
            pnlTR.ResumeLayout(false);
            pnlB.ResumeLayout(false);
            pnlB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSpectrum).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxPlaylist;
        private Button btnOpen;
        private Button btnPlayPause;
        private Button btnStop;
        private Button btnExport;
        private Button btnImport;
        private Button btnAbout;
        private TrackBar TrackBarVolume;
        private ProgressBar progressBarTrack;
        private System.Windows.Forms.Timer timerProgress;
        private Panel pnlTL;
        private Panel pnlTR;
        private Panel pnlB;
        private PictureBox pictureBoxSpectrum;
    }
}
