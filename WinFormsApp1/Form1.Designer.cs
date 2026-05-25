namespace WinFormsApp1
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
            picDisplay = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            tbDirection = new TrackBar();
            lblDirection = new Label();
            tbGravitation = new TrackBar();
            tbTeleportRad = new TrackBar();
            tbTeleportDirect = new TrackBar();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGravitation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbTeleportRad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbTeleportDirect).BeginInit();
            SuspendLayout();
            // 
            // picDisplay
            // 
            picDisplay.Location = new Point(2, 2);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(786, 446);
            picDisplay.TabIndex = 0;
            picDisplay.TabStop = false;
            picDisplay.MouseClick += picDisplay_MouseClick;
            picDisplay.MouseMove += picDisplay_MouseMove;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // tbDirection
            // 
            tbDirection.Location = new Point(12, 454);
            tbDirection.Maximum = 359;
            tbDirection.Name = "tbDirection";
            tbDirection.Size = new Size(150, 45);
            tbDirection.TabIndex = 1;
            tbDirection.Scroll += tbDirection_Scroll;
            // 
            // lblDirection
            // 
            lblDirection.AutoSize = true;
            lblDirection.Location = new Point(162, 460);
            lblDirection.Name = "lblDirection";
            lblDirection.Size = new Size(0, 15);
            lblDirection.TabIndex = 2;
            // 
            // tbGravitation
            // 
            tbGravitation.Location = new Point(250, 454);
            tbGravitation.Maximum = 100;
            tbGravitation.Name = "tbGravitation";
            tbGravitation.Size = new Size(104, 45);
            tbGravitation.TabIndex = 3;
            tbGravitation.Scroll += tbGravitation_Scroll;
            // 
            // tbTeleportRad
            // 
            tbTeleportRad.Location = new Point(398, 454);
            tbTeleportRad.Maximum = 150;
            tbTeleportRad.Minimum = 10;
            tbTeleportRad.Name = "tbTeleportRad";
            tbTeleportRad.Size = new Size(104, 45);
            tbTeleportRad.TabIndex = 4;
            tbTeleportRad.Value = 10;
            tbTeleportRad.Scroll += tbTeleportRad_Scroll;
            // 
            // tbTeleportDirect
            // 
            tbTeleportDirect.Location = new Point(545, 454);
            tbTeleportDirect.Maximum = 360;
            tbTeleportDirect.Name = "tbTeleportDirect";
            tbTeleportDirect.Size = new Size(104, 45);
            tbTeleportDirect.TabIndex = 5;
            tbTeleportDirect.Scroll += tbTeleportDirect_Scroll;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(398, 494);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 6;
            textBox1.Text = "Размер входа";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(528, 494);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(121, 23);
            textBox2.TabIndex = 7;
            textBox2.Text = "Направление выхода";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 529);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(tbTeleportDirect);
            Controls.Add(tbTeleportRad);
            Controls.Add(tbGravitation);
            Controls.Add(lblDirection);
            Controls.Add(tbDirection);
            Controls.Add(picDisplay);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGravitation).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbTeleportRad).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbTeleportDirect).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private TrackBar tbDirection;
        private Label lblDirection;
        private TrackBar tbGravitation;
        private TrackBar tbTeleportRad;
        private TrackBar tbTeleportDirect;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
