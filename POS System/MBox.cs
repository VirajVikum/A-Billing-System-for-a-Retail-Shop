using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS_System
{
    public partial class MBox : Form
    {
        public MBox()
        {
            InitializeComponent();
            MessageLbl.Text = Message;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
        static string Message;
        public static void Show(string msg)
        {
            Message = msg;
            MBox Obj = new MBox();
            Obj.Show();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void MessageLbl_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
