using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Agree
    {
        public int ID { get; set; }

        public int CompanyFeedbackId { get; set; } = -1;

        public int TechFeedbackId { get; set; } = -1;
        
        public string AgreeOrDisagree { get; set; }

        public string FeedbackType { get; set; }

        public string Cookie { get; set; }
    }
}
