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
    public partial class Ocena : Form
    {
        DataTable dt_grid;
        public Ocena()
        {
            InitializeComponent();
        }

        private void Ocena_Load(object sender, EventArgs e)
        {
            cmb_profesor.Enabled = true;
            cmb_godina_populate();
            cmb_profesor_pop();
            cmb_ocena.Enabled = false;
        }
        private void cmb_godina_populate()
        {
            SqlConnection veza = Connection.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from skolska_godina", veza);
            DataTable dt_godina = new DataTable();
            adapter.Fill(dt_godina);
            cmb_godina.DataSource = dt_godina;
            cmb_godina.DisplayMember = "naziv";
            cmb_godina.ValueMember = "id";
            cmb_godina.SelectedValue = 2;
        }
        private void cmb_profesor_pop()
        {
            SqlConnection veza = Connection.Connect();
            string select = $"select distinct osoba.id as ID, ime + ' ' + prezime as naziv from Osoba " +
                $"join Raspodela ON osoba.id=nastavnik_id where godina_id={cmb_godina.SelectedValue.ToString()}";
            SqlDataAdapter adapter = new SqlDataAdapter(select, veza);
            DataTable dt_profesor = new DataTable();
            adapter.Fill(dt_profesor);
            cmb_profesor.DataSource = dt_profesor;
            cmb_profesor.DisplayMember = "naziv";
            cmb_profesor.ValueMember = "id";
            cmb_profesor.SelectedValue = -1;
        }

        private void cmb_godina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_godina.IsHandleCreated && cmb_godina.Focused)
            {
                cmb_profesor_pop();
            }
        }

        private void cmb_profesor_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_profesor.IsHandleCreated && cmb_profesor.Focused)
            {
                cmb_predmet.Enabled = true;
                cmb_predmet_pop();
                cmb_odeljenje.Enabled = false;
                cmb_odeljenje.SelectedIndex = -1;

                cmb_ucenik.Enabled = false;
                cmb_ucenik.SelectedIndex = -1;

                cmb_ocena.SelectedIndex = -1;
                cmb_ocena.Enabled = false;

                dt_grid = new DataTable();
                Grid1.DataSource = dt_grid;
            }
        }
        private void cmb_predmet_pop()
        {
            SqlConnection veza = Connection.Connect();
            string naredba = $"Select distinct predmet.id as id, naziv from predmet join raspodela " +
                $"on predmet.id = predmet_id where godina_id={cmb_godina.SelectedValue.ToString()} and " +
                $"nastavnik_id = {cmb_profesor.SelectedValue.ToString()}";
            SqlDataAdapter adapter = new SqlDataAdapter(naredba, veza);
            DataTable dt_predmet = new DataTable();
            adapter.Fill(dt_predmet);
            cmb_predmet.DataSource = dt_predmet;
            cmb_predmet.ValueMember = "id";
            cmb_predmet.DisplayMember = "naziv";
            cmb_predmet.SelectedIndex = -1;

        }

        private void cmb_predmet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_predmet.IsHandleCreated && cmb_predmet.Focused)
            {
                cmb_odeljenje_pop();
                cmb_odeljenje.Enabled = true;

                cmb_ucenik.Enabled = false;
                cmb_ucenik.SelectedIndex = -1;

                cmb_ocena.SelectedIndex = -1;
                cmb_ocena.Enabled = false;

                dt_grid = new DataTable();
                Grid1.DataSource = dt_grid;
            }
        }
        private void cmb_odeljenje_pop()
        {
            SqlConnection veza = Connection.Connect();
            string naredba = $"Select distinct odeljenje.id as id, str(razred) + '-' + indeks as naziv from odeljenje " +
                $"join raspodela on odeljenje.id=odeljenje_id " +
                $"where raspodela.godina_id={cmb_godina.SelectedValue.ToString()} and " +
                $"nastavnik_id = {cmb_profesor.SelectedValue.ToString()} and " +
                $"predmet_id = {cmb_predmet.SelectedValue.ToString()}";
            SqlDataAdapter adapter = new SqlDataAdapter(naredba, veza);
            DataTable dt_odeljenje = new DataTable();
            adapter.Fill(dt_odeljenje);
            cmb_odeljenje.DataSource = dt_odeljenje;
            cmb_odeljenje.DisplayMember = "naziv";
            cmb_odeljenje.ValueMember = "id";
            cmb_odeljenje.SelectedIndex = -1;
        }

        private void cmb_odeljenje_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_odeljenje.IsHandleCreated && cmb_odeljenje.Focused)
            {
                cmb_ucenik.Enabled = true;
                cmb_ucenik_pop();
                grid_pop();
                UcenikOcenaId_pop(0);
                cmb_ocena.Enabled = true;
            }

        }
        private void cmb_ucenik_pop()
        {
            SqlConnection veza = Connection.Connect();
            string naredba = $"select osoba.id as id, ime + ' ' + prezime as naziv from osoba " +
                $"join upisnica on osoba.id=osoba_id" +
                $" where upisnica.odeljenje_id={cmb_odeljenje.SelectedValue.ToString()}";

            SqlDataAdapter adapter = new SqlDataAdapter(naredba, veza);
            DataTable dt_ucenik = new DataTable();
            adapter.Fill(dt_ucenik);
            cmb_ucenik.DataSource = dt_ucenik;
            cmb_ucenik.DisplayMember = "naziv";
            cmb_ucenik.ValueMember = "id";
            cmb_ucenik.SelectedIndex = -1;
        }
        private void grid_pop()
        {
            string naredba = $"select ocena.id as id, ime + ' ' + prezime as naziv, ocena, ucenik_id, datum from " +
                $"osoba join ocena on osoba.id=ucenik_id " +
                $"join raspodela on raspodela_id=raspodela.id " +
                $"where raspodela_id = (select id from raspodela where " +
                $"godina_id={cmb_godina.SelectedValue.ToString()} and " +
                $"nastavnik_id={cmb_profesor.SelectedValue.ToString()} and" +
                $" predmet_id={cmb_predmet.SelectedValue.ToString()} and " +
                $" odeljenje_id={cmb_odeljenje.SelectedValue.ToString()} )" +
                $" and uloga=1";
            SqlConnection veza = Connection.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(naredba, veza);
            dt_grid = new DataTable();
            adapter.Fill(dt_grid);
            Grid1.DataSource = dt_grid;
            Grid1.AllowUserToAddRows = false;
            Grid1.Columns["ucenik_id"].Visible = false;
        }

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UcenikOcenaId_pop(e.RowIndex);
            }
        }
        private void UcenikOcenaId_pop(int t)
        {
            cmb_ucenik.SelectedValue = dt_grid.Rows[t]["ucenik_id"];
            cmb_ocena.SelectedIndex = int.Parse(dt_grid.Rows[t]["ocena"].ToString()) - 1;
            textBox2.Text = dt_grid.Rows[t]["id"].ToString();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            string naredba = $"select id from raspodela where " +
                $"godina_id={cmb_godina.SelectedValue.ToString()} and " +
                $"nastavnik_id={cmb_profesor.SelectedValue.ToString()} and " +
                $"predmet_id={cmb_predmet.SelectedValue.ToString()} and " +
                $"odeljenje_id={cmb_odeljenje.SelectedValue.ToString()}";
            SqlConnection veza = Connection.Connect();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            int id_raspodele = 0;            
            try
            {
                veza.Open();
                id_raspodele = (int)komanda.ExecuteScalar();
                veza.Close();
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.Message);
            }
            if (id_raspodele > 0)
            {
                DateTime datum = Datum.Value;
                string nova_naredba = $"insert into ocena (datum,raspodela_id,ucenik_id,ocena)" +
                    $" values('{datum.ToString("yyyy-MM-dd")}','{id_raspodele.ToString()}'," +
                    $"'{cmb_ucenik.SelectedValue.ToString()}','{cmb_ocena.SelectedItem.ToString()}')";
                komanda = new SqlCommand(nova_naredba, veza);
                
                  try
                  {
                      veza.Open();
                      komanda.ExecuteNonQuery();
                      veza.Close();
                  }
                  catch (Exception greska)
                  {
                      MessageBox.Show(greska.Message);
                  }
              }
              grid_pop();
          }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(textBox2.Text) >0)
            {
                DateTime datum = Datum.Value;
                string naredba = $"update ocena set " +
                    $"ucenik_id = '{cmb_ucenik.SelectedValue.ToString()}', " +
                    $"ocena = '{cmb_ocena.SelectedItem.ToString()}', " +
                    $"datum = '{datum.ToString("yyyy-MM-dd")}' " +
                    $"where id={textBox2.Text}";
                SqlConnection veza = Connection.Connect();
                SqlCommand Komanda = new SqlCommand(naredba, veza);
                try
                {
                    veza.Open();
                    Komanda.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception greska)
                {
                    MessageBox.Show(greska.Message);
                }

            }
            grid_pop();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox2.Text) > 0)
            {
                string naredba = $"delete from ocena where id={textBox2.Text}";
                SqlConnection veza = Connection.Connect();
                SqlCommand Komanda = new SqlCommand(naredba, veza);
                try
                {
                    veza.Open();
                    Komanda.ExecuteNonQuery();
                    veza.Close();
                    grid_pop();
                    UcenikOcenaId_pop(0);
                }
                catch (Exception greska)
                {
                    MessageBox.Show(greska.Message);
                }
            }
            
        }
    }
}
    
