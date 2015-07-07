using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokeMans.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserComment { get; set; }
        public DateTime DateCreated { get; set; }
        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Items { get; set; }
    }
}
