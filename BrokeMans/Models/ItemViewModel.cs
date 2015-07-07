using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokeMans.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Pic { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CommentViewModel> commentViewModel { get; set; }


    }
}