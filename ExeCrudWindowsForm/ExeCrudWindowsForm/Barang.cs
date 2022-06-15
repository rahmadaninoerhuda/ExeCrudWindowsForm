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

namespace ExeCrudWindowsForm
{
    public partial class Barang : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Barang()
        {
            InitializeComponent();
        }

        private void Barang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'warungDataSet.Daftar_Barang' table. You can move, or remove it, as needed.
            this.daftar_BarangTableAdapter.Fill(this.warungDataSet.Daftar_Barang);
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            cmdSave.Enabled = false;

        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            cmdSave.Enabled = true;
            textBox2.Text = "";
            textBox2.Text = "";
            int ctr, len;
            string codeval;
            dt = warungDataSet.Tables["Daftar_Barang"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["Kode_Barang"].ToString();
            codeval = code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if ((ctr >= 1) && (ctr < 9))
            {
                ctr = ctr + 1;
                textBox1.Text = "C00" + ctr;
            }

            else if ((ctr >= 9) && (ctr < 99))
            {
                ctr = ctr + 1;
                textBox1.Text = "C0" + ctr;
            }

            else if (ctr >= 99)
            {
                {
                    ctr = ctr + 1;
                    textBox1.Text = "C" + ctr;
                }

            }

            cmdAdd.Enabled = false;

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            dt = warungDataSet.Tables["Daftar_Barang"];
            dr = dt.NewRow();
            dr[0] = textBox1.Text;
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            dt.Rows.Add(dr);
            daftar_BarangTableAdapter.Update(warungDataSet);
            textBox1.Text = System.Convert.ToString(dr[0]);
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            this.daftar_BarangTableAdapter.Fill(this.warungDataSet.Daftar_Barang);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = true;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = textBox1.Text;
            dr = warungDataSet.Tables["Daftar_Barang"].Rows.Find(code);
            dr.Delete();
            daftar_BarangTableAdapter.Update(warungDataSet);
        }
    }
}
