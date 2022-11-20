using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Title
    {
        [Key]
        public int TitleId { get; set; }
        [StringLength(50)]
        public string TitleName { get; set; }
        public DateTime TitleDate { get; set; }
        public bool TitleStatus { get; set; }
        public int CategoryId { get; set; }   //bir title'ın tek bir kategorisi olur.
        public virtual Category Category { get; set; } //bir title'ın tek bir kategorisi olur.

        public ICollection<Content> Contents { get; set; }
        public int SocialMediaUserId { get; set; }
        public virtual SocialMediaUser SocialMediaUser { get; set; }
    }
}
