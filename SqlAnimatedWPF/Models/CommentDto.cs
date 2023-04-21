using System.Security.Cryptography;

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
        public override string ToString()
        {
            return this.Id + ", " + this.ApplicationName + ", " + this.UserName + ", " + this.Comment;
        }
    }
}
