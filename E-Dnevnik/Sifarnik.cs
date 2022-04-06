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
    public partial class Sifarnik : Form
    {
        string ime_tabele;
        SqlDataAdapter adapter;
        DataTable podaci = new DataTable();
        public Sifarnik( string tabela)
        {
            ime_tabele = tabela;
            InitializeComponent();
        }

        private void Sifarnik_Load(object sender, EventArgs e)
        {
            SqlConnection veza = Connection.Connect();
            SqlCommand komanda = new SqlCommand($"Select * from {ime_tabele}", veza);
            adapter = new SqlDataAdapter(komanda);
            adapter.Fill(podaci);
            dataGridView1.DataSource = podaci;
            dataGridView1.Columns["id"].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable menjano = podaci.GetChanges();
            adapter.UpdateCommand = new SqlCommandBuilder(adapter).GetUpdateCommand();
            if(menjano!=null)
            {
                adapter.Update(menjano);
            }
            this.Close();
        }
    }
}
