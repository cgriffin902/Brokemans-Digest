using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokeMans.Models
{
    public class CommentViewModel
    {
        public string UserComment { get; set; }
        public string Commenter { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ItemId { get; set; }
    }
}