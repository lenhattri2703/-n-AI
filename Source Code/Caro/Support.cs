using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Giao_Dien
{
    public partial class Support : Form
    {
        public Support()
        {
            InitializeComponent();
        }

        static Support MsgBox;
        static DialogResult result = DialogResult.No;

        public static DialogResult Show()
        {
            MsgBox = new Support();
            MsgBox.label2.Text =
"•  Hai bên thay phiên nhau đi những nước đi.\n\n•  Bên nào có 5 quân liền nhau trên một hàng, một\n    cột hoặc một đường chéo mà không bị chặn 2\n    đầu thì thắng.\n\n•  Trường hợp bị chặn 2 đầu không thắng.\n\n•  Đánh hết ô cờ mà chưa phân thắng bại thì hòa.";
            MsgBox.ShowDialog();
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            MsgBox.Close();
        }

    }
}
