using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Crystale_Report
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void getStagaire()
        {
            DataSet1 ds = new DataSet1();
            DataSet1TableAdapters.StagiaireTableAdapter stg = new DataSet1TableAdapters.StagiaireTableAdapter();
            stg.Fill(ds.Stagiaire);
            CrystaleAffiche CR = new CrystaleAffiche();
            CR.SetDataSource(ds);
            crystalReportViewer1.ReportSource = CR;
        }
        void getBayCin()
        {
            DataSet1 ds = new DataSet1();
            DataSet1TableAdapters.Stagiaire1TableAdapter stag = new DataSet1TableAdapters.Stagiaire1TableAdapter();
            stag.Fill(ds.Stagiaire1, textRechercher.Text);
            CrystalRecherchCin rech = new CrystalRecherchCin();
            rech.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rech;
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            if (textRechercher.Text != "")
            {
                DataSet1 ds = new DataSet1();
                DataSet1TableAdapters.Stagiaire1TableAdapter stag = new DataSet1TableAdapters.Stagiaire1TableAdapter();
                stag.Fill(ds.Stagiaire1, textRechercher.Text);
                dataGridView1.DataSource = ds.Tables["Stagiaire1"];
            }
            else
            {

                DataSet1 ds = new DataSet1();
                DataSet1TableAdapters.StagiaireTableAdapter stg = new DataSet1TableAdapters.StagiaireTableAdapter();
                stg.Fill(ds.Stagiaire);
                dataGridView1.DataSource = ds.Tables["Stagiaire"];
            }
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            if (textRechercher.Text != "")
            {
                getBayCin();
            }
            else
            {
                getStagaire();
            }
        }
    }
}
