using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Giao_Dien
{
    partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        static About MsgBox;
        static DialogResult result = DialogResult.No;

        public static DialogResult Show()
        {
            MsgBox = new About();
            MsgBox.ShowDialog();
            return result;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            MsgBox.Close();
        }
    }
}
