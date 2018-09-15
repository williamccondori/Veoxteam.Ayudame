using System;

namespace Veoxteam.DistributedSystems.DialogFlow.Models
{
    public class FlowRequestQueryModel
    {
        public string[] Contexts { get; set; }
        public string Lang { get; set; }
        public string Query { get; set; }
        public string SessionId { get; set; }
        public string TimeZone { get; set; }

        public FlowRequestQueryModel()
        {

        }

        public static FlowRequestQueryModel CreateIntentQuery(string message)
        {
            return new FlowRequestQueryModel
            {
                Contexts = null,
                Lang = "es",
                Query = message,
                SessionId = Guid.NewGuid().ToString(),
                TimeZone = "America/Bogota"
            };
        }
    }
}
