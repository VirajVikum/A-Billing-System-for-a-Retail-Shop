using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_System
{
    public partial class ViewProducts : Form
    {
        public ViewProducts()
        {
            InitializeComponent();
            DisplayProducts();
        }

        private void label10_Click(object sender, EventArgs e)
        {


        }

        private void label14_Click(object sender, EventArgs e)
        {
            MainMenu Obj = new MainMenu();
            Obj.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\User\Documents\POSdb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        private void DisplayProducts()
        {
            Con.Open();
            String Query = "Select * from ProductTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Buider = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductsDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MBox.Show("Select the Product");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ProductTbl where PID=@PKey", Con);
                    cmd.Parameters.AddWithValue("@PKey", Key);

                    cmd.ExecuteNonQuery();
                    MBox.Show("Product Deleted");
                    Con.Close();
                    DisplayProducts();
                     Reset();
                }
                catch (Exception Ex)
                {
                    MBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void ProductsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PnameTb.Text = (ProductsDGV.SelectedRows[0].Cells[1].Value).ToString();
            PcatCb.SelectedItem = ProductsDGV.SelectedRows[0].Cells[2].Value.ToString();
            PriceTb.Text = ProductsDGV.SelectedRows[0].Cells[3].Value.ToString();
            QtyTb.Text = ProductsDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (PnameTb.Text == " ")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ProductsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void ViewProducts_Load(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            PnameTb.Text = "";
            PriceTb.Text = "";
            QtyTb.Text = "";
            PcatCb.SelectedIndex = -1;
            Key = 0;
        }
        private void button2_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("Update ProductTbl set Pname=@PN,Pcat=@PC,Pprice=@PP,PQty=@PQ where PId=@PKey", Con);
                    cmd.Parameters.AddWithValue("@PN", PnameTb.Text);
                    cmd.Parameters.AddWithValue("@PC", PcatCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PP", PriceTb.Text);
                    cmd.Parameters.AddWithValue("@PQ", QtyTb.Text);
                    cmd.Parameters.AddWithValue("@PKey", Key);


                    cmd.ExecuteNonQuery();
                    MBox.Show("Product Updated");
                    Con.Close();
                    DisplayProducts();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MainMenu Obj = new MainMenu();
            Obj.Show();
            this.Hide();
        }
    }
}
