using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace userService.Database.Entities
{
    [Table("User", Schema = "challenge")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string contact { get; set; }
    }
}
