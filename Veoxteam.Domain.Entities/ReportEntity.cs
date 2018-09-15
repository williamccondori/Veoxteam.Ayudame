using System;

namespace Veoxteam.Domain.Entities
{
    public class ReportEntity
    {
        public long Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime DateReport { get; set; }


        public ReportTypeEntity ReportType { get; set; }
    }
}
