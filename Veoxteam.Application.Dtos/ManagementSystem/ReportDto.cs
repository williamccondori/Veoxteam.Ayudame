using System;

namespace Veoxteam.Application.Dtos.ManagementSystem
{
    public class ReportDto
    {
        public long Id { get; set; }
        public string ReportTypeId { get; set; }
        public string Title { get; set; }
        public string ClientAppId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Description { get; set; }
        public DateTime DateReport { get; set; }
    }
}
