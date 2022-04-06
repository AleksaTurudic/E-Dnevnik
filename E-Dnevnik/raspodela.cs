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

namespace E_Dnevnik
{
    public partial class raspodela : Form
    {
        DataTable Raspodela;
        int t = 0;
        public raspodela()
        {
            InitializeComponent();
        }
        private void data_load()
        {
            SqlConnection veza = Connection.Connect();
            SqlCommand komanda = new SqlCommand($"Select * from Raspodela", veza);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            Raspodela = new DataTable();
            adapter.Fill(Raspodela);
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void raspodela_Load(object sender, EventArgs e)
        {
            data_load();
            Combo_fill();
        }
        private void Combo_fill()
        {
            SqlConnection veza = Connection.Connect();
            SqlDataAdapter adapter;
            DataTable dt_godina, dt_profesor, dt_predmet, dt_odeljenje;
            adapter = new SqlDataAdapter("select * from Skolska_godina",veza);
            dt_godina = new DataTable();
            adapter.Fill(dt_godina);

            adapter = new SqlDataAdapter("select id, ime + prezime as naziv from Osoba where uloga=2", veza);
            dt_profesor = new DataTable();
            adapter.Fill(dt_profesor);

            adapter = new SqlDataAdapter("select id, STR(razred) + '-' + indeks as naziv from Odeljenje", veza);
            dt_odeljenje = new DataTable();
            adapter.Fill(dt_odeljenje);

            adapter = new SqlDataAdapter("select id, naziv from Predmet", veza);
            dt_predmet = new DataTable();
            adapter.Fill(dt_predmet);

            comboBox1.DataSource = dt_godina;
            comboBox1.DisplayMember = "naziv";
            comboBox1.ValueMember = "id";
           

            comboBox2.DataSource = dt_profesor;
            comboBox2.DisplayMember = "naziv";
            comboBox2.ValueMember = "id";
    

            comboBox3.DataSource = dt_predmet;
            comboBox3.DisplayMember = "naziv";
            comboBox3.ValueMember = "id";
           

            comboBox4.DataSource = dt_odeljenje;
            comboBox4.DisplayMember = "naziv";
            comboBox4.ValueMember = "id";
            

            textBox1.Text = Raspodela.Rows[t]["id"].ToString();
            if(Raspodela.Rows.Count==0)
            {
                comboBox1.SelectedValue = -1;
                comboBox2.SelectedValue = -1;
                comboBox3.SelectedValue = -1;
                comboBox4.SelectedValue = -1;
            }
            else
                {
                comboBox1.SelectedValue = Raspodela.Rows[t]["godina_id"];
                comboBox2.SelectedValue = Raspodela.Rows[t]["nastavnik_id"];
                comboBox3.SelectedValue = Raspodela.Rows[t]["predmet_id"];
                comboBox4.SelectedValue = Raspodela.Rows[t]["odeljenje_id"];
            }
            if(t==0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            if (t == Raspodela.Rows.Count-1)
            {
                button6.Enabled = false;
                button7.Enabled = false;
            }
            else
            {
                button6.Enabled = true;
                button7.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t = 0;
            Combo_fill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t--;
            Combo_fill();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            t = Raspodela.Rows.Count - 1;
            Combo_fill();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            t++;
            Combo_fill();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string naredba = $"Insert into Raspodela (godina_id, nastavnik_id, predmet_id, odeljenje_id) " +
                $"values ('{comboBox1.SelectedValue}','{comboBox2.SelectedValue}','{comboBox3.SelectedValue}','{comboBox4.SelectedValue}')";
            SqlConnection veza = Connection.Connect();
            SqlCommand adapter = new SqlCommand(naredba, veza);
            try
            {
                veza.Open();
                adapter.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }
            data_load();
            t = Raspodela.Rows.Count - 1;
            Combo_fill();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string naredba = "Delete from Raspodela where id=" + textBox1.Text;
            SqlConnection veza = Connection.Connect();
            SqlCommand adapter = new SqlCommand(naredba, veza);
            Boolean brisano = false; ;
            try
            {
                veza.Open();
                adapter.ExecuteNonQuery();
                veza.Close();
                brisano = true;
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }
            if(brisano)
            {
                data_load();
                if (t > 0) t--;
                Combo_fill();               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string naredba = $"Update Raspodela set godina_id='{comboBox1.SelectedValue}'," +
                $"nastavnik_id='{comboBox2.SelectedValue}',predmet_id='{comboBox3.SelectedValue}'," +
                $"odeljenje_id='{comboBox4.SelectedValue}'" +
                "where id=" + textBox1.Text;
            SqlConnection veza = Connection.Connect();
            SqlCommand adapter = new SqlCommand(naredba, veza);
            try
            {
                veza.Open();
                adapter.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }
            data_load();
            Combo_fill();
        }
    }
}
