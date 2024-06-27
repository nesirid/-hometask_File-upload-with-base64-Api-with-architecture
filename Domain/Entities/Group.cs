using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Group : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Capacity { get; set; }
        public List<Student> Students  { get; set; }
        public virtual ICollection<GroupsStudents> GroupsStudents { get; set; }

    }
}
