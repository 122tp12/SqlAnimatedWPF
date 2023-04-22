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
        }
        public List<CommentDto> SelectAll()
        {
            return model.SelectAll();
        }
        public int Insert(CommentDto insertObj)
        {
            return model.Insert(insertObj);
        }
        public int Update(CommentDto updateObj)
        {
            return model.Update(updateObj);
        }
        public int Delete(int id)
        {
            return model.Delete(id);
        }
        public void Close()
        {
            model.Close();
        }
    }
}
