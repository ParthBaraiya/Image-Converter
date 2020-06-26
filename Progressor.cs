using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageConverter
{
    public partial class Progressor : Form
    {
        private string[] files;
        private string opDir;
        private string ext;
        private Form parent;
        public Progressor()
        {
            InitializeComponent();
        }

        public void setValues(string []files, string opDir, string ext, Form parent)
        {
            this.files = files;
            this.opDir = opDir;
            this.ext = ext;
            this.parent = parent;
        }

        private void Progressor_Load(object sender, EventArgs e)
        {
            int total_files = files.Length;
            progressIndecator.Maximum = total_files;
            Converter c = new Converter();
            for (int i=0; i< total_files;i++)
            {
                fileCounter.Text = "Converting File "+i+"Of File(s)" + total_files;
                c.Convert(this.files[i], this.opDir, this.ext);
                progressIndecator.Value++;
            }

            parent.Show();
            this.Close();
        }
    }
}
