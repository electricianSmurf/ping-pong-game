using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tennisGame
{
    public partial class Form1 : Form
    {
        int playerScore, computerScore;

        int computerLocY;

        int ballLocX;
        int ballLocY;

        int ballSpeedX = 7, ballSpeedY;
        int playerSpeed = 6;
        int computerSpeed = 15;

        bool isPlayerMoving;

        bool isBallMovingLeft = true;


        cRacket player;
        cRacket computer;

        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                player.isRacketMovingUp = true;
                isPlayerMoving = true;
            }
            if (e.KeyCode == Keys.S)
            {
                player.isRacketMovingDown = true;
                isPlayerMoving = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            player.isRacketMovingUp = false;
            player.isRacketMovingDown = false;
            isPlayerMoving = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            player = new cRacket(Properties.Resources.player, new Point(1, 144), this);
            computer = new cRacket(Properties.Resources.computer, new Point(695, 125), this);
            ballLocX = 360;
            ballLocY = 185;
        }
        // if player plays with arrow keys then it's more handy to direct with ProcessCmdKey
        // if letters are used then, KeyUp & Down is better
       
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (isPlayerMoving)
            {
                movePlayer();
            }
            moveComputer();
        }
        void movePlayer()
        {
            int playerLocY = player.pBox.Location.Y;
            if (playerLocY >= 0 && playerLocY <= 312)
            {
                if (player.isRacketMovingUp)
                {
                    playerLocY -= playerSpeed;
                }
                else if (player.isRacketMovingDown)
                {
                    playerLocY += playerSpeed;
                }
            }
            playerLocY = correctPlayerPlace(playerLocY);
            player.pBox.Location = new Point(player.pBox.Location.X, playerLocY);
        }
        private int correctPlayerPlace(int locY)
        {
            if (locY < 0)
            {
                locY = 0;
            }
            else if (locY > 312)
            {
                locY = 312;
            }
            return locY;
        }
        void moveComputer()
        {
            if (computerLocY > ballLocY)
            {
                computerLocY -= computerSpeed;
            }
            if (computerLocY < ballLocY)
            {
                computerLocY += computerSpeed;
            }
            computer.pBox.Location = new Point(695, computerLocY);
        }
        
        private void ballTimer_Tick(object sender, EventArgs e)
        {
            if (PBoxBall.Bounds.IntersectsWith(player.pBox.Bounds))
            {
                hitTheBall(player);
                isBallMovingLeft = false;
            }
            else if (PBoxBall.Bounds.IntersectsWith(computer.pBox.Bounds))
            {
                hitTheBall(computer);
                isBallMovingLeft = true;
            }

            moveTheBall();
            checkIfBallHitsWall();
            detectBallDirection();
            checkComputerScored();
            checkPlayerScored();
            checkForWinner();
        }
        void hitTheBall(cRacket racket)
        {
            ballSpeedX = 10;
            int racketLocY = racket.pBox.Location.Y;
            //when the racket is still
            if (!racket.isRacketMovingDown && !racket.isRacketMovingUp)
            {
                ballSpeedY = 0;
                if (racket == computer)
                {
                    setSpeedWhenComputerStill();
                }
            }
            else if (racket.isRacketMovingDown)
            {
                if (checkEdgeHit(racketLocY))
                {
                    ballSpeedY = 8;
                }
                if (checkZone1Hit(racketLocY))
                {
                    ballSpeedY = 7;
                }
                if (checkZone2Hit(racketLocY))
                {
                    ballSpeedY = 6;
                }
                else// (checkZone3Hit)
                {
                    ballSpeedY = 8;
                }
            }
            else if (racket.isRacketMovingUp)
            {
                if (checkEdgeHit(racketLocY))
                {
                    ballSpeedY = -8;
                }
                if (checkZone1Hit(racketLocY))
                {
                    ballSpeedY = -7;
                }
                if (checkZone2Hit(racketLocY))
                {
                    ballSpeedY = -6;
                }
                else// (checkZone3Hit)
                {
                    ballSpeedY = -8;
                }
            }
        }
        private bool checkEdgeHit(int racketLocY)
        {
            bool isHit = false;
            int zoneLength = Math.Abs(ballLocY - racketLocY);
            if ((zoneLength <= 15 && zoneLength >= 0) || (zoneLength <= 125 && zoneLength >= 108))
            {
                ballSpeedX = 13;
                isHit = true;
            }
            return isHit;
        }
        private bool checkZone1Hit(int racketLocY)
        {
            bool isHit = false;
            int zoneLength = Math.Abs(ballLocY - racketLocY);
            if (zoneLength <= 36 && zoneLength >= 16)
            {
                isHit = true;
            }
            return isHit;
        }
        private bool checkZone2Hit(int racketLocY)
        {
            bool isHit = false;
            int zoneLength = Math.Abs(ballLocY - racketLocY);
            if (zoneLength <= 70 && zoneLength >= 37)
            {
                isHit = true;
            }
            return isHit;
        }
        void setSpeedWhenComputerStill()
        {
            int randomHitSelection = rnd.Next(0, 3);
            if (randomHitSelection == 0)
            {
                ballSpeedY = 0;
            }
            else if (randomHitSelection == 1)
            {
                ballSpeedY = 2;
            }
            else
            {
                ballSpeedY = -2;
            }
        }
        void moveTheBall()
        {
            ballLocY += ballSpeedY;
            if (isBallMovingLeft)
            {
                ballLocX -= ballSpeedX;
            }
            else
            {
                ballLocX += ballSpeedX;
            }
            PBoxBall.Location = new Point(ballLocX, ballLocY);
        }
        void checkIfBallHitsWall()
        {
            if (ballLocY <= 8 || ballLocY >= 425)
            {
                ballSpeedY *= -1;//reversing the ball
            }
        }
        void detectBallDirection()
        {
            if (ballSpeedY < 0)//ball going up
            {
                computer.isRacketMovingUp = true;

                computer.isRacketMovingDown = false;
            }
            if (ballSpeedY > 0)//ball going down
            {
                computer.isRacketMovingDown = true;

                computer.isRacketMovingUp = false;
            }
            if (ballSpeedY == 0)
            {
                computer.isRacketMovingDown = false;
                computer.isRacketMovingUp = false;
            }
        }
        void checkComputerScored()
        {
            if (PBoxBall.Location.X < 1)
            {
                computerScore++;
                lblComputer.Text = "Computer: " + computerScore;
                restartTheBallLocation();
            }
        }
        void checkPlayerScored()
        {
            if (PBoxBall.Location.X > 699)
            {
                playerScore++;
                lblPlayer.Text = "Player: " + playerScore;
                restartTheBallLocation();
            }
        }
        void restartTheBallLocation()
        {
            isBallMovingLeft = !isBallMovingLeft;
            ballLocX = 360;
            ballLocY = 185;
            ballSpeedX = 6;
            ballSpeedY = 0;
        }
        void checkForWinner()
        {
            if (playerScore == 5 || computerScore == 5)
            {
                ballTimer.Stop();
                gameTimer.Stop();
                showTheMessage();
            }
        }
        void showTheMessage()
        {
            if (playerScore == 5)
            {
                MessageBox.Show("You Win! x)");
            }
            else if (computerScore == 5)
            {
                MessageBox.Show("You Lost! x(");
            }
        }
    }
}
