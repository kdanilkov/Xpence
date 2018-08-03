using System;
using System.IO;
using Xamarin.Forms;
using Xpence.iOS.Services;
using XpenceShared.Contracts;
//using SQLite.Net.Interop;
//using SQLite.Net.Platform.XamarinIOS;

[assembly: Dependency(typeof(FileHelper))]

namespace Xpence.iOS.Services

{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            var docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
                Directory.CreateDirectory(libFolder);

            return Path.Combine(libFolder, filename);
        }

        //public ISQLitePlatform GetPlatform()
        //{
        //    return new SQLitePlatformIOS();
        //}
    }
}