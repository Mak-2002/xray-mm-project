using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XRayImageProcessor
{
    public partial class IntroductionForm : Form
    {
        public IntroductionForm()
        {
            InitializeComponent();
        }

        private void BtnOpenMainForm_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            mainForm.Show();
        }

        private void BtnOpenCompareForm_Click(object sender, EventArgs e)
        {
            CompareForm compareForm = new CompareForm();
            compareForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            compareForm.Show();
        }
    }
}
