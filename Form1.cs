using CSCore;
using CSCore.Codecs;
using CSCore.DSP;
using CSCore.SoundOut;
using CSCore.Streams;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MusicPlayerTH
{
    public partial class Form1 : Form
    {
        //Declaring Stuff blah blah
        
        int currentIndex;

        private ISoundOut soundOut;
        private IWaveSource waveSource;
        
        // Playlist of file paths
        private List<string> playlist = new List<string>();

        private FftProvider fftProvider;
        private System.Windows.Forms.Timer visualizerTimer;
        private const int fftSize = 1024;
        private float[] previousHeights = new float[64]; // match barCount



        //This Section has visualiser stuff, have no idea what half it does lmao
        private void InitVisualizer(IWaveSource source)
        {
            fftProvider = new FftProvider(source.WaveFormat.Channels, FftSize.Fft1024);

            var sampleSource = source.ToSampleSource();

            var notificationSource = new SingleBlockNotificationStream(sampleSource);
            notificationSource.SingleBlockRead += (s, a) =>
            {
                fftProvider.Add(a.Left, a.Right);
            };

            waveSource = notificationSource.ToWaveSource();

            visualizerTimer = new System.Windows.Forms.Timer();
            visualizerTimer.Interval = 16; 
            visualizerTimer.Tick += VisualizerTimer_Tick;
            visualizerTimer.Start();
        }




        private void VisualizerTimer_Tick(object sender, EventArgs e)
        {
            float[] fftBuffer = new float[fftSize];
            if (fftProvider != null && fftProvider.GetFftData(fftBuffer))
            {
                DrawSpectrum(fftBuffer);
            }
        }




        private void DrawSpectrum(float[] fftBuffer)
        {
            int barCount = 64;
            Bitmap bmp = new Bitmap(pictureBoxSpectrum.Width, pictureBoxSpectrum.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);

                int width = pictureBoxSpectrum.Width;
                int height = pictureBoxSpectrum.Height;
                int barWidth = width / barCount;

                double logMax = Math.Log10(fftBuffer.Length);
                double[] logBins = new double[barCount + 1];
                for (int i = 0; i <= barCount; i++)
                {
                    logBins[i] = Math.Pow(10, i * logMax / barCount);
                }

                for (int i = 0; i < barCount; i++)
                {
                    int startBin = (int)logBins[i];
                    int endBin = (int)logBins[i + 1];
                    endBin = Math.Min(endBin, fftBuffer.Length - 1);

                    float sum = 0;
                    int count = 0;

                    for (int bin = startBin; bin <= endBin; bin++)
                    {
                        sum += Math.Max(0, fftBuffer[bin]);
                        count++;
                    }

                    float magnitude = (count > 0) ? sum / count : 0;

                    // --- Frequency weighting ---
                    // Calculate normalized position (0 = bass, 1 = treble)
                    float freqPos = i / (float)(barCount - 1);

                    // Bass reduction factor: lower freqPos means bigger reduction
                    float bassReduction = 1f - (float)Math.Pow(1f - freqPos, 2.5); // curve that drops bass strength
                                                                                   // Treble boost factor: raise higher frequencies slightly
                    float trebleBoost = 0.5f + 0.5f * freqPos;

                    // Combine weighting
                    float weightedMag = magnitude * bassReduction * trebleBoost;

                    // Non-linear scaling for smoother dynamics (exponent <1 compresses)
                    float scaledMag = (float)Math.Pow(weightedMag, 0.6);

                    // Clamp final magnitude so it doesn't explode visually
                    float mag = Math.Min(scaledMag * 10f, 1.0f);

                    // Calculate bar height with smoothing
                    int targetHeight = (int)(mag * height);
                    int smoothedHeight = (targetHeight + (int)previousHeights[i] * 3) / 4;
                    previousHeights[i] = smoothedHeight;

                    // New: blue gradient (dark blue low, bright cyan high)
                    int blue = 255;
                    int green = (int)(255 * (smoothedHeight / (float)height));
                    int red = 0;

                    Color barColor = Color.FromArgb(red, green, blue);
                    g.FillRectangle(new SolidBrush(barColor),
                        i * barWidth,
                        height - smoothedHeight,
                        barWidth - 2,
                        smoothedHeight);
                }
            }

            pictureBoxSpectrum.Image?.Dispose();
            pictureBoxSpectrum.Image = bmp;
        }




        private void UpdateVisualizerState()
        {
            if (soundOut == null)
                return;

            if (soundOut.PlaybackState == PlaybackState.Playing)
            {
                // Resume visualizer updates
                if (!visualizerTimer.Enabled)
                    visualizerTimer.Start();
            }
            else
            {
                // Pause or stop visualizer updates
                if (visualizerTimer.Enabled)
                    visualizerTimer.Stop();

                // Clear the visualizer display so it doesn't freeze
                if (pictureBoxSpectrum.Image != null)
                {
                    pictureBoxSpectrum.Image.Dispose();
                    pictureBoxSpectrum.Image = null;
                }
            }
        }



        //Okay main program stuff starts here
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Importing Files, wanna add VORBIS support later, mp3 outdated imo
        //i wanna rant about it but it is what it is

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Audio Files|*.mp3;*.wav;*.flac";
            ofd.Multiselect = true;  



            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    playlist.Add(file);
                    listBoxPlaylist.Items.Add(Path.GetFileName(file));
                }
            }
        }

        //Pause play button, self explanatory
        //Man this looks so bad, i should really clean this up later


        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (soundOut == null || waveSource == null)
            {
                if (playlist.Count > 0)
                {
                    PlayTrack(0);
                }
                else
                {
                    MessageBox.Show("Please add audio files to the playlist first.");
                }
                return;
            }

            if (soundOut.PlaybackState == PlaybackState.Playing)
            {
                soundOut.Pause();
            }
            else if (soundOut.PlaybackState == PlaybackState.Paused)
            {
                soundOut.Play();
            }
            else if (soundOut.PlaybackState == PlaybackState.Stopped)
            {
                waveSource.SetPosition(TimeSpan.Zero);
                soundOut.Play();
            }
            UpdateVisualizerState();
        }


        //Stop button, little broken will fix later (wont) but it does what it needs to for now

        private void listBoxPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBoxPlaylist.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < playlist.Count)
            {
                PlayTrack(selectedIndex);
            }
        }


        //This handles actual playing of a track
        //I need to study CsCore more to understand what this does lmao


        private void PlayTrack(int index)
        {
            if (soundOut != null)
            {
                soundOut.Stopped -= SoundOut_Stopped; // Unhook old event
                soundOut.Stop();
                soundOut.Dispose();
            }

            waveSource?.Dispose();

            currentIndex = index;

            var baseSource = CodecFactory.Instance.GetCodec(playlist[index]);
            InitVisualizer(baseSource);
            soundOut = new WasapiOut();
            soundOut.Initialize(waveSource);

            soundOut.Volume = TrackBarVolume.Value / 100f;


            soundOut.Stopped += SoundOut_Stopped;

            soundOut.Play();
            listBoxPlaylist.SelectedIndex = index;
            timerProgress.Start();

        }

       
        //Just making sure things don't break, which they still do.
        
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            soundOut?.Stop();
            soundOut?.Dispose();
            waveSource?.Dispose();
            base.OnFormClosing(e);
        }


        //This is the stop button, it stops playback and clears the playlist

        private void btnStop_Click(object sender, EventArgs e)
        {

            if (soundOut != null)
            {
                soundOut.Stop();
                soundOut.Dispose();
                soundOut = null;
                UpdateVisualizerState();
            }

            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;     
            }  

            playlist.Clear();
            listBoxPlaylist.Items.Clear();


            listBoxPlaylist.SelectedIndex = -1;
            timerProgress.Stop();
            progressBarTrack.Value = 0;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (playlist.Count == 0)
            {
                MessageBox.Show("Nothing to export!");
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files|*.txt";
            sfd.Title = "Export Playlist";
            sfd.FileName = "playlist.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(sfd.FileName, playlist);
                MessageBox.Show("Playlist exported successfully!");
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt";
            ofd.Title = "Import Playlist";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(ofd.FileName);

                playlist.Clear();
                listBoxPlaylist.Items.Clear();

                foreach (var path in lines)
                {
                    if (File.Exists(path))
                    {
                        playlist.Add(path);
                        listBoxPlaylist.Items.Add(Path.GetFileName(path));
                    }
                }

                MessageBox.Show("Playlist imported successfully!");
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Form2 aboutForm = new Form2();
            aboutForm.ShowDialog(this);
        }


        //Ooo this was tempermantal, ahd to shovein a try catch, if you didnt manually stop playback and close the program it would throw an error, but i think its fixed now


        private void SoundOut_Stopped(object sender, PlaybackStoppedEventArgs e)
        {
            System.Threading.Thread.Sleep(100);

            if (this.IsHandleCreated && !this.IsDisposed)
            {
                try
                {
                    this.Invoke(new Action(() =>
                    {
                        if (currentIndex + 1 < playlist.Count)
                        {
                            PlayTrack(currentIndex + 1);
                        }
                        else
                        {
                            currentIndex = -1;
                        }
                    }));
                }
                catch (ObjectDisposedException)
                {
                    
                }
            }
        }


        //Volume control, simple slider, nothing fancy


        private void TrackBarVolume_Scroll(object sender, EventArgs e)
        {
            if (soundOut != null)
            {
                soundOut.Volume = TrackBarVolume.Value / 100f;
            }
        }



        //Progress bar for the track, im gonna replace looks ugly, uses like the windows 7 style progress bar

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            if (waveSource != null && waveSource.Length > 0)
            {
                double progress = (double)waveSource.Position / waveSource.Length;
                progressBarTrack.Value = (int)(progress * progressBarTrack.Maximum);
            }
            else
            {
                progressBarTrack.Value = 0;
            }

        }
    }

}
