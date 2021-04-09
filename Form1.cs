using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Camera_Rental_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\Documents\CamRentaldb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from camRentalTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentalDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Add_Click(object sender, EventArgs e)
        {

            if (IdTB.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "" || RegNoTb.Text == "" || MerkTb.Text == "" || ModelTb.Text == "" || PriceTb.Text == "" || DaysTb.Text == "" || RentFeeTb.Text == "")
            {
                MessageBox.Show("Informasi belum lengkap");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into camRentalTbl values('" + IdTB.Text + "','" + IdTypeCb.SelectedItem.ToString() + "', '" + NameTb.Text + "', '" + AddressTb.Text + "', '" + PhoneTb.Text + "', " + RegNoTb.Text + ", '" + MerkTb.Text + "','" + ModelTb.Text + "','" + PriceTb.Text + "', '" + DaysTb.Text + "', '" + RentFeeTb.Text +"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Informasi sukses ditambahkan");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
            uCustomer iCustomer = new uCustomer();
            Rental iRental = new Rental();
            uRent iRent = new uRent();

            iRental.thePrice = Double.Parse(PriceTb.Text);
            iRent.theDays = int.Parse(DaysTb.Text);

            String q = String.Format("Rp{0}", iRental.thePrice * iRent.theDays);
            RentFeeTb.Text = q;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            populate();
            IdTypeCb.Items.Add("KTP");
            IdTypeCb.Items.Add("SIM");
            IdTypeCb.Items.Add("Kartu Pelajar");
            IdTypeCb.Items.Add("Passport");
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            if (IdTB.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "" || RegNoTb.Text == "" || MerkTb.Text == "" || ModelTb.Text == "" || PriceTb.Text == "" || DaysTb.Text == "" || RentFeeTb.Text == "")
            {
                MessageBox.Show("Informasi belum lengkap");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update camRentalTbl set ID= '" + IdTB.Text + "', [Id Type]= '" + IdTypeCb.SelectedItem.ToString() + "',Name= '" + NameTb.Text + "',Address= '" + AddressTb.Text + "', Phone= '" + PhoneTb.Text + "', Merk= '" + MerkTb.Text + "',Model= '" + ModelTb.Text + "',Price= '" + PriceTb.Text + "', Days= '" + DaysTb.Text + "', [Rent Fee]= '" + RentFeeTb.Text + "' where RegNo= '" + RegNoTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Informasi sukses diedit");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int rowIndex = RentalDGV.CurrentCell.RowIndex;
            RentalDGV.Rows.RemoveAt(rowIndex);     
        }

        private void RentalDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTB.Text = RentalDGV.CurrentRow.Cells["ID"].Value.ToString();
            NameTb.Text = RentalDGV.CurrentRow.Cells["Name"].Value.ToString();
            AddressTb.Text = RentalDGV.CurrentRow.Cells["Address"].Value.ToString();
            PhoneTb.Text = RentalDGV.CurrentRow.Cells["Phone"].Value.ToString();
            RegNoTb.Text = RentalDGV.CurrentRow.Cells["RegNo"].Value.ToString();
            MerkTb.Text = RentalDGV.CurrentRow.Cells["Merk"].Value.ToString();
            ModelTb.Text = RentalDGV.CurrentRow.Cells["Model"].Value.ToString();
            PriceTb.Text = RentalDGV.CurrentRow.Cells["Price"].Value.ToString();
            DaysTb.Text = RentalDGV.CurrentRow.Cells["Days"].Value.ToString();
            RentFeeTb.Text = RentalDGV.CurrentRow.Cells["Rent Fee"].Value.ToString();
        }
    }
     
    }


