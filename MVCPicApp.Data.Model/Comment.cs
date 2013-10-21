using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPicApp.Data.Model
{
    public class Comment : AuditObject
    {
        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }
        //public virtual User User { get; set; }

        public int SubmissionId { get; set; }
        //public virtual Submission Submission { get; set; }

        //this is by default 0 until user give likes or dislikes; represents popularity
        public int Score { get; set; }

        //value that determines whether the asker/submitter of the original upload has chosen this comment to be correct
        public bool IsCorrect { get; set; }
    }
}
