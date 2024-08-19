using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS_System
{
    public partial class Addproducts : Form
    {
        public Addproducts()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\User\Documents\POSdb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        private void Reset()
        {
            PnameTb.Text = "";
            PriceTb.Text = "";
            QtyTb.Text = "";
            PcatCb.SelectedIndex = -1;

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PnameTb.Text == "" || PcatCb.SelectedIndex == -1 || PriceTb.Text == "" || QtyTb.Text == "")
            {
                MBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ProductTbl(Pname,Pcat,Pprice,PQty)values(@PN,@PC,@PP,@PQ)", Con);
                    cmd.Parameters.AddWithValue("@PN", PnameTb.Text);
                    cmd.Parameters.AddWithValue("@PC", PcatCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PP", PriceTb.Text);
                    cmd.Parameters.AddWithValue("@PQ", QtyTb.Text);
                    cmd.ExecuteNonQuery();
                    MBox.Show("Product Saved");
                    Con.Close();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MBox.Show(Ex.Message);
                }
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
            /*PnameTb.Text = "";
            PriceTb.Text = "";
            QtyTb.Text = "";
            PcatCb.SelectedIndex = -1;*/
        }

        private void Addproducts_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
