using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void WFSStartUp_Click(object sender, EventArgs e)
        {
            WFSStartUpResult.Text = "Ads";
        }

        private void WFSOpen_Click(object sender, EventArgs e)
        {
            WFSOpenResult.Text = "Ads";
        }

        private void WFSRegister_Click(object sender, EventArgs e)
        {
            WFSRegisterResult.Text = "Ads";
        }
    }
}
