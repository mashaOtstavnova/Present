using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presents.Core.Domain
{
    public class Present
    {

        public string Image
        {
            get;
            set;
        }
        
        public long Id
        {
            get;
            set;
        }
        
        public string Title
        {
            get;
            set;
        }

        public string Details { get; set; }

    }
}
