using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeGame
{
    public partial class TicTacToe : Form
    {

        // https://coolors.co/palette/f72585-7209b7-3a0ca3-4361ee-4cc9f0

        private char[,] board = new char[3, 3];
        private bool isPlayerXTurn = true;
        private int moveCount = 0;
        private int XWinsCount = 0;
        private int OWinsCount = 0;

        public TicTacToe()
        {
            InitializeComponent();
        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = '-';
            isPlayerXTurn = true;

        }

        //Check if the move is a win
        private bool CheckWin(int row, int col)
        {
            char current = board[row, col];

            // Check row, column, diagonals
            return (board[row, 0] == current && board[row, 1] == current && board[row, 2] == current) ||
                   (board[0, col] == current && board[1, col] == current && board[2, col] == current) ||
                   (board[0, 0] == current && board[1, 1] == current && board[2, 2] == current) ||
                   (board[0, 2] == current && board[1, 1] == current && board[2, 0] == current);
        }

        private void turnNotification(bool xTurn)
        {
            if (xTurn)
            {
                YTurnLabel.Visible = false;
                XTurnLabel.Visible = true;
                XTurnLabel.Text = "Player X turn";
            }
            else
            {
                XTurnLabel.Visible = false;
                YTurnLabel.Visible = true;
                YTurnLabel.Text = "Player O Turn";
            }
        }

        private void checkStatus(int row, int col, int moveCounts, bool isXTurn)
        {
            if (CheckWin(row, col))
            {
                WinnerNotif.Visible = true;
                WinnerNotif.Text = isXTurn ? "Player O Wins!" : "Player X Wins!";
                if(WinnerNotif.Text.Equals("Player O Wins!"))
                {
                    OWinsCount++;
                    OWinCount.Text = OWinsCount.ToString();
                }
                else
                {
                    XWinsCount++;
                    XWinCount.Text = XWinsCount.ToString();
                }
                DisableAllButtons(); // Optional: Disable buttons after a win
            }
            else if (moveCount == 9)
            {
                WinnerNotif.Visible = true;
                WinnerNotif.Text = "   It's a Draw!";
                DisableAllButtons();
            }
            else
            {
                turnNotification(isXTurn); // Update turn notification
            }
        }


        private void DisableAllButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Name.Contains("Row"))
                {
                    button.Enabled = false;
                }
                else if (control.HasChildren) // Check for nested controls
                {
                    DisableButtonsInContainer(control);
                }
            }
        }

        private void DisableButtonsInContainer(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is Button button && button.Name.Contains("Row"))
                {
                    button.Enabled = false;
                }
                else if (control.HasChildren)
                {
                    DisableButtonsInContainer(control);
                }
            }
        }



        //Row1

        private void Row1Col1Btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Row1Col1Btn.Text)) return;

            if (isPlayerXTurn)
            { 
                board[0, 0] = 'X';
                Row1Col1Btn.Text = board[0, 0].ToString();
                Row1Col1Btn.ForeColor = Color.Cyan;
                isPlayerXTurn = false;
                moveCount++;
                checkStatus(0, 0, moveCount, isPlayerXTurn);
            }
            else
            {
                board[0, 0] = 'O';
                Row1Col1Btn.Text = board[0, 0].ToString();
                Row1Col1Btn.ForeColor = Color.Red;
                isPlayerXTurn = true;
                moveCount++;
                checkStatus(0, 0, moveCount, isPlayerXTurn);
            }
        }

        private void Row1Col2Btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Row1Col2Btn.Text)) return;

            if (isPlayerXTurn)
            {
                board[0, 1] = 'X';
                Row1Col2Btn.Text = board[0, 1].ToString();
                isPlayerXTurn = false;
                Row1Col2Btn.ForeColor = Color.Cyan;
                moveCount++;
                checkStatus(0, 1, moveCount, isPlayerXTurn);
            }
            else
            {
                board[0, 1] = 'O';
                Row1Col2Btn.Text = board[0, 1].ToString();
                isPlayerXTurn = true;
                Row1Col2Btn.ForeColor = Color.Red;
                moveCount++;
                checkStatus(0, 1, moveCount, isPlayerXTurn);
            }
        }

        private void Row1Col3Btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Row1Col3Btn.Text)) return;

            if (isPlayerXTurn)
            {
                board[0, 2] = 'X';
                Row1Col3Btn.Text = board[0, 2].ToString();
                isPlayerXTurn = false;
                Row1Col3Btn.ForeColor = Color.Cyan;
                moveCount++;
                checkStatus(0, 2, moveCount, isPlayerXTurn);
            }
            else
            {
                board[0, 2] = 'O';
                Row1Col3Btn.Text = board[0, 2].ToString();
                isPlayerXTurn = true;
                Row1Col3Btn.ForeColor = Color.Red;
                moveCount++;
                checkStatus(0, 2, moveCount, isPlayerXTurn);
            }
        }

        //Row 2

        private void Row2Col1Btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Row2Col1Btn.Text)) return;

            if (isPlayerXTurn)
            {
                board[1, 0] = 'X';
                Row2Col1Btn.Text = board[1, 0].ToString();
                isPlayerXTurn = false;
                Row2Col1Btn.ForeColor = Color.Cyan;
                moveCount++;
                checkStatus(1, 0, moveCount, isPlayerXTurn);
            }
            else
            {
                board[1, 0] = 'O';
                Row2Col1Btn.Text = board[1, 0].ToString();
                isPlayerXTurn = true;
                Row2Col1Btn.ForeColor = Color.Red;
                moveCount++;
                checkStatus(1, 0, moveCount, isPlayerXTurn);
            }
        }

        private void Row2Col2Btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Row2Col2Btn.Text)) return;
            if (isPlayerXTurn)
            {
                board[1, 1] = 'X';
                Row2Col2Btn.Text = board[1, 1].ToString();
                isPlayerXTurn = false;
                Row2Col2Btn.ForeColor = Color.Cyan;
                moveCount++;
                checkStatus(1, 1, moveCount, isPlayerXTurn);
            }
            else
            {
                board[1, 1] = 'O';
                Row2Col2Btn.Text = board[1, 1].ToString();
                isPlayerXTurn = true;
                Row2Col2Btn.ForeColor = Color.Red;
                moveCount++;
                checkStatus(1, 1, moveCount, isPlayerXTurn);
            }
        }

        private void Row2Col3Btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Row2Col3Btn.Text)) return;

            if (isPlayerXTurn)
            {
                board[1, 2] = 'X';
                Row2Col3Btn.Text = board[1, 2].ToString();
                isPlayerXTurn = false;
                Row2Col3Btn.ForeColor = Color.Cyan;
                moveCount++;
                checkStatus(1, 2, moveCount, isPlayerXTurn);
            }
            else
            {
                board[1, 2] = 'O';
                Row2Col3Btn.Text = board[1, 2].ToString();
                isPlayerXTurn = true;
                Row2Col3Btn.ForeColor = Color.Red;
                moveCount++;
                checkStatus(1, 2, moveCount, isPlayerXTurn);
            }
        }

        //Row 3

        private void Row3Col1Btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Row3Col1Btn.Text)) return;

            if (isPlayerXTurn)
            {
                board[2, 0] = 'X';
                Row3Col1Btn.Text = board[2, 0].ToString();
                isPlayerXTurn = false;
                Row3Col1Btn.ForeColor = Color.Cyan;
                moveCount++;
                checkStatus(2, 0, moveCount, isPlayerXTurn);
            }
            else
            {
                board[2, 0] = 'O';
                Row3Col1Btn.Text = board[2, 0].ToString();
                isPlayerXTurn = true;
                Row3Col1Btn.ForeColor = Color.Red;
                moveCount++;
                checkStatus(2, 0, moveCount, isPlayerXTurn);
            }
        }

        private void Row3Col2Btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Row3Col2Btn.Text)) return;

            if (isPlayerXTurn)
            {
                board[2, 1] = 'X';
                Row3Col2Btn.Text = board[2, 1].ToString();
                isPlayerXTurn = false;
                Row3Col2Btn.ForeColor = Color.Cyan;
                moveCount++;
                checkStatus(2, 1, moveCount, isPlayerXTurn);
            }
            else
            {
                board[2, 1] = 'O';
                Row3Col2Btn.Text = board[2, 1].ToString();
                isPlayerXTurn = true;
                Row3Col2Btn.ForeColor = Color.Red;
                moveCount++;
                checkStatus(2, 1, moveCount, isPlayerXTurn);
            }
        }

        private void Row3Col3Btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Row3Col3Btn.Text)) return;
            if (isPlayerXTurn)
            {
                board[2, 2] = 'X';
                Row3Col3Btn.Text = board[2, 2].ToString();
                isPlayerXTurn = false;
                Row3Col3Btn.ForeColor = Color.Cyan;
                moveCount++;
                checkStatus(2, 2, moveCount, isPlayerXTurn);
            }
            else
            {
                board[2, 2] = 'O';
                Row3Col3Btn.Text = board[2, 2].ToString();
                isPlayerXTurn = true;
                Row3Col3Btn.ForeColor = Color.Red;
                moveCount++;
                checkStatus(2, 2, moveCount, isPlayerXTurn);
            }
        }

        private void EnableAllButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Name.Contains("Row"))
                {
                    button.Enabled = true;
                }
                else if (control.HasChildren) // Check for nested controls
                {
                    EnableButtonsInContainer(control);
                }
            }
        }

        private void EnableButtonsInContainer(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is Button button && button.Name.Contains("Row"))
                {
                    button.Enabled = true;
                }
                else if (control.HasChildren)
                {
                    EnableButtonsInContainer(control);
                }
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetBoard();
            ResetScores();
            EnableAllButtons();
        }

        private void AgainButton_Click(object sender, EventArgs e)
        {
            ResetBoard();
            EnableAllButtons();
        }

        private void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = '-';

            isPlayerXTurn = true;
            ClearButtonText();
            moveCount = 0;
            WinnerNotif.Visible = false;
        }

        private void ResetScores()
        {
            XWinsCount = 0;
            OWinsCount = 0;
            XWinCount.Text = XWinsCount.ToString();
            OWinCount.Text = OWinsCount.ToString();
        }

        private void ClearButtonText()
        {
            Row1Col1Btn.Text = "";
            Row1Col2Btn.Text = "";
            Row1Col3Btn.Text = "";
            Row2Col1Btn.Text = "";
            Row2Col2Btn.Text = "";
            Row2Col3Btn.Text = "";
            Row3Col1Btn.Text = "";
            Row3Col2Btn.Text = "";
            Row3Col3Btn.Text = "";
        }

    }
}
