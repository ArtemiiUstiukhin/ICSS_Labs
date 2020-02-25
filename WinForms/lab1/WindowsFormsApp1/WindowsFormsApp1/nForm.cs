using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class nForm : Form
    {
        private bool nclose;

        public nForm()
        {
            InitializeComponent();
        }

        public new void Close()
        {
            nclose = true;
            base.Close();
        }
        private void nForm_Load(object sender, EventArgs e)
        {

        }
    }
}
