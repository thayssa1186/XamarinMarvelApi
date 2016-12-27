using System.IO;
using Xamarin.Forms;
using TesteDigital.UWP;
using Windows.Storage;
using TesteDigital;

[assembly: Dependency(typeof(FileHelper))]
namespace TesteDigital.UWP
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
