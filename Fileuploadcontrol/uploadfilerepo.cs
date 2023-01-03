using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileuploadcontrol
{
    public class uploadfilerepo : UploadInterface
    {
        private IHostingEnvironment hostingEnviornment;
        public uploadfilerepo(IHostingEnvironment hostingenvironment)
        {
            this.hostingEnviornment = hostingenvironment;
        }
        public async void uploadmultiplefile(IList<IFormFile> files)
        {
            long totalBytes = files.Sum(f => f.Length);
            foreach (IFormFile item in files)
            {
                string filename = item.FileName.Trim('"');
                byte[] buffer = new byte[16 * 1024];
                using (FileStream output = System.IO.File.Create(this.getpathandfilename(filename)))
                {
                    using (Stream input = item.OpenReadStream())
                    {
                        int readbytes;
                        while ((readbytes = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            await output.WriteAsync(buffer, 0, readbytes);
                            totalBytes += readbytes;
                        }
                    }
                }
            }
        }

        private string getpathandfilename(string filename)
        {
            string path = this.hostingEnviornment.WebRootPath + "\\uploads\\";
            if (!Directory.Exists(path))

                Directory.CreateDirectory(path);
                return path + filename;

        }


    }
}