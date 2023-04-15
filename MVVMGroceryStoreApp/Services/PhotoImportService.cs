using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace MVVMGroceryStoreApp.Services
{
    public class PhotoImportService
    {
        readonly static OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            Multiselect = false,
            Filter = "Images (*.JPG; *.PNG)| *.JPG;*.PNG"
        };
        public static BitmapImage ImportToBitmapImage(int pixelSizeImage)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(openFileDialog.FileName);
                bitmapImage.EndInit();

                CroppedBitmap croppedBitmap;

                if (bitmapImage.PixelWidth > bitmapImage.PixelHeight)
                {
                    int widthPoint = (bitmapImage.PixelWidth - bitmapImage.PixelHeight) / 2;
                    croppedBitmap = new CroppedBitmap(bitmapImage, new Int32Rect(widthPoint, 0, bitmapImage.PixelHeight, bitmapImage.PixelHeight));
                }
                else if (bitmapImage.PixelWidth < bitmapImage.PixelHeight)
                {
                    int heightPoint = (bitmapImage.PixelHeight - bitmapImage.PixelWidth) / 2;
                    croppedBitmap = new CroppedBitmap(bitmapImage, new Int32Rect(0, heightPoint, bitmapImage.PixelWidth, bitmapImage.PixelWidth));
                }
                else
                {
                    croppedBitmap = new CroppedBitmap(bitmapImage, new Int32Rect(0, 0, (int)(bitmapImage.PixelWidth), (int)(bitmapImage.PixelWidth)));
                }

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    JpegBitmapEncoder bitmapEncoder = new JpegBitmapEncoder();
                    bitmapEncoder.Frames.Add(BitmapFrame.Create(croppedBitmap));
                    bitmapEncoder.Save(memoryStream);

                    bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memoryStream;
                    bitmapImage.DecodePixelHeight = pixelSizeImage;
                    bitmapImage.DecodePixelWidth = pixelSizeImage;
                    bitmapImage.EndInit();

                    return bitmapImage;
                }
            }
            return null;
        }
        public static byte[] ImportToByte(int pixelSizeImage)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(openFileDialog.FileName);
                bitmapImage.EndInit();

                CroppedBitmap croppedBitmap;

                if (bitmapImage.PixelWidth > bitmapImage.PixelHeight)
                {
                    int widthPoint = (bitmapImage.PixelWidth - bitmapImage.PixelHeight) / 2;
                    croppedBitmap = new CroppedBitmap(bitmapImage, new Int32Rect(widthPoint, 0, bitmapImage.PixelHeight, bitmapImage.PixelHeight));
                }
                else if (bitmapImage.PixelWidth < bitmapImage.PixelHeight)
                {
                    int heightPoint = (bitmapImage.PixelHeight - bitmapImage.PixelWidth) / 2;
                    croppedBitmap = new CroppedBitmap(bitmapImage, new Int32Rect(0, heightPoint, bitmapImage.PixelWidth, bitmapImage.PixelWidth));
                }
                else
                {
                    croppedBitmap = new CroppedBitmap(bitmapImage, new Int32Rect(0, 0, (int)(bitmapImage.PixelWidth), (int)(bitmapImage.PixelWidth)));
                }

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    JpegBitmapEncoder bitmapEncoder = new JpegBitmapEncoder();
                    bitmapEncoder.Frames.Add(BitmapFrame.Create(croppedBitmap));
                    bitmapEncoder.Save(memoryStream);

                    bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memoryStream;

                    bitmapImage.DecodePixelHeight = pixelSizeImage;
                    bitmapImage.DecodePixelWidth = pixelSizeImage;
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    bitmapImage.EndInit();

                    MemoryStream memory = new MemoryStream();
                    bitmapEncoder = new JpegBitmapEncoder();
                    bitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                    bitmapEncoder.Save(memory);

                    return memory.ToArray();
                }
            }
            return null;
        }

    }
}
