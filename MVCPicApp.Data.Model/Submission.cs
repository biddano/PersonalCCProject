using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPicApp.Data.Model
{
    public class Submission : AuditObject
    {
        [Key]
        public int SubmissionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //not sure how to manage this; as own object? different data type; want to make it so that there is option to upload from web(url) or from computer(upload)
        //public string PhotoURL { get; set; }
        //public int PhotoId { get; set; }
        [DataType(DataType.Upload)]
        public virtual Photo Photo { get; set; }



        public int UserId { get; set; }
        //public virtual User User { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public int Score { get; set; }

        
    }
}
