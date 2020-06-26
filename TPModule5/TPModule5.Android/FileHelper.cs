using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TPModule5.Droid;
using TPModule5.Services;

[assembly: Xamarin.Forms.Dependency(typeof(FileHelper))]
namespace TPModule5.Droid
{

    public class FileHelper : IFileHelper
    {
        //public DatabasePath()
        //{ }

        public string GetLocalFilePath(string filename)
        {
            //cf: https://christophe.gigax.fr/2017/11/23/xamarin-forms-net-standard-2-0-et-entity-framework-core-avec-sqlite/
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filename);
        }
    }
}