using System.ComponentModel.DataAnnotations;

namespace TestWebAPI.DataAccess.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}