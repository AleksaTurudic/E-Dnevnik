using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Dnevnik
{
    public partial class Glavna2 : Form
    {
        public Glavna2()
        {
            InitializeComponent();
        }

        private void raspodelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            raspodela frm_raspodela = new raspodela();
            frm_raspodela.Show();
        }

        private void oceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void osobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Osoba frm_osoba = new Osoba();
            frm_osoba.Show();
        }

        private void smeroviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnik frm_smerovi = new Sifarnik("Smer");
            frm_smerovi.Show();
        }

        private void skolskeGodineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnik frm_skg = new Sifarnik("Skolska_godina");
            frm_skg.Show();
        }

        private void predmetiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnik frm_predmet = new Sifarnik("Predmet");
            frm_predmet.Show();
        }

        private void upisnicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Upisnica frm_upisnica = new Upisnica();
            frm_upisnica.Show();
        }

        private void Glavna2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
