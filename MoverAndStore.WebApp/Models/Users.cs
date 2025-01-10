using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace MoverAndStore.WebApp.Models
{
    [Table("user")]
    public partial class User
    {
        [Key]
        [Column("person_id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string  Firstname { get; set; } = null!;

        [Column("lastname")]
        public string Lastname { get; set; } = null!; 

        [Column("username")]
        public string Username { get; set; } = null!;
    }
}
