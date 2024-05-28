using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Groups
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxPlaces { get; set; }
        public ICollection<User>? Studants { get; set; }
        public Course? Course { get; set; }
        public int CourseId { get; set; }
        //public LessonsSchedule? Schedule { get; set; }

    }
}
