using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SocialMediaUser
    {
        [Key]
        public int SocialMediaUserId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(250)]
        public string Image { get; set; }
        [StringLength(100)]
        public string SocialMediaUserAbout { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(200)]
        public string Password { get; set; }
        [StringLength(50)]
        public string SocialMediaUserTitle { get; set; }
        public bool SocialMediaUserStatus { get; set; }

        public ICollection<Title> Titles { get; set; }//bir yazarın çok sayıda title'ı olur
        public ICollection<Content> Contents { get; set; } //bir yazarın çok sayıda content'i olur
    }
}
