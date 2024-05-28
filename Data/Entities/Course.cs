using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public string? ImageUrl { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
        public ICollection<Groups>? Groups { get; set; }

    }
}
