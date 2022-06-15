using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExeCrudWindowsForm
{
    public partial class Barang : Form
    {
        public Barang()
        {
            InitializeComponent();
        }

        private void Barang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'warungDataSet.Daftar_Barang' table. You can move, or remove it, as needed.
            this.daftar_BarangTableAdapter.Fill(this.warungDataSet.Daftar_Barang);

        }
    }
}
