using BoardApp.ViewModels.Base;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardApp.Messages
{
    public class NavigationMessage
    {
        public ViewModelBase ViewModelType { get; set; }
    }
}
