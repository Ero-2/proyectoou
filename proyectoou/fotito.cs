using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using System.IO;

namespace proyectoou
{
    public class fotito
    {
        public Bitmap Image { get; set; }
        public string FilePath { get; private set; }

        public void SaveImage()
        {
            if (Image != null)
            {
                if (Image != null)
                {
                    string rutaPersonalizada = @"C:\Users\erick garcia\Desktop\datos clientes";
                    string fileName = $"foto_{DateTime.Now.ToString("yyyyMMddHHmmss")}.jpg";
                    string filePath = Path.Combine(rutaPersonalizada, fileName);
                    Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    FilePath = filePath;
                }

            }
        }
    }
}




