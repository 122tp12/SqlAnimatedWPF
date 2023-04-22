using SqlAnimatedWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SqlAnimatedWPF
{
    public class MainViewModel
    {
        private SqLiteModel _model;
        
        public MainViewModel()
        {
            _model = new SqLiteModel();
        }
        public List<CommentDto> SelectAll()
        {
            return _model.SelectAll();
        }
        public int Insert(string appName, string userName, string comment)
        {
            return _model.Insert(new CommentDto(appName, userName, comment));
        }
        public int Update(int id, string appName, string userName, string comment)
        {
            return _model.Update(new CommentDto(id, appName, userName, comment));
        }
        public int Delete(int id)
        {
            return _model.Delete(id);
        }
    }
}
