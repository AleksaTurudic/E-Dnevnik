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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void osobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Osoba frm_osoba = new Osoba();
            frm_osoba.Show();
        }

        private void osobaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sifarnik form_Sifarnik = new Sifarnik("Osoba");
            form_Sifarnik.Show();
        }

        private void smeroviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnik form_Sifarnik = new Sifarnik("Smer");
            form_Sifarnik.Show();
        }

        private void skolskeGodineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnik form_Sifarnik = new Sifarnik("skolska_godina");
            form_Sifarnik.Show();
        }

        private void predmetiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnik form_Sifarnik = new Sifarnik("Predmet");
            form_Sifarnik.Show();
        }

        private void raspodelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            raspodela frm_Raspodela = new raspodela();
            frm_Raspodela.Show();
        }
    }
}
