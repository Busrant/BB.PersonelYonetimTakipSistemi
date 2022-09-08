using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.TimeDays
{
    public class TimeDayDto
    {
        public int ID { get; set; }
        public DateTime? TimeValue { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public int? Quarter { get; set; }
        public int? Week { get; set; }
        public int? WeekOfMonthStartingMonDate { get; set; }
        public int? WeekOfMonthStartingWedDate { get; set; }
        public int? DayOfWeek { get; set; }
        public int? DayOfYear { get; set; }
        public int? DayOfMonth { get; set; }
        public string DayName { get; set; }
        public string DayNameTr { get; set; }
        public string MonthName { get; set; }
        public string MonthNameTr { get; set; }
        public int? TimeDayTypeId { get; set; }
    }
}
