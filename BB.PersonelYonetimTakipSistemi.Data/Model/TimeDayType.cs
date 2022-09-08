using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Data.Model
{
    public class TimeDayType
    {
        public int ID { get; set; }
        public string Explanation { get; set; }
        public float? EffectDay { get; set; }

    }
}
