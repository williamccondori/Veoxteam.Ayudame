using Veoxteam.DistributedSystems.DialogFlow.Helpers;
using Veoxteam.DistributedSystems.DialogFlow.Models;

namespace Veoxteam.DistributedSystems.DialogFlow.Services
{
    public class FlowRequestQueryService : BaseProxy
    {
        public FlowRequestQueryService(string path)
            : base(string.Format("{0}/query?v=20170712", path))
        {

        }

        public FlowResponseQueryModel Send(FlowRequestQueryModel flowRequestQueryModel)
        {
            Response<ResponseQueryModel> result = Ejecutar<ResponseQueryModel>(string.Empty, HttpMethod.Post,
                 RequestQueryModel.CreateQuery(flowRequestQueryModel));

            return result.Data.GetFlowResponseQueryModel();
        }

        private class RequestQueryModel
        {
            public string query { get; set; }
            public string lang { get; set; }
            public string sessionId { get; set; }
            public string timezone { get; set; }

            public RequestQueryModel()
            {

            }

            public static RequestQueryModel CreateQuery(FlowRequestQueryModel flowRequestQueryModel)
            {
                return new RequestQueryModel
                {
                    query = flowRequestQueryModel.Query,
                    lang = flowRequestQueryModel.Lang,
                    sessionId = flowRequestQueryModel.SessionId,
                    timezone = flowRequestQueryModel.TimeZone
                };
            }
        }

        private class MetadataQueryModel
        {
            public string intentName { get; set; }
        }

        private class FulfillmentQueryModel
        {
            public string speech { get; set; }
        }

        private class ResultQueryModel
        {
            public string source { get; set; }
            public string resolvedQuery { get; set; }
            public string action { get; set; }
            public bool actionIncomplete { get; set; }
            public FulfillmentQueryModel fulfillment { get; set; }
            public MetadataQueryModel metadata { get; set; }
        }

        private class ResponseQueryModel
        {
            public string id { get; set; }
            public string timestamp { get; set; }
            public string lang { get; set; }
            public string sessionId { get; set; }
            public ResultQueryModel result { get; set; }

            public FlowResponseQueryModel GetFlowResponseQueryModel()
            {
                return new FlowResponseQueryModel
                {
                    Id = id,
                    Timestamp = timestamp,
                    Lang = lang,
                    SessionId = sessionId,
                    Message = result.fulfillment.speech,
                    Intent = result.metadata.intentName
                };
            }

            //{  
            //   "id":"81954f39-5be7-4fbc-b168-f76e39c4189b",
            //   "timestamp":"2018-09-12T06:14:37.527Z",
            //   "lang":"es",
            //   "result":{  
            //      "source":"agent",
            //      "resolvedQuery":"Hola!",
            //      "action":"",
            //      "actionIncomplete":false,
            //      "parameters":{  

            //      },
            //      "contexts":[

            //      ],
            //      "metadata":{  
            //         "intentId":"1f93b180-2ff3-4ca3-af33-d1fb3343b573",
            //         "webhookUsed":"false",
            //         "webhookForSlotFillingUsed":"false",
            //         "isFallbackIntent":"false",
            //         "intentName":"saludar"
            //      },
            //      "fulfillment":{  
            //         "speech":"Buenos días",
            //         "messages":[
            //            {  
            //               "type":0,
            //               "speech":"Hola!"
            //            }
            //         ]
            //      },
            //      "score":0.75
            //   },
            //   "status":{  
            //      "code":200,
            //      "errorType":"success"
            //   },
            //   "sessionId":"a4260d6a-9efc-3bec-2ab4-62f2edda9671"
            //}
        }
    }
}
