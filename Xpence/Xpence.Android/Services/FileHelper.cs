using System;
using System.IO;
using Xamarin.Forms;
using Xpence.Droid.Services;
using XpenceShared.Contracts;

[assembly: Dependency(typeof(FileHelper))]

namespace Xpence.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}