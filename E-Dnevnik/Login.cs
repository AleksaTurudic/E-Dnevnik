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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text=="")
            {
                MessageBox.Show("unesite mejl i sifru");
                return;
            }
            else
            {
                try
                {
                    SqlConnection veza = Connection.Connect();
                    SqlCommand komanda = new SqlCommand($"Select * from osoba where email='{textBox1.Text}'",veza);
                    SqlDataAdapter adapter = new SqlDataAdapter(komanda);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    int t = tabela.Rows.Count;
                    if(t==1)
                    {
                        if (string.Compare(tabela.Rows[0]["pass"].ToString(), textBox2.Text)==0)
                        {
                            MessageBox.Show("Dobrodosli");
                            Form1 frm_main = new Form1();
                            this.Hide();
                            frm_main.Show();                            
                        }
                        else
                        {
                            MessageBox.Show("Pogresna sifra");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nepostojeci mejl");
                        return;
                    }
                }
                catch (Exception greska)
                {
                    MessageBox.Show(greska.Message);
                }
            }
        }
    }
}
