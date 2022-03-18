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
    public partial class Osoba : Form
    {
        int t = 0;
        DataTable Tabela;
        public Osoba()
        {
            InitializeComponent();
        }
        private void load_data()
        {
            SqlConnection veza = Connection.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM OSOBA", veza);
            Tabela = new DataTable();
            adapter.Fill(Tabela);
        }
        private void Ispuni_tabelu()
        {
            if (t == -1)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                levo.Enabled = false;
                desno.Enabled = false;
                kraj.Enabled = false;
                pocetak.Enabled = false;
            }
            else
            {
                textBox1.Text = Tabela.Rows[t]["id"].ToString();
                textBox2.Text = Tabela.Rows[t]["ime"].ToString();
                textBox3.Text = Tabela.Rows[t]["prezime"].ToString();
                textBox4.Text = Tabela.Rows[t]["adresa"].ToString();
                textBox5.Text = Tabela.Rows[t]["jmbg"].ToString();
                textBox6.Text = Tabela.Rows[t]["email"].ToString();
                textBox7.Text = Tabela.Rows[t]["pass"].ToString();
                textBox8.Text = Tabela.Rows[t]["uloga"].ToString();
            }
            if (t==0)
            {
                levo.Enabled = false;
                pocetak.Enabled = false;
                desno.Enabled = true;
                kraj.Enabled = true;
            }
            else if(t==Tabela.Rows.Count-1)
            {
                levo.Enabled = true;
                pocetak.Enabled = true;
                desno.Enabled = false;
                kraj.Enabled = false;
            }
            else
            {
                desno.Enabled = true;
                kraj.Enabled = true;
                levo.Enabled = true;
                pocetak.Enabled = true;
            }
        }

        private void Osoba_Load(object sender, EventArgs e)
        {
            load_data();
            Ispuni_tabelu();
        }

        private void desno_Click(object sender, EventArgs e)
        {
            t++;
            Ispuni_tabelu();
        }

        private void levo_Click(object sender, EventArgs e)
        {
            t--;
            Ispuni_tabelu();
        }

        private void pocetak_Click(object sender, EventArgs e)
        {
            t = 0;
            Ispuni_tabelu();
        }

        private void kraj_Click(object sender, EventArgs e)
        {
            t = Tabela.Rows.Count - 1;
            Ispuni_tabelu();
        }

        private void add_Click(object sender, EventArgs e)
        {
            string naredba = $"Insert into Osoba (ime,prezime,adresa,jmbg,email,pass,uloga) " +
                $"values ('{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{textBox7.Text}','{textBox8.Text}' )";
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
            load_data();
            Ispuni_tabelu();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string naredba = "Delete from osoba where id=" + textBox1.Text;
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
            t--;
            load_data();
            Ispuni_tabelu();
        }

        private void alter_Click(object sender, EventArgs e)
        {
            string naredba = $"Update osoba set ime='{textBox2.Text}'," +
                $"prezime='{textBox3.Text}',adresa='{textBox4.Text}'," +
                $"jmbg='{textBox5.Text}',email='{textBox6.Text}'," +
                $"pass='{textBox7.Text}',uloga='{textBox8.Text}'" +
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
            load_data();
            Ispuni_tabelu();
        }
    }
}
