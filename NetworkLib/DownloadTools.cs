using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ACLibrary.Network
{
    public class DownloadTools : WebClient
    {
        public void DownloadFileAsync(string uri, string path)
        {
            DownloadFileAsync(new Uri(uri), path);
        }
    }
}
