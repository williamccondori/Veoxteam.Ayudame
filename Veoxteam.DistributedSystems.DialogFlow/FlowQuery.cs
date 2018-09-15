using Veoxteam.DistributedSystems.DialogFlow.Models;
using Veoxteam.DistributedSystems.DialogFlow.Services;

namespace Veoxteam.DistributedSystems.DialogFlow
{
    public class FlowQuery
    {
        private string _url;

        public FlowQuery(string url)
        {
            _url = url;
        }

        public FlowResponseQueryModel Send(string message)
        {
            return new FlowRequestQueryService(_url).Send(
                FlowRequestQueryModel.CreateIntentQuery(message));
        }
    }
}
