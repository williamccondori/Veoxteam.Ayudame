using Microsoft.Bot.Builder.ConnectorEx;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Veoxteam.Distribution.Botservice.Dialogs.DialogFlow.Reporte
{
    [Serializable]
    public class FacebookLocationDialog : IDialog<Place>
    {
        public async Task StartAsync(IDialogContext context)
        {
            IMessageActivity msg = context.MakeMessage();
            if (msg.ChannelId == "facebook")
            {
                var reply = context.MakeMessage();
                reply.ChannelData = new FacebookMessage
                (
                    text: "Por favor, brindame tu ubicación actual!",
                    quickReplies: new List<FacebookQuickReply>
                    {
                        new FacebookQuickReply(
                            contentType: FacebookQuickReply.ContentTypes.Location,
                            title: default(string),
                            payload: default(string)
                        )
                    }
                );
                await context.PostAsync(reply);


                context.Wait(this.LocationReceivedAsync);
            }
            else
            {
                await context.PostAsync("Esta opción no está disponible en esta plataforma.");
                context.Done(this);
            }
        }

        public virtual async Task LocationReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            IMessageActivity msg = await argument;
            Place location = msg.Entities?.Where(t => t.Type == "Place").Select(t => t.GetAs<Place>()).FirstOrDefault();

            if (location != null)
            {
                var geo = (location.Geo as JObject)?.ToObject<GeoCoordinates>();
                if (geo != null)
                {
                    //await context.PostAsync(string.Format("Latitud: {0}", geo.Latitude));
                    //await context.PostAsync(string.Format("Longitud: {0}", geo.Longitude));
                    await context.PostAsync("Hemos enviado el reporte del accidente de tránsito a las autoridades más cercanas 🚔");
                    await context.PostAsync("Muchas gracias por la notificación 😎");
                }
            }
            else
                await context.PostAsync("No elijiste una ubicación válida 🙁");
            context.Done(this);
        }
    }
}