using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearningPlatform.Models
{
    public class AppData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsTextUnderstood { get; set; }
        public int WPM { get; set; }
        public int WordCount { get; set; }
        public string Mode { get; set; }

        public User User { get; set; }
    }
}
