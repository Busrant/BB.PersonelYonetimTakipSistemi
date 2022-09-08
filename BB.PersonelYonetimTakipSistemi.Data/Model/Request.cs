using System;
using System.ComponentModel.DataAnnotations;

namespace BB.PersonelYonetimTakipSistemi.Data.Model
{
    public class Request
    {
        public int ID { get; set; }
        public int? EmployeeID { get; set; }
        public int? PermissionTypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public float? TotalDuration { get; set; }
        public string Description { get; set; }
        public int? ReplaceEmployeeId { get; set; }
        public int? IsAccepted { get; set; }
        public int? RequestTypeId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
