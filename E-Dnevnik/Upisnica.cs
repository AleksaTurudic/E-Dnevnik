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
    public partial class Upisnica : Form
    {
        DataTable dt_upis;
        public Upisnica()
        {
            InitializeComponent();
        }
        private void cmbgod_populate()
        {
            SqlConnection veza = Connection.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from skolska_godina",veza);
            DataTable dt_godina = new DataTable();
            adapter.Fill(dt_godina);
            skolska_godina.DataSource = dt_godina;
            skolska_godina.DisplayMember = "naziv";
            skolska_godina.ValueMember = "id";
            skolska_godina.SelectedValue = 2;
        }
        
        private void cmbodeljenje_populate()
        {
            string godina = skolska_godina.SelectedValue.ToString();
            SqlConnection veza = Connection.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter($"Select id, str(razred) + '-' +indeks AS naziv from Odeljenje where godina_id={godina}", veza);
            DataTable dt_odeljenje = new DataTable();
            adapter.Fill(dt_odeljenje);
            odeljenje.DataSource = dt_odeljenje;
            odeljenje.DisplayMember = "naziv";
            odeljenje.ValueMember = "id";
            odeljenje.SelectedValue = -1;
        }
        private void cmbucenik_populate()
        {
            string godina = skolska_godina.SelectedValue.ToString();
            SqlConnection veza = Connection.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("Select id, ime + '' + prezime AS naziv from Osoba where uloga=1", veza);
            DataTable dt_ucenik = new DataTable();
            adapter.Fill(dt_ucenik);
            ucenik.DataSource = dt_ucenik;
            ucenik.DisplayMember = "naziv";
            ucenik.ValueMember = "id";
            ucenik.SelectedValue = -1;
        }
        private void grid_pop()
        {
            SqlConnection veza = Connection.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter($"Select upisnica.id as id, ime + '' + prezime as naziv, osoba.id as ucenik from upisnica join osoba on osoba_id=osoba.id where odeljenje_id={odeljenje.SelectedValue.ToString()}", veza);
            dt_upis = new DataTable();
            adapter.Fill(dt_upis);
            dataGridView1.DataSource = dt_upis;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["Ucenik"].Visible = false;

        }
       
        private void Upisnica_Load(object sender, EventArgs e)
        {
            cmbgod_populate();
            cmbodeljenje_populate();
            ucenik.Enabled = false;
            upisnica_id.Enabled = false;
        }

        private void skolska_godina_SelectedValueChanged(object sender, EventArgs e)
        {
            if(skolska_godina.IsHandleCreated && skolska_godina.Focused)
            {
                cmbodeljenje_populate();
                odeljenje.SelectedValue = -1;
                while (dataGridView1.Rows.Count>0)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
                }
                ucenik.SelectedValue = -1;
                upisnica_id.Text = "";
                ucenik.Enabled = false;
            }           
        }
        private void odeljenje_SelectedValueChanged(object sender, EventArgs e)
        {
            if (odeljenje.IsHandleCreated && odeljenje.Focused)
            {
                cmbucenik_populate();
                ucenik.Enabled = true;
                grid_pop();
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {            
            if (dataGridView1.CurrentRow != null)
            {
                int t = dataGridView1.CurrentRow.Index;
                if (dt_upis.Rows.Count != 0 && t >= 0)
                {
                    ucenik.SelectedValue = dataGridView1.Rows[t].Cells["ucenik"].Value.ToString();
                    upisnica_id.Text= dataGridView1.Rows[t].Cells["id"].Value.ToString();
                }
            }
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            string naredba = $"Insert into upisnica (odeljenje_id,osoba_id) values('{odeljenje.SelectedValue.ToString()}','{ucenik.SelectedValue.ToString()}')";
            SqlConnection veza = Connection.Connect();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
                grid_pop();
            }
            catch(Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }
         
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string naredba = $"update upisnica set osoba_id='{ucenik.SelectedValue.ToString()}', " +
                $"odeljenje_id={odeljenje.SelectedValue.ToString()} where id={upisnica_id.Text}";
            SqlConnection veza = Connection.Connect();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
                grid_pop();
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string naredba = "delete from upisnica where id=" + upisnica_id.Text;
            SqlConnection veza = Connection.Connect();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
                grid_pop();
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }
        }
    }
}
