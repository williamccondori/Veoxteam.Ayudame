using System.Collections.Generic;
using Veoxteam.Application.Dtos.ManagementSystem;
using Veoxteam.Application.Dtos.Shared;
using Veoxteam.Application.Services.ManagementSystem;

namespace Veoxteam.Application.Services.Implementation.ManagementSystem
{
    public class ReportService : IReportService
    {
        public Response<IList<ReportDto>> GetByType(string reportTypeId)
        {
            return new Response<IList<ReportDto>>();
        }
    }
}
