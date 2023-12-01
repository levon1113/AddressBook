using System.ComponentModel.DataAnnotations;

namespace AddressBook.Data.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
