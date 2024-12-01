    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Giao_Dien
{
    class Board         // Bàn cờ
    {
        private int numRows;        // số dòng
        private int numColumns;     // số cột

        public int nRows
        {
            get { return numRows; }
        }

        public int nColumns
        {
            get { return numColumns; }
        }

        public Board()
        {
            numRows = 0; 
            numColumns = 0;
        }

        public Board(int r, int c)
        {
            numRows = r;
            numColumns = c;
        }

        // Vẽ bàn cờ
        public void paintBoard(Graphics g)     
        {
            for(int i = 0; i <= numColumns; i++)
                g.DrawLine(CaroChess.pen, i * Cell.width, 0, i * Cell.width, numRows * Cell.height);

            for (int j = 0; j <= numRows; j++)
                g.DrawLine(CaroChess.pen, 0, j * Cell.height, numColumns * Cell.width, j * Cell.height);
        }

        // Load hình quân cờ
        public void drawChessMan(Graphics g, Point p, Image sb, int luotdi)        
        {
            if (luotdi == 1)
            {
                g.DrawImage(CaroChess.imageO, p.X + 4, p.Y + 4, Cell.width - 8, Cell.height - 8);
            }
            else
                if (luotdi == 2)
                {
                    g.DrawImage(CaroChess.imageX, p.X + 4, p.Y + 4, Cell.width - 8, Cell.height - 8);
                }
        }

        // Xóa quân cờ
        public void deleteChessMan(Graphics g, Point p, SolidBrush sb)   
        {
            g.FillRectangle(sb, p.X + 1, p.Y + 1, Cell.width - 2, Cell.height - 2);
        }
    }
}
