using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Presents.Core.IServices;

namespace Presents.Droid.Services
{
    public class FileService: IFileService
    {
        public byte[] ReadAllByteS(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}