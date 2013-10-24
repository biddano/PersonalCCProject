using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPicApp.Data.Model
{
    [Table("Users")]
    public class User : AuditObject
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        

        //put all lists within the view model

        public virtual List<Comment> Comments { get; set; }
        public virtual List<Submission> Submissions { get; set; }
        ////public virtual List<Favorite> Favorites { get; set; }
        ////public virtual List<Like> Likes { get; set; }
        ////public virtual List<Dislike> Dislikes { get; set; }

        //public virtual List<Photo> Photos { get; set; }
    }

    
    
}
