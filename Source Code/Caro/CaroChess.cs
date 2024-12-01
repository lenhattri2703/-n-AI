using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Giao_Dien
{
    class CaroChess
    {
        #region Phương thức + thuộc tính cơ bản

        public enum TheEnd          // biến để kiểm tra thắng thua
        {
            Draw, Player1, Player2
        }

        public static Pen pen;

        public static Image imageX;
        public static Image imageO;

        public static SolidBrush sbWhite;         // khai báo màu bàn cờ
        private Board board;
        private Cell[,] cellArray;
        private Stack<Cell> stack_NuocDaDi;      // Danh sách lưu các nước đã đi
        private Stack<Cell> stack_NuocUndo;      // Danh sách các nước Undo   
        private int luotDi;                     // lượt đi 1 or 2
        private bool start;                     // khai báo biến bắt đầu
        private int typePlay;
        
        public TheEnd the_end;

        // Lưu tên người chơi
        public static string name_label1;
        public static string name_label2;
        public static string name_label3;
        public static string name_label4;

        // Lưu điểm người chơi
        public static int point_player1a;
        public static int point_player2a;

        public int TypePlay
        { 
            get
            {
                return typePlay;
            }
        }

        public CaroChess()
        {
            pen = new Pen(Color.Black);                  // Khởi tạo đường kẻ màu đen

            imageO = new Bitmap(Properties.Resources.o);
            imageX = new Bitmap(Properties.Resources.x);
            sbWhite = new SolidBrush(Color.FromArgb(255, 255, 255));              // Khởi tạo màu cho bàn cờ
            board = new Board(20, 20);                  // Khởi tạo bàn cờ (20, 20)
            cellArray = new Cell[board.nRows, board.nColumns];      // Khởi tạo mảng ô cờ  
            stack_NuocDaDi = new Stack<Cell>();         // Khởi tạo Stack nước đã đi
            stack_NuocUndo = new Stack<Cell>();         // Khởi tạo Stack các nước Undo
            luotDi = 1;
        }

        public void paintBoard(Graphics g)
        {
            board.paintBoard(g);
        }

        public void initCellArray()             // Khởi tạo mảng ô cờ
        {
            for (int i = 0; i < board.nRows; i++)
                for (int j = 0; j < board.nColumns; j++)
                {
                    Point p = new Point(j * Cell.width, i * Cell.height);
                    cellArray[i, j] = new Cell(i, j, p, 0);
                }
        }

        // Đánh cờ
        public bool playChess(int MouseX, int MouseY, Graphics g)
        {
            // Xử lí để ko đánh ở đường kẻ, hạn chế đánh sai
            if (MouseX % Cell.width == 0 || MouseY % Cell.height == 0)
                return false;

            int columns = MouseX / Cell.width;
            int rows = MouseY / Cell.height;

            // Xử lí để ko đánh được vào ô đã đánh rồi
            if (cellArray[rows, columns].soHuu != 0)
                return false;

            switch (luotDi)
            {
                case 1:
                    cellArray[rows, columns].soHuu = 1;         // Gán sở hữu là 1
                    board.drawChessMan(g, cellArray[rows, columns].pos, imageO, luotDi);       // vẽ quân cờ đen lên board
                    luotDi = 2;         // khi đánh xong gán lượt đi = 2
                    break;
                case 2:
                    cellArray[rows, columns].soHuu = 2;         // Gán sở hữu là 1
                    board.drawChessMan(g, cellArray[rows, columns].pos, imageX, luotDi);       // vẽ quân cờ trắng lên board
                    luotDi = 1;         // khi đánh xong gán lượt đi = 1
                    break;
            }

            stack_NuocUndo = new Stack<Cell>();

            // tạo vùng nhớ mới cho ô cờ
            Cell cell = new Cell(cellArray[rows, columns].rows, cellArray[rows, columns].columns, cellArray[rows, columns].pos, cellArray[rows, columns].soHuu);
            stack_NuocDaDi.Push(cell);      // đưa các nước đã đi vào stack các nước đã đi

            return true;
        }


        // Vẽ lại quân cờ khi chuyển màn hình, nếu không có thì các quân cờ đang đánh sẽ bị mất
        public void drawAgainChess(Graphics g)
        {
            foreach (Cell cell in stack_NuocDaDi)
            {
                if (cell.soHuu == 1)
                    board.drawChessMan(g, cell.pos, imageO, luotDi = 1 );
                else
                    if (cell.soHuu == 2)
                        board.drawChessMan(g, cell.pos, imageX, luotDi = 2 );
            }
        }


        public bool Start       // phương thức bắt đầu
        {
            get { return start; }
        }

        public void startPvsP(Graphics g)           // bắt đầu với chế độ PvsP
        {
            start = true;
            stack_NuocDaDi = new Stack<Cell>();      // khởi tạo danh sách quân cờ mới luôn
            stack_NuocUndo = new Stack<Cell>();
            luotDi = 1;                              // Gán lượt đi đầu = 1
            initCellArray();                         // Khởi tạo mảng ô cờ
            paintBoard(g);                           // Vẽ bàn cờ
            typePlay = 1;
        }


        public void startPvsC(Graphics g)
        {
            start = true;
            stack_NuocDaDi = new Stack<Cell>();      // khởi tạo danh sách quân cờ mới luôn
            stack_NuocUndo = new Stack<Cell>();
            luotDi = 1;                              // Gán lượt đi đầu = 1
            initCellArray();                         // Khởi tạo mảng ô cờ
            paintBoard(g);                           // Vẽ bàn cờ 
            typePlay = 2;
            initPC(g);                               // khởi tạo máy tính
        }
        #endregion


        #region Xử lí Undo

        // Xử lí thao tác Undo
        public void Undo(Graphics g)
        {
            // Trường hợp PvsP
            if (typePlay == 1)
            {
                if (stack_NuocDaDi.Count != 0)
                {
                    Cell cell = stack_NuocDaDi.Pop();                   // bỏ phần tử cuối cùng đi (nước vừa mới đánh)
                    stack_NuocUndo.Push(new Cell(cell.rows, cell.columns, cell.pos, cell.soHuu));     // thêm vào các nước Undo
                    cellArray[cell.rows, cell.columns].soHuu = 0;       // ô cờ đó được gán ở hữu bằng 0
                    board.deleteChessMan(g, cell.pos, sbWhite);

                    // Xử lí lượt đi
                    if (luotDi == 1)
                        luotDi = 2;
                    else
                        luotDi = 1;
                }
            }

            // Trường hợp PvsC
            if (typePlay == 2)
            {
                if (stack_NuocDaDi.Count > 1)
                {
                    Cell cell = stack_NuocDaDi.Pop();                   // bỏ phần tử cuối cùng đi (nước vừa mới đánh)
                    stack_NuocUndo.Push(new Cell(cell.rows, cell.columns, cell.pos, cell.soHuu));     // thêm vào các nước Undo
                    cellArray[cell.rows, cell.columns].soHuu = 0;       // ô cờ đó được gán ở hữu bằng 0
                    board.deleteChessMan(g, cell.pos, sbWhite);
                    if (stack_NuocDaDi.Count > 0)
                    {
                        cell = stack_NuocDaDi.Pop();                   // bỏ phần tử cuối cùng đi (nước vừa mới đánh)
                        stack_NuocUndo.Push(new Cell(cell.rows, cell.columns, cell.pos, cell.soHuu));     // thêm vào các nước Undo
                        cellArray[cell.rows, cell.columns].soHuu = 0;       // ô cờ đó được gán ở hữu bằng 0
                        board.deleteChessMan(g, cell.pos, sbWhite);
                    }
                }
            }
        }

        #endregion


        #region Kiểm tra thắng thua

        public void EndGame()
        {
            if (typePlay == 1)
            {
                switch (the_end)
                {
                    case TheEnd.Draw:
                    {
                        MessageBox.Show("Hòa cờ !");
                        break;
                    }
                    case TheEnd.Player1:
                    {
                        MessageBox.Show(name_label1 + " chiến thắng !");
                        point_player1a += 100;
                        point_player2a += 0;
                        break;
                    }
                    case TheEnd.Player2:
                    {
                        MessageBox.Show(name_label2 + " chiến thắng !");
                        point_player2a += 100;
                        point_player1a += 0;
                        break;
                    }
                }
            }

            else if (typePlay == 2)
            {
                switch (the_end)
                {
                    case TheEnd.Draw:
                    {
                        MessageBox.Show("Hòa cờ !");
                        break;
                    }
                    case TheEnd.Player1:
                    {
                        MessageBox.Show(name_label4 + " chiến thắng !");
                        point_player1a += 100;
                        point_player2a += 0;
                        break;
                    }
                    case TheEnd.Player2:
                    {
                        MessageBox.Show(name_label3 + " chiến thắng !");
                        point_player2a += 100;
                        point_player1a += 0;
                        break;
                    }
                }
            }

            start = false;
        }

        public bool TestWin()
        {
            // Nếu người chơi đi hết các ô cờ trên bàn cờ
            if (stack_NuocDaDi.Count == board.nColumns * board.nRows)
            {
                the_end = TheEnd.Draw;

                return true;
            }

            foreach (Cell cell in stack_NuocDaDi)
            {
                if (testDoc(cell.rows, cell.columns, cell.soHuu) || testNgang(cell.rows, cell.columns, cell.soHuu)
                      || testCheoRight(cell.rows, cell.columns, cell.soHuu) || testCheoLeft(cell.rows, cell.columns, cell.soHuu))
                {
                    if (cell.soHuu == 1)
                        the_end = TheEnd.Player1;
                    else
                        the_end = TheEnd.Player2;
                    return true;
                }
            }
            return false;
        }

        // kiểm tra theo chiều dọc 
        private bool testDoc(int currRows, int currColumns, int currSoHuu)
        {
            if (currRows > board.nRows - 5)         // quân cờ ở dòng 15 thì ko thể chiến thắng được nữa
                return false;

            int count;

            // đếm xem được 5 quân liên tiếp
            for (count = 1; count < 5; count++)
            {
                // nếu trong 5 ô có 1 ô sở hữu khác 4 ô còn lại hoặc rỗng (sh=0) thì ko thể chiến thắng
                if (cellArray[currRows + count, currColumns].soHuu != currSoHuu)
                    return false;
            }

            ////// ở biên trên và biên dưới
            // TH1: 5 quân tính từ dòng 0->4 nên chỉ bị chặn 1 đầu ở dòng 5 
            // TH2: 5 quân tính từ dòng 15->19 nên chỉ bị chặn 1 đầu ở dòng 14
            if (currRows == 0 || currRows + count == board.nRows)
                return true;

            ////// ở giữa bàn cờ
            //TH1: nếu 5 quân ko bị chặn ở đầu trên ( đầu trên rỗng )
            //TH2: nếu 5 quân ko bị chặn ở đầu dưới ( đầu dưới rỗng )
            if (cellArray[currRows - 1, currColumns].soHuu == 0 || cellArray[currRows + count, currColumns].soHuu == 0)
                return true;

            return false;
        }

        // kiểm tra theo chiều ngang
        private bool testNgang(int currRows, int currColumns, int currSoHuu)
        {
            if (currColumns > board.nColumns - 5)         // quân cờ ở dòng 15 thì ko thể chiến thắng được nữa
                return false;

            int count;

            // đếm xem được 5 quân liên tiếp
            for (count = 1; count < 5; count++)
            {
                // nếu trong 5 ô có 1 ô sở hữu khác 4 ô còn lại hoặc rỗng (sh=0) thì ko thể chiến thắng
                if (cellArray[currRows, currColumns + count].soHuu != currSoHuu)
                    return false;
            }

            ////// ở biên trái và biên phải
            if (currColumns == 0 || currColumns + count == board.nColumns)
                return true;

            ////// ở giữa bàn cờ
            if (cellArray[currRows, currColumns - 1].soHuu == 0 || cellArray[currRows, currColumns + count].soHuu == 0)
                return true;

            return false;
        }

        // kiểm tra theo chiều chéo phải ( trái trên -> phải dưới). 
        // XÉT THEO CHIỀU NGANG VÀ DỌC
        private bool testCheoRight(int currRows, int currColumns, int currSoHuu)
        {
            if (currRows > board.nRows - 5 || currColumns > board.nColumns - 5)         // quân cờ ở dòng || cột 15 thì ko thể chiến thắng được nữa
                return false;

            int count;

            // đếm xem được 5 quân liên tiếp
            for (count = 1; count < 5; count++)
            {
                if (cellArray[currRows + count, currColumns + count].soHuu != currSoHuu)
                    return false;
            }

            if (currRows == 0 || currRows + count == board.nRows || currColumns == 0 || currColumns + count == board.nColumns)
                return true;

            ////// ở giữa bàn cờ
            if (cellArray[currRows - 1, currColumns - 1].soHuu == 0 || cellArray[currRows + count, currColumns + count].soHuu == 0)
                return true;

            return false;
        }

        // kiểm tra theo chiều chéo trái (trái dưới -> phải trên)
        private bool testCheoLeft(int currRows, int currColumns, int currSoHuu)
        {
            if (currRows < 4 || currColumns > board.nColumns - 5)
                return false;

            int count;

            // đếm xem được 5 quân liên tiếp
            for (count = 1; count < 5; count++)
            {
                if (cellArray[currRows - count, currColumns + count].soHuu != currSoHuu)
                    return false;
            }

            if (currRows == 4 || currRows == board.nRows - 1 || currColumns == 0 || currColumns + count == board.nColumns)
                return true;

            ////// ở giữa bàn cờ
            if (cellArray[currRows + 1, currColumns - 1].soHuu == 0 || cellArray[currRows - count, currColumns + count].soHuu == 0)
                return true;

            return false;
        }

        #endregion


        #region Mức chơi

        public long[] arr_attack = new long[7] { 0, 0, 0, 0, 0, 0, 0 };
        public long[] arr_defend = new long[7] { 0, 0, 0, 0, 0, 0, 0 };

        public void SetLevel()
        {
            int a = NewGame.level;
            switch (a)
            {
                case 1:
                {
                    arr_attack[0] = 0;
                    arr_attack[1] = 3;
                    arr_attack[2] = 12;
                    arr_attack[3] = 48;
                    arr_attack[4] = 192;
                    arr_attack[5] = 768;
                    arr_attack[6] = 3072;

                    arr_defend[0] = 0;
                    arr_defend[1] = 2;
                    arr_defend[2] = 6;
                    arr_defend[3] = 12;
                    arr_defend[4] = 60;
                    arr_defend[5] = 300;
                    arr_defend[6] = 1000;
                    break;
                }
                case 2:
                {
                    arr_attack[0] = 0;
                    arr_attack[1] = 9;
                    arr_attack[2] = 54;
                    arr_attack[3] = 162;
                    arr_attack[4] = 1458;
                    arr_attack[5] = 13122;
                    arr_attack[6] = 118098;

                    arr_defend[0] = 0;
                    arr_defend[1] = 3;
                    arr_defend[2] = 27;
                    arr_defend[3] = 99;
                    arr_defend[4] = 729;
                    arr_defend[5] = 6561;
                    arr_defend[6] = 59049;
                    break;
                }
                case 3:
                {
                    arr_attack[0] = 0;
                    arr_attack[1] = 9;
                    arr_attack[2] = 81;
                    arr_attack[3] = 729;
                    arr_attack[4] = 6561;
                    arr_attack[5] = 59049;
                    arr_attack[6] = 531441;

                    arr_defend[0] = 0;
                    arr_defend[1] = 4;
                    arr_defend[2] = 32;
                    arr_defend[3] = 256;
                    arr_defend[4] = 2048;
                    arr_defend[5] = 16384;
                    arr_defend[6] = 131072;
                    break;
                }
            }
        }
        #endregion


        #region Khởi tạo Computer
        public void initPC(Graphics g)
        {
            if (stack_NuocDaDi.Count == 0)
            {
                // máy đánh trước khi who == 1, ngược lại người sẽ đánh trước
                if (NewGame.who == 1)
                    // đánh vào ô giữa bàn cờ
                    playChess(board.nColumns / 2 * Cell.width + 1, board.nRows / 2 * Cell.height + 1, g);
            }

            else
            {
                Cell cell = SearchRoads();
                playChess(cell.pos.X + 1, cell.pos.Y + 1, g);
            }
        }
        #endregion


        #region Hàm tìm kiếm nước đi
        private Cell SearchRoads()
        {
            Cell cell = new Cell();

            long Score = 0;

            for (int i = 0; i < board.nRows; i++)
            {
                for (int j = 0; j < board.nColumns; j++)
                {
                    long p_Attack = 0;
                    long p_Defend = 0;
                    if (cellArray[i, j].soHuu == 0)
                    {
                        p_Attack += attack_Doc(i, j);
                        p_Attack += attack_Ngang(i, j);
                        p_Attack += attack_CheoLeft(i, j);
                        p_Attack += attack_CheoRight(i, j);

                        p_Defend += defend_Doc(i, j);
                        p_Defend += defend_Ngang(i, j);
                        p_Defend += defend_CheoLeft(i, j);
                        p_Defend += defend_CheoRight(i, j);


                        if (p_Defend <= p_Attack)
                        {
                            if (Score <= p_Attack)
                            {
                                Score = p_Attack;
                                cell = new Cell(cellArray[i, j].rows, cellArray[i, j].columns, cellArray[i, j].pos, cellArray[i, j].soHuu);
                            }
                        }
                        else
                        {
                            if (Score <= p_Defend)
                            {
                                Score = p_Defend;
                                cell = new Cell(cellArray[i, j].rows, cellArray[i, j].columns, cellArray[i, j].pos, cellArray[i, j].soHuu);
                            }
                        }
                    }
                }
            }
            return cell;
        }
        #endregion


        #region Chiến thuật Tấn công
        private long attack_Doc(int curr_Row, int curr_Column)
        {
            long Sum = 0;
            long PointTemp = 0;
            int QuanTa = 0;
            int QuanDich = 0;
            for (int count = 1; count < 6 && curr_Row + count < board.nRows; count++)
            {
                if (cellArray[curr_Row + count, curr_Column].soHuu == 1)        // quân của máy đánh ra
                    QuanTa++;
                else
                    if (cellArray[curr_Row + count, curr_Column].soHuu == 2)       // quân ta đánh
                    {
                        QuanDich++;
                        PointTemp -= arr_attack[1];
                        break;
                    }
                    else    // gặp những ô trống thì thoát không xét
                        break;
            }

            for (int count = 1; count < 6 && curr_Row - count >= 0; count++)
            {
                if (cellArray[curr_Row - count, curr_Column].soHuu == 1)        // quân của máy đánh ra
                    QuanTa++;
                else
                    if (cellArray[curr_Row - count, curr_Column].soHuu == 2)    // quân ta đánh
                    {
                        QuanDich++;
                        PointTemp -= arr_attack[1];
                        break;
                    }
                    else            // gặp những ô trống thì thoát không xét
                        break;
            }

            // bị chặn 2 đầu
            if (QuanDich == 2)
                return 0;

            Sum += arr_attack[QuanTa];
            Sum -= arr_attack[QuanDich];
            PointTemp += Sum;

            return PointTemp;
        }

        private long attack_Ngang(int curr_Row, int curr_Column)
        {
            long Sum = 0;
            long PointTemp = 0;
            int QuanTa = 0;
            int QuanDich = 0;
            for (int count = 1; count < 6 && curr_Column + count < board.nColumns; count++)
            {
                if (cellArray[curr_Row, curr_Column + count].soHuu == 1)        // quân của máy đánh ra
                    QuanTa++;
                else
                    if (cellArray[curr_Row, curr_Column + count].soHuu == 2)       // quân ta đánh
                    {
                        QuanDich++;
                        PointTemp -= arr_attack[1];
                        break;
                    }
                    else    // gặp những ô trống thì thoát không xét
                        break;
            }


            for (int count = 1; count < 6 && curr_Column - count >= 0; count++)
            {
                if (cellArray[curr_Row, curr_Column - count].soHuu == 1)        // quân của máy đánh ra
                    QuanTa++;
                else
                    if (cellArray[curr_Row, curr_Column - count].soHuu == 2)    // quân ta đánh
                    {
                        QuanDich++;
                        PointTemp -= arr_attack[1];
                        break;
                    }
                    else            // gặp những ô trống thì thoát không xét
                        break;
            }

            // bị chặn 2 đầu
            if (QuanDich == 2)
                return 0;

            Sum += arr_attack[QuanTa];
            Sum -= arr_attack[QuanDich];
            PointTemp += Sum;

            return PointTemp;
        }

        private long attack_CheoLeft(int curr_Row, int curr_Column)
        {
            long Sum = 0;
            long PointTemp = 0;
            int QuanTa = 0;
            int QuanDich = 0;
            for (int count = 1; count < 6 && curr_Column + count < board.nColumns && curr_Row - count >= 0; count++)
            {
                if (cellArray[curr_Row - count, curr_Column + count].soHuu == 1)        // quân của máy đánh ra
                    QuanTa++;
                else
                    if (cellArray[curr_Row - count, curr_Column + count].soHuu == 2)       // quân ta đánh
                    {
                        QuanDich++;
                        PointTemp -= arr_attack[1];
                        break;
                    }
                    else    // gặp những ô trống thì thoát không xét
                        break;
            }


            for (int count = 1; count < 6 && curr_Column - count >= 0 && curr_Row + count < board.nRows; count++)
            {
                if (cellArray[curr_Row + count, curr_Column - count].soHuu == 1)        // quân của máy đánh ra
                    QuanTa++;
                else
                    if (cellArray[curr_Row + count, curr_Column - count].soHuu == 2)    // quân ta đánh 
                    {
                        QuanDich++;
                        PointTemp -= arr_attack[1];
                        break;
                    }
                    else            // gặp những ô trống thì thoát không xét
                        break;
            }

            // bị chặn 2 đầu
            if (QuanDich == 2)
                return 0;

            Sum += arr_attack[QuanTa];
            Sum -= arr_attack[QuanDich];
            PointTemp += Sum;

            return PointTemp;
        }

        private long attack_CheoRight(int curr_Row, int curr_Column)
        {
            long Sum = 0;
            long PointTemp = 0;
            int QuanTa = 0;
            int QuanDich = 0;
            for (int count = 1; count < 6 && curr_Column + count < board.nColumns && curr_Row + count < board.nRows; count++)
            {
                if (cellArray[curr_Row + count, curr_Column + count].soHuu == 1)        // quân của máy đánh ra
                    QuanTa++;
                else
                    if (cellArray[curr_Row + count, curr_Column + count].soHuu == 2)       // quân ta đánh
                    {
                        QuanDich++;
                        PointTemp -= arr_attack[1];
                        break;
                    }
                    else    // gặp những ô trống thì thoát không xét
                        break;
            }


            for (int count = 1; count < 6 && curr_Column - count >= 0 && curr_Row - count >= 0; count++)
            {
                if (cellArray[curr_Row - count, curr_Column - count].soHuu == 1)        // quân của máy đánh ra
                    QuanTa++;
                else
                    if (cellArray[curr_Row - count, curr_Column - count].soHuu == 2)    // quân ta đánh 
                    {
                        QuanDich++;
                        PointTemp -= arr_attack[1];
                        break;
                    }
                    else            // gặp những ô trống thì thoát không xét
                        break;
            }

            // bị chặn 2 đầu
            if (QuanDich == 2)
                return 0;

            Sum += arr_attack[QuanTa];
            Sum -= arr_attack[QuanDich];
            PointTemp += Sum;

            return PointTemp;
        }
        #endregion


        #region Chiến thuật Phòng ngự
        private long defend_Doc(int curr_Row, int curr_Column)
        {
            long Sum = 0;
            long PointTemp = 0;
            int QuanTa = 0;
            int QuanDich = 0;
            for (int count = 1; count < 6 && curr_Row + count < board.nRows; count++)
            {
                if (cellArray[curr_Row + count, curr_Column].soHuu == 1)        // quân của máy đánh ra
                {
                    QuanTa++;
                    break;
                }
                else
                    if (cellArray[curr_Row + count, curr_Column].soHuu == 2)       // quân ta đánh
                        QuanDich++;
                    else    // gặp những ô trống thì thoát không xét
                        break;
            }


            for (int count = 1; count < 6 && curr_Row - count >= 0; count++)
            {
                if (cellArray[curr_Row - count, curr_Column].soHuu == 1)        // quân của máy đánh ra
                {
                    QuanTa++;
                    break;
                }
                else
                    if (cellArray[curr_Row - count, curr_Column].soHuu == 2)    // quân ta đánh
                        QuanDich++;
                    else            // gặp những ô trống thì thoát không xét
                        break;
            }

            // bị chặn 2 đầu
            if (QuanTa == 2)
                return 0;

            Sum += arr_defend[QuanDich];
            if (QuanDich > 0)
                Sum -= arr_attack[QuanTa] * 2;
            PointTemp += Sum;

            return PointTemp;
        }

        private long defend_Ngang(int curr_Row, int curr_Column)
        {
            long Sum = 0;
            long PointTemp = 0;
            int QuanTa = 0;
            int QuanDich = 0;
            for (int count = 1; count < 6 && curr_Column + count < board.nColumns; count++)
            {
                if (cellArray[curr_Row, curr_Column + count].soHuu == 1)        // quân của máy đánh ra
                {
                    QuanTa++;
                    break;
                }
                else
                    if (cellArray[curr_Row, curr_Column + count].soHuu == 2)       // quân ta đánh
                        QuanDich++;
                    else    // gặp những ô trống thì thoát không xét
                        break;
            }


            for (int count = 1; count < 6 && curr_Column - count >= 0; count++)
            {
                if (cellArray[curr_Row, curr_Column - count].soHuu == 1)        // quân của máy đánh ra
                {
                    QuanTa++;
                    break;
                }
                else
                    if (cellArray[curr_Row, curr_Column - count].soHuu == 2)    // quân ta đánh
                        QuanDich++;
                    else            // gặp những ô trống thì thoát không xét
                        break;
            }

            // bị chặn 2 đầu
            if (QuanTa == 2)
                return 0;

            Sum += arr_defend[QuanDich];
            if (QuanDich > 0)
                Sum -= arr_attack[QuanTa] * 2;
            PointTemp += Sum;


            return PointTemp;
        }

        // Chéo ngược
        private long defend_CheoLeft(int curr_Row, int curr_Column)
        {
            long Sum = 0;
            long PointTemp = 0;
            int QuanTa = 0;
            int QuanDich = 0;
            for (int count = 1; count < 6 && curr_Column + count < board.nColumns && curr_Row - count >= 0; count++)
            {
                if (cellArray[curr_Row - count, curr_Column + count].soHuu == 1)        // quân của máy đánh ra
                {
                    QuanTa++;
                    break;
                }
                else
                    if (cellArray[curr_Row - count, curr_Column + count].soHuu == 2)       // quân ta đánh
                        QuanDich++;
                    else    // gặp những ô trống thì thoát không xét
                        break;
            }


            for (int count = 1; count < 6 && curr_Column - count >= 0 && curr_Row + count < board.nRows; count++)
            {
                if (cellArray[curr_Row + count, curr_Column - count].soHuu == 1)        // quân của máy đánh ra
                {
                    QuanTa++;
                    break;
                }
                else
                    if (cellArray[curr_Row + count, curr_Column - count].soHuu == 2)    // quân ta đánh 
                        QuanDich++;
                    else            // gặp những ô trống thì thoát không xét
                        break;
            }

            // bị chặn 2 đầu
            if (QuanTa == 2)
                return 0;

            Sum += arr_defend[QuanDich];
            if (QuanDich > 0)
                Sum -= arr_attack[QuanTa] * 2;
            PointTemp += Sum;

            return PointTemp;
        }

        // chéo xuôi
        private long defend_CheoRight(int curr_Row, int curr_Column)
        {
            long Sum = 0;
            long PointTemp = 0;
            int QuanTa = 0;
            int QuanDich = 0;
            for (int count = 1; count < 6 && curr_Column + count < board.nColumns && curr_Row + count < board.nRows; count++)
            {
                if (cellArray[curr_Row + count, curr_Column + count].soHuu == 1)        // quân của máy đánh ra
                {
                    QuanTa++;
                    break;

                }
                else
                    if (cellArray[curr_Row + count, curr_Column + count].soHuu == 2)       // quân ta đánh
                        QuanDich++;
                    else    // gặp những ô trống thì thoát không xét
                        break;
            }


            for (int count = 1; count < 6 && curr_Column - count >= 0 && curr_Row - count >= 0; count++)
            {
                if (cellArray[curr_Row - count, curr_Column - count].soHuu == 1)        // quân của máy đánh ra
                {
                    QuanTa++;
                    break;
                }
                else
                    if (cellArray[curr_Row - count, curr_Column - count].soHuu == 2)    // quân ta đánh 
                        QuanDich++;
                    else            // gặp những ô trống thì thoát không xét
                        break;
            }

            // bị chặn 2 đầu
            if (QuanTa == 2)
                return 0;

            Sum += arr_defend[QuanDich];
            if (QuanDich > 0)
                Sum -= arr_attack[QuanTa] * 2;
            PointTemp += Sum;

            return PointTemp;
        }
        #endregion

    }
}
