using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Veoxteam.Distribution.Botservice
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            try
            {

                if (activity.Type == ActivityTypes.Message)
                {
                    ConnectorClient conector = new ConnectorClient(new Uri(activity.ServiceUrl));

                    Activity actividadTyping = activity.CreateReply();
                    actividadTyping.Type = ActivityTypes.Typing;
                    await conector.Conversations.ReplyToActivityAsync(actividadTyping);

                    activity.Text = string.IsNullOrEmpty(activity.Text) ? "0" : activity.Text;

                    //ClienteDto cliente = new ClienteDto
                    //{
                    //    CodigoCliente = actividad.From.Id,
                    //    DescripcionNombre = actividad.From.Name,
                    //    DescripcionConversacion = actividad.Conversation.Id,
                    //    DescripcionMetadata = JsonConvert.SerializeObject(actividad),
                    //    DescripcionCanal = actividad.ChannelId,
                    //    Estado = EstadoObjeto.Nuevo
                    //};

                    //ClienteProxy proxyCliente = new ClienteProxy(VariableConfiguracion.RutaApi());

                    //proxyCliente.Guardar(cliente);

                    await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
                }
                else
                {
                    HandleSystemMessage(activity);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception excepcion)
            {
                ConnectorClient conector = new ConnectorClient(new Uri(activity.ServiceUrl));

                Activity nuevaActividad = activity.CreateReply(excepcion.Message);

                nuevaActividad.Type = ActivityTypes.Message;

                await conector.Conversations.ReplyToActivityAsync(nuevaActividad);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        private Activity HandleSystemMessage(Activity message)
        {
            string messageType = message.GetActivityType();
            if (messageType == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (messageType == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (messageType == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (messageType == ActivityTypes.Typing)
            {
                // Handle knowing that the user is typing
            }
            else if (messageType == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}