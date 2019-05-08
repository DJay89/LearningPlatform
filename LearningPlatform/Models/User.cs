using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearningPlatform.Models
{
    public enum Gender
    {
        M, F
    }

    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Age { get; set; }
        public Gender? Gender { get; set; }

        public ICollection<AppData> AppData { get; set; }
    }
}
