using mvc.Models.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class CompanyAndOrganizationFeedback
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        public String Username { get; set; }

        [Required]
        public String Heading { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }

        [Required]
        [MinLength(5)]
        public string Feedback { get; set; }

        public int Agree { get; set; } = 0;

        public int Disagree { get; set; } = 0;

        [Required]
        [CompanyType]
        [Display(Name = "Name of Companies And Organizations")]
        public String CompanyName { get; set; }

        public string OwnerID { get; set; }
    }
}
