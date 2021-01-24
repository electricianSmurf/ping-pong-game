namespace tennisGame
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.ballTimer = new System.Windows.Forms.Timer(this.components);
            this.PBoxBall = new System.Windows.Forms.PictureBox();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblComputer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PBoxBall)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // ballTimer
            // 
            this.ballTimer.Enabled = true;
            this.ballTimer.Interval = 10;
            this.ballTimer.Tick += new System.EventHandler(this.ballTimer_Tick);
            // 
            // PBoxBall
            // 
            this.PBoxBall.Image = global::tennisGame.Properties.Resources.ball;
            this.PBoxBall.Location = new System.Drawing.Point(360, 185);
            this.PBoxBall.Name = "PBoxBall";
            this.PBoxBall.Size = new System.Drawing.Size(16, 16);
            this.PBoxBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBoxBall.TabIndex = 0;
            this.PBoxBall.TabStop = false;
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer.ForeColor = System.Drawing.Color.White;
            this.lblPlayer.Location = new System.Drawing.Point(67, 12);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(48, 13);
            this.lblPlayer.TabIndex = 2;
            this.lblPlayer.Text = "Player: 0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Controls.Add(this.lblComputer);
            this.panel1.Controls.Add(this.lblPlayer);
            this.panel1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Location = new System.Drawing.Point(1, 443);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 46);
            this.panel1.TabIndex = 3;
            // 
            // lblComputer
            // 
            this.lblComputer.AutoSize = true;
            this.lblComputer.BackColor = System.Drawing.Color.Transparent;
            this.lblComputer.ForeColor = System.Drawing.Color.White;
            this.lblComputer.Location = new System.Drawing.Point(264, 12);
            this.lblComputer.Name = "lblComputer";
            this.lblComputer.Size = new System.Drawing.Size(64, 13);
            this.lblComputer.TabIndex = 4;
            this.lblComputer.Text = "Computer: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(714, 489);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PBoxBall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Tennis";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PBoxBall)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBoxBall;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer ballTimer;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblComputer;
    }
}

