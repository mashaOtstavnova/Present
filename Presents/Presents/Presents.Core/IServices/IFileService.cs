using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presents.Core.IServices
{
    public interface IFileService
    {
        byte[] ReadAllByteS(string path);
    }
}
