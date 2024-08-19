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
    public partial class ViewSuppliers : Form
    {
        public ViewSuppliers()
        {
            InitializeComponent();
            DisplaySup();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            
        }

        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\User\Documents\POSdb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        private void DisplaySup()
        {
            Con.Open();
            String Query = "Select * from SupplierTB";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Buider = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SuppliersDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void Reset()
        {
            SNameTb.Text = "";
            SPhoneTb.Text = "";
            SAddressTb.Text = "";
            SRemarks.Text = "";
            Key = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MBox.Show("Select the Supplier");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from SupplierTB where SupId=@SKey", Con);
                    cmd.Parameters.AddWithValue("@SKey", Key);

                    cmd.ExecuteNonQuery();
                    MBox.Show("Supplier Deleted");
                    Con.Close();
                    DisplaySup();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void SuppliersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SNameTb.Text = (SuppliersDGV.SelectedRows[0].Cells[1].Value).ToString();
            SAddressTb.Text = SuppliersDGV.SelectedRows[0].Cells[2].Value.ToString();
            SPhoneTb.Text = SuppliersDGV.SelectedRows[0].Cells[3].Value.ToString();
            SRemarks.Text = SuppliersDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (SNameTb.Text == " ")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SuppliersDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void ViewSuppliers_Load(object sender, EventArgs e)
        {

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "" || SAddressTb.Text == "" || SPhoneTb.Text == "" || SRemarks.Text == "")
            {
                MBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update SupplierTB set SupName=@SN,SupAddress=@SA,SupPhone=@SP,SupRem=@SR where SupId=@SKey", Con);
                    cmd.Parameters.AddWithValue("@SN", SNameTb.Text);
                    cmd.Parameters.AddWithValue("@SA", SAddressTb.Text);
                    cmd.Parameters.AddWithValue("@SP", SPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@SR", SRemarks.Text);
                    cmd.Parameters.AddWithValue("@SKey",Key);
                    cmd.ExecuteNonQuery();
                    MBox.Show("Supplier Updated");
                    Con.Close();
                    DisplaySup();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MainMenu Obj = new MainMenu();
            Obj.Show();
            this.Hide();
        }
    }
}
