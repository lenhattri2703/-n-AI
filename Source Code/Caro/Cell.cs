using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Giao_Dien
{
    class Cell      // Ô cờ
    {
        public const int height = 27;       // chiều cao
        public const int width = 27;        // chiều rộng

        private int r;      // dòng
        private int c;      // cột
        private Point p;    // vị trí
        private int sh;     // sở hữu (ô đó sở hữu quân đen hay đỏ)  

        public int rows
        {
            set
            {
                r = value;
            }

            get
            {
                return r;
            }
        }

        public int columns
        {
            set
            {
                r = value;
            }

            get
            {
                return c;
            }
        }


        public Point pos
        {
            set
            {
                p = value;
            }

            get
            {
                return p;
            }
        }

        public int soHuu
        {
            set
            {
                sh = value;
            }

            get
            {
                return sh;
            }
        }

        public Cell(int rows, int columns, Point pos, int sohuu)
        {
            r = rows;
            c = columns;
            p = pos;
            sh = sohuu;
        }

        public Cell() {}
    }
}
