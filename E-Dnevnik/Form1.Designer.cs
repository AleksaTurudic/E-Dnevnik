
namespace E_Dnevnik
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.jedanBezToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jedanSaFKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.osobaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelaBezToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelaSaFKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izvestajiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jedanBezToolStripMenuItem,
            this.jedanSaFKToolStripMenuItem,
            this.tabelaBezToolStripMenuItem,
            this.tabelaSaFKToolStripMenuItem,
            this.izvestajiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // jedanBezToolStripMenuItem
            // 
            this.jedanBezToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.osobaToolStripMenuItem});
            this.jedanBezToolStripMenuItem.Name = "jedanBezToolStripMenuItem";
            this.jedanBezToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.jedanBezToolStripMenuItem.Text = "Jedan Bez";
            // 
            // jedanSaFKToolStripMenuItem
            // 
            this.jedanSaFKToolStripMenuItem.Name = "jedanSaFKToolStripMenuItem";
            this.jedanSaFKToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.jedanSaFKToolStripMenuItem.Text = "Jedan SaFK";
            // 
            // osobaToolStripMenuItem
            // 
            this.osobaToolStripMenuItem.Name = "osobaToolStripMenuItem";
            this.osobaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.osobaToolStripMenuItem.Text = "Osoba";
            this.osobaToolStripMenuItem.Click += new System.EventHandler(this.osobaToolStripMenuItem_Click);
            // 
            // tabelaBezToolStripMenuItem
            // 
            this.tabelaBezToolStripMenuItem.Name = "tabelaBezToolStripMenuItem";
            this.tabelaBezToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.tabelaBezToolStripMenuItem.Text = "Tabela bez";
            // 
            // tabelaSaFKToolStripMenuItem
            // 
            this.tabelaSaFKToolStripMenuItem.Name = "tabelaSaFKToolStripMenuItem";
            this.tabelaSaFKToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.tabelaSaFKToolStripMenuItem.Text = "Tabela sa FK";
            // 
            // izvestajiToolStripMenuItem
            // 
            this.izvestajiToolStripMenuItem.Name = "izvestajiToolStripMenuItem";
            this.izvestajiToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.izvestajiToolStripMenuItem.Text = "Izvestaji";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jedanBezToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem osobaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jedanSaFKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabelaBezToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabelaSaFKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izvestajiToolStripMenuItem;
    }
}

