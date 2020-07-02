using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace ImageConverter
{
    public partial class CustomControl : UserControl
    {
        private delegate void UpdateUIDeletgate(int index, string fileName);

        private string[] files;
        private string opDirectory;
        private string ext;


        private bool isConverting;
        private bool deferConverting;
        private Thread convertThread;
        private UpdateUIDeletgate updateUIDeletgate;
        private EventHandler onConvertComplete;

        private int fileCounter;

        public event EventHandler ConvertComplete;

        public CustomControl()
        {
            InitializeData();
        }

        public CustomControl(string[] files, string opDirectory, string ext)
        {
            InitializeData();
            this.SetData(files, opDirectory, ext);
        }


        private void InitializeData()
        {
            InitializeComponent();
            updateUIDeletgate = new UpdateUIDeletgate(updateUI);
            this.fileCounter = 0;
            onConvertComplete = new EventHandler(OnConvertComplete);
        }

        public void SetData(string[] files, string opDirectory, string ext)
        {
            this.files = files;
            this.opDirectory = opDirectory;
            this.ext = ext;
            this.progressIndecator.Maximum = files.Length;
        }

        private void updateUI(int index, string fileName)
        {
            this.processText.Text = "Converting file: " + Path.GetFileName(fileName);
            this.progressIndecator.Value = index;
        }



        public void ConvertFiles()
        {
            if (this.isConverting) return;

            if(IsHandleCreated)
            {
                convertThread = new Thread(new ThreadStart(StartConversion));
                isConverting = true;
                convertThread.Start();
            }

            else
            {
                deferConverting = true;
            }
        }

        private void StartConversion()
        {
            try
            {
                Converter converter = new Converter();
                int length = files.Length;
                for (int i = 0; i < length; i++)
                {
                    fileCounter = i + 1;
                    IAsyncResult res = BeginInvoke(updateUIDeletgate, new object[] { fileCounter, files[i]});
                    converter.Convert(this.files[i], this.opDirectory, this.ext);
                }
            }
            finally
            {
                isConverting = false;
                // code That runs once converting is completed.

                // For event
                BeginInvoke(onConvertComplete, new object[]{this, EventArgs.Empty});
            }
        }

        public void StopConversion()
        {
            if (!isConverting) return;
            if (convertThread.IsAlive)
            {
                convertThread.Abort();
                convertThread.Join();
            }
            convertThread = null;
            isConverting = false;
        }

        private void OnConvertComplete(object sender, EventArgs e)
        {
            if (ConvertComplete != null)
            {
                ConvertComplete(sender, e);
            }
        }


        protected override void OnHandleCreated(EventArgs e)
        {   
            base.OnHandleCreated(e);
            if (deferConverting)
            {
                deferConverting = false;
                ConvertFiles();
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (!RecreatingHandle) StopConversion();
            base.OnHandleDestroyed(e);
        }

        private void CustomControl_Load(object sender, EventArgs e)
        {
            this.processText.Text = "Search....";
            this.progressIndecator.Value = 0;
            this.progressIndecator.Width = this.Width;
        }
    }
}
