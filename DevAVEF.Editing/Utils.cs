//-----------------------------------------------------------------------
// <copyright file="C:\git\DevExtremeMVC-YouTube\DevAVEF.Editing\Utils.cs" company="">
//     Author: Don Wibier
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DevAVEF.Editing
{
    public class Utils
    {
    }

    public static class ImageExtensions
    {
        static ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        public static string GetMimeType(this Image image)
        {
            return image.RawFormat.GetMimeType();
        }

        public static byte[] CreateThumbArray(this byte[] imageData, int w, int h, out string mimeType)
        {
            Image thumbImg = null;
            ImageFormat orgFormat = null;

            using(MemoryStream orgMS = new MemoryStream(imageData))
            {
                Image orgImg = Image.FromStream(orgMS);

                orgFormat = orgImg.RawFormat;
                mimeType = orgImg.GetMimeType();
                thumbImg = orgImg.GetThumbnailImage(w, h, () => false, IntPtr.Zero);
            }
            if(thumbImg != null)
            {
                using(var ms = new MemoryStream())
                {
                    thumbImg.Save(ms, orgFormat);
                    return ms.ToArray();
                }
            }
            return null;
        }

        public static string GetMimeType(this ImageFormat imageFormat)
        {
            return codecs.First(codec => codec.FormatID == imageFormat.Guid).MimeType;
        }
    }
}
