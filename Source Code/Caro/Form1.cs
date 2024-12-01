using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giao_Dien
{
    public partial class Form1 : Form
    {
        private CaroChess caroChess;
        private Graphics g;

        public Form1()
        {
            InitializeComponent();
            caroChess = new CaroChess();
            caroChess.initCellArray();
            g = pnlBoard.CreateGraphics();


            // Xử lí sự kiện Button
            StartMenu.Click += new EventHandler(playBox_Click);
            OptionsMenu.Click += new EventHandler(OptionsBox_Click);
            helpBox.Click += new EventHandler(supportToolStripMenuItem_Click);          // Support
            undoBox.Click += new EventHandler(undoToolStripMenuItem_Click);             // Undo
            pictureBox3.Click += new EventHandler(ToolStripMenuItem_Click);             // Exit

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
        
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pnlBoard_Paint(object sender, PaintEventArgs e)
        {
            caroChess.paintBoard(g);
            caroChess.drawAgainChess(g);
        }

        private void pnlBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (!caroChess.Start)       // nếu false thì thoát khỏi hàm
                return;                 // tức: nếu chưa chọn chế độ PvsP thì sẽ ko đánh được

            if (caroChess.playChess(e.X, e.Y, g))
                if (caroChess.TestWin())
                    caroChess.EndGame();
                else
                    if (caroChess.TypePlay == 2)
                    {
                        caroChess.initPC(g);
                        if (caroChess.TestWin())
                            caroChess.EndGame();
                    }
        }


        // Xử lí hiện Menu Rules
        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Support.Show();
        }

        // Xử lí hiện Menu Support
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About.Show();
        }

        // Xử lí Menu Undo
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caroChess.Undo(g);
        }

        // Xử lí button Play
        private void playBox_Click(object sender, EventArgs e)
        {
            

            if (NewGame.mode == 1)
            {
                g.Clear(pnlBoard.BackColor);       // xóa toàn bộ panel của bàn cờ, chỉ giữ lại màu nền của bàn cờ
                caroChess.startPvsP(g);            // bắt đầu chơi

                // Chế độ cộng điểm khi thắng

                // Đánh với người
                if (caroChess.the_end == CaroChess.TheEnd.Player1)
                {
                    int c = CaroChess.point_player1a;
                    string s1 = c.ToString();
                    Point_1.Text = s1;
                }

                if (caroChess.the_end == CaroChess.TheEnd.Player2)
                {
                    int c = CaroChess.point_player2a;
                    string s2 = c.ToString();
                    Point_2.Text = s2;
                }
            }

            // Đánh với máy
            if (NewGame.mode == 2)
            {
                g.Clear(pnlBoard.BackColor);       // xóa toàn bộ panel của bàn cờ, chỉ giữ lại màu nền của bàn cờ
                caroChess.startPvsC(g);            // bắt đầu chơi

                // Chế độ cộng điểm khi thắng
                if (caroChess.the_end == CaroChess.TheEnd.Player1)
                {
                    int c = CaroChess.point_player1a;
                    string s1 = c.ToString();
                    Point_1.Text = s1;
                }

                if (caroChess.the_end == CaroChess.TheEnd.Player2)
                {
                    int c = CaroChess.point_player2a;
                    string s2 = c.ToString();
                    Point_2.Text = s2;
                    }
            }
        }


        private void OptionsBox_Click(object sender, EventArgs e)
        {
            if (NewGame.Show() == DialogResult.OK)
            {
                if (NewGame.mode == 1)
                {
                    label1.Text = NewGame.mode1;        // Player 1 Name
                    CaroChess.name_label1 = label1.Text;

                    label2.Text = NewGame.mode2;        // Player 2 Name
                    CaroChess.name_label2 = label2.Text;

                    g.Clear(pnlBoard.BackColor);       // xóa toàn bộ panel của bàn cờ, chỉ giữ lại màu nền của bàn cờ
                    caroChess.startPvsP(g);            // bắt đầu chơi


                    Point_1.Text = "0";
                    Point_2.Text = "0";
                    CaroChess.point_player1a = 0;
                    CaroChess.point_player2a = 0;
                }

                if (NewGame.mode == 2)
                {
                    caroChess.SetLevel();               // gọi hàm thiết lập độ khó

                    label1.Text = NewGame.mode4;        // PC Name
                    CaroChess.name_label4 = label1.Text;

                    label2.Text = NewGame.mode3;        // Your Name
                    CaroChess.name_label3 = label2.Text;

                    g.Clear(pnlBoard.BackColor);       // xóa toàn bộ panel của bàn cờ, chỉ giữ lại màu nền của bàn cờ
                    caroChess.startPvsC(g);            // bắt đầu chơi


                    Point_1.Text = "0";
                    Point_2.Text = "0";
                    CaroChess.point_player1a = 0;
                    CaroChess.point_player2a = 0;
                }
            }
        }
    }
}
