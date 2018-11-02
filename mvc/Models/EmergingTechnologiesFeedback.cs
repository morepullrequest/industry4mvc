using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class EmergingTechnologiesFeedback
    {

        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        public String Username { get; set; }

        public String Heading { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }

        public string Feedback { get; set; }

        public int Agree { get; set; } = 0;

        public int Disagree { get; set; } = 0;

        public String EmergingTechnologiesName { get; set; }

        public string OwnerID { get; set; }

    }



    public enum EmergingTechnologies
    {
        AI,
        IoT,
        CognitiveServices,
        CloudComputing,
        Robotics,
        Blockchains
    }

    public class EnumET
    {
        public static Array GetEnumET()
        {
            return Enum.GetValues(typeof(EmergingTechnologies));
        }

    }
}
