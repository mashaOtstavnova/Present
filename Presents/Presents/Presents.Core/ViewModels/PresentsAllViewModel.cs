using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace Presents.Core.ViewModels
{
    public class PresentsAllViewModel : MvxViewModel
    {
        public PresentsAllViewModel()
        {
        }
        public IMvxCommand AddClickCommand
        {
            get { return new MvxCommand(OnClickAdd); }
        }

        private void OnClickAdd()
        {
        }
    }
}
