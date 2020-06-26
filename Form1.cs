using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace ImageConverter
{
    public partial class Form1 : Form
    {
        string[] files;

        private string ext = "";

        private CustomControl cont;

        public Form1()
        {
            InitializeComponent();
        }

        //private void convertButton_Click(object sender, EventArgs e)
        //{
        //    Converter c = new Converter();


        //    string opDirectory = opFileDirectory.Text;

        //    int total_files = files.Length;
        //    ProgressBar pb = new ProgressBar();

        //    pb.Width = 300;
        //    // fileCounter.AutoSize = true;

        //    mainTable.Controls.Add(pb, 0, 5);

        //    pb.Maximum = total_files;
        //    for (int i = 0; i < total_files; i++)
        //    {
        //        // fileCounter.Text = "Converting File " + (i+1).ToString() + " Of File(s)" + total_files.ToString();
        //        pb.Value++;
        //        c.Convert(this.files[i], opDirectory, this.ext);
        //    }

        //    /*for(int i = 0; i < files.Length; i++)
        //    {
        //        c.Convert(files[i], opDirectory, ext);
        //    }*/
        //}


        private void convertButton_Click(object sender, EventArgs e)
        {
            string opDirectory = opFileDirectory.Text;

            cont = new CustomControl(this.files, opDirectory, this.ext);
            cont.Width = 300;
            mainTable.Controls.Add(cont, 0, 5);
            cont.ConvertComplete += new EventHandler(onConversionComplete);
            cont.ConvertFiles();
        }

        private void onConversionComplete(object sender, EventArgs e)
        {
            MessageBox.Show("ConversionComplete");
            mainTable.Controls.Remove(cont);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Extensions.Extension.Length; i++)
                extensionList.Items.Add(Extensions.Extension[i]);
            
            extensionList.SelectedIndex = 0;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            // Initialize openFile Dialoug Box
            OpenFileDialog openFile = new OpenFileDialog();

            // Enable Multiple Select
            openFile.Multiselect = true;

            if(openFile.ShowDialog() == DialogResult.OK)
            {

                // Array of all Selected Files
                this.files = openFile.FileNames;

                // Directory where all seleted files are
                string directory = Path.GetDirectoryName(files[0]);
                inputFileName.Text = directory;

                // Add files to files List
                for(int i=0; i < files.Length; i++)
                    filesList.Text += (i+1).ToString() + ". " + Path.GetFileName(files[i]) + Environment.NewLine;

                // Output Directory
                string opDirectory = Path.Combine(directory, "ConvertedJPG");

                opFileDirectory.Text = opDirectory;

            }
        }

        private void openFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialoug = new FolderBrowserDialog();
            folderDialoug.ShowNewFolderButton = true;
            if(folderDialoug.ShowDialog() == DialogResult.OK)
                opFileDirectory.Text = folderDialoug.SelectedPath;
            
        }

        private void extensionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ext = extensionList.SelectedItem.ToString();
            Console.WriteLine(this.ext);
        }
    }
}
