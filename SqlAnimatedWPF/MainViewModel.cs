using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlAnimatedWPF
{
    public class MainViewModel
    {
        private SqLiteModel model;
        
        public MainViewModel()
        {
            model = new SqLiteModel();
        }
    }
}
