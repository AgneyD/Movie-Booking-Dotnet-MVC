using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileuploadcontrol
{
    public interface UploadInterface
    {
        void uploadmultiplefile(IList<IFormFile> files);
    }
}
