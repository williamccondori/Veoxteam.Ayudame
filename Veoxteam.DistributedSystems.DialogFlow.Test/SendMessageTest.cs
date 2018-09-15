using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Veoxteam.DistributedSystems.DialogFlow.Test
{
    [TestClass]
    public class SendMessageTest
    {
        FlowQuery _flowMessage;

        [TestMethod]
        public void SendMessage()
        {
            string flowApiUrl = "https://api.dialogflow.com";
            string flowApiVersion = "v1";
            string flowApi = string.Format("{0}/{1}", flowApiUrl, flowApiVersion);

            _flowMessage = new FlowQuery(flowApi);
            var result = _flowMessage.Send("Hola!");
        }
    }
}
