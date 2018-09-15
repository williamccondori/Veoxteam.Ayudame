using System.Collections.Generic;
using Veoxteam.Application.Dtos.ManagementSystem;
using Veoxteam.Application.Dtos.Shared;

namespace Veoxteam.Application.Services.ManagementSystem
{
    public interface IReportService
    {
        Response<IList<ReportDto>> GetByType(string reportTypeId);
    }
}
