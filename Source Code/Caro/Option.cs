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
    public partial class NewGame : Form
    {
        public NewGame()
        {
            InitializeComponent();
            mode = 2;
            level = 2;
            who = 1;
        }

        static NewGame MsgBox;
        static DialogResult result = DialogResult.No;

        public static int mode;
        
        public static string mode1;
        public static string mode2;
        public static string mode3;
        public static string mode4;

        public static int level;    // mức độ chơi
        public static int who;

        public static DialogResult Show()
        {
            MsgBox = new NewGame();
            MsgBox.label1.Text = "Vui lòng chọn một trong 2 chế độ chơi";
            MsgBox.btn_Cancel.Text = "Cancel";

            MsgBox.ShowDialog();
            return result;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            result = DialogResult.No;
            MsgBox.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mode1 = MsgBox.textBox1.Text;       // Player 1 Name
            mode2 = MsgBox.textBox2.Text;       // Player 2 Name

            // máy đánh trước
            if (who == 1)
            {
                mode3 = MsgBox.textBox3.Text;       // Your Name

                MsgBox.textBox4.Text = "Computer";  // PC Name
                mode4 = MsgBox.textBox4.Text;
            }

            // người đánh trước
            else
            {
                mode4 = MsgBox.textBox3.Text;       // Your Name

                MsgBox.textBox4.Text = "Computer";  // PC Name
                mode3 = MsgBox.textBox4.Text;
            }
            
            result = DialogResult.OK;
        }

        private void radio_PvsP_CheckedChanged(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            mode = 1;
           
        }

        private void radio_PvsC_CheckedChanged(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            mode = 2;
        }


        private void Easy_Dlg_CheckedChanged(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            level = 1;
        }

        private void Medium_Dlg_CheckedChanged(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            level = 2;
        }

        private void Hard_Dlg_CheckedChanged(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            level = 3;
        }

        private void Com_CheckedChanged(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            who = 1;
        }

        private void You_CheckedChanged(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            who = 2;
        }
    }
}
