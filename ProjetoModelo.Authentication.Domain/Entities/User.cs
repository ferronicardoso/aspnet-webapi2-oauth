using ProjetoModelo.Authentication.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Authentication.Domain.Entities
{
    [Table("users")]
    public class User : IUser
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [StringLength(45)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(45)]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [StringLength(45)]
        [Column("password")]
        public string Password { get; set; }

        [Required]
        [Column("date_created")]
        public DateTime DateCreated { get; set; }
        
        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }
        
        [Column("date_lastaccess")]
        public DateTime? DateLastAccess { get; set; }
    }
}
