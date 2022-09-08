using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Data.Model
{
    public class User
    {
        public int ID { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ProfilePhoto { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public bool? Gender { get; set; }
        public string DisabilitySituation { get; set; }
        public string Nationality { get; set; }
        public string BloodGroup { get; set; }
        public string MilitaryStatus { get; set; }
        public string EducationalStatus { get; set; }
        public string LastCompletedEducationDegree { get; set; }
        public string CompletedEducation { get; set; }
        public bool? MaritialSituation { get; set; }
    }
}
