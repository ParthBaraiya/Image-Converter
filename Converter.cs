using System;
using ImageMagick;
using System.IO;

namespace ImageConverter
{
    class Extensions
    {
        public static string[] Extension = new string[] { "jpg", "jpeg", "png" };
    }

    class Converter
    {
        public void Convert(string filename)
        {
            
            using (MagickImage image = new MagickImage(filename))
            {
                // string[] filePath = filename.Split('.');
                // string ext = filePath[filePath.Length -1];
                string outputFile = Path.GetDirectoryName(filename) + 
                    Path.GetFileNameWithoutExtension(filename) + ".jpg";
                image.Write(outputFile);
            }
        }

        public void Convert(string ipFile, string opDir, string type)
        {
            if (!Directory.Exists(opDir)) Directory.CreateDirectory(opDir);

            // file name without extension
            string filename = Path.GetFileNameWithoutExtension(ipFile);

            // Same as parsed parameter
            string file = ipFile;

            // Output Directory Path + filename + Filetype (Given by type argument of method)
            string opFile = Path.Combine(opDir, filename+ "."+type);
            Console.WriteLine(opFile);

            using (MagickImage image = new MagickImage(file))
            {
                image.Write(opFile);
            }
        }
    }
}
