using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppClinica
{
    public partial class FrmRecordatorio : Form
    {
        public FrmRecordatorio()
        {
            InitializeComponent();
        }

        private void FrmRecordatorio_Load(object sender, EventArgs e)
        {
            pbRecordatorio.Value = 0;
        }

        private void FrmRecordatorio_Activated(object sender, EventArgs e)
        {
            while (pbRecordatorio.Value < 100) {

                pbRecordatorio.Value += 10;
            }
        }
    }
}
