using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlAnimatedWPF.Models
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }

        public CommentDto(int id, string applicationName, string userName, string comment)
        {
            Id = id;
            ApplicationName = applicationName;
            UserName = userName;
            Comment = comment;
        }
        public CommentDto(string applicationName, string userName, string comment)
        {
            ApplicationName = applicationName;
            UserName = userName;
            Comment = comment;
        }

        public override string ToString()
        {
            return Id.ToString() + ", " + ApplicationName.ToString() + ", " + UserName.ToString() + ", " + Comment.ToString();
        }
    }
}
