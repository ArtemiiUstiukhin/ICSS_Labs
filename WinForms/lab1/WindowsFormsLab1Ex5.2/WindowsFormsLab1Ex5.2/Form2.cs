using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLab1Ex5._2
{
    public partial class Form2 : Form
    {
        Form1 f2;
 

        public Form2()
        {
            InitializeComponent();
            f2 = new Form1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = new Point(this.Location.X, this.Location.Y);
            f2.Show();
        }
    }
}
