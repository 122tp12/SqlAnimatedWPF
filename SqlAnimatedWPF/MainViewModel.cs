using SqlAnimatedWPF.Models;
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
            model.Insert("app", "name", "comment");
        }
        public List<CommentDto> SelectAll()
        {
            return model.selectAll();
        }
        public void Close()
        {
            model.Close();
        }
    }
}
