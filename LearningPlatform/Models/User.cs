using System.Collections.Generic;

namespace LearningPlatform.Models
{
    public enum Gender
    {
        M, F
    }

    public class User
    {
        public int Id { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }

        public ICollection<Data> Data { get; set; }
    }
}
