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
            tbGravitation2 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGravitation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGravitation2).BeginInit();
            SuspendLayout();
            // 
            // picDisplay
            // 
            picDisplay.Location = new Point(2, 2);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(786, 446);
            picDisplay.TabIndex = 0;
            picDisplay.TabStop = false;
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
            tbGravitation.Location = new Point(428, 454);
            tbGravitation.Maximum = 100;
            tbGravitation.Name = "tbGravitation";
            tbGravitation.Size = new Size(104, 45);
            tbGravitation.TabIndex = 3;
            tbGravitation.Scroll += tbGravitation_Scroll;
            // 
            // tbGravitation2
            // 
            tbGravitation2.Location = new Point(275, 454);
            tbGravitation2.Maximum = 100;
            tbGravitation2.Name = "tbGravitation2";
            tbGravitation2.Size = new Size(104, 45);
            tbGravitation2.TabIndex = 4;
            tbGravitation2.Scroll += tbGravitation2_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 529);
            Controls.Add(tbGravitation2);
            Controls.Add(tbGravitation);
            Controls.Add(lblDirection);
            Controls.Add(tbDirection);
            Controls.Add(picDisplay);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGravitation).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGravitation2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private TrackBar tbDirection;
        private Label lblDirection;
        private TrackBar tbGravitation;
        private TrackBar tbGravitation2;
    }
}
