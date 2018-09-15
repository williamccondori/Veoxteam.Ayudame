using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Veoxteam.Distribution.Botservice.Dialogs.DialogFlow
{
    [Serializable]
    public class SaludarDialog : IDialog<object>
    {
        private string _message;

        public SaludarDialog(string message)
        {
            _message = message;
        }

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync(_message);

            IMessageActivity activity = context.MakeMessage();
            activity.Recipient = activity.From;
            activity.Type = ActivityTypes.Message;
            activity.Text = "Estas son algunas de las opciones que tengo para ti 😀";

            activity.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            activity.Attachments = new List<Attachment>();

            HeroCard loTarjetaInformacion = new HeroCard()
            {
                Title = "Información",
                Text = "Información a cerca de la universidad o de la escuela profesional.",
                Images = new List<CardImage>
                {
                    new CardImage
                    {
                        Url = "https://kwttoday.com/wp-content/uploads/2018/05/help-me-blogging-cage-contest-678x381.jpg"
                    }
                },
                Buttons = new List<CardAction>
                {
                    new CardAction
                    {
                        Title = "Dirección",
                        Value = "Direccion",
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Title = "Teléfono",
                        Value = "Telefono",
                        Type = ActionTypes.ImBack
                    }
                }
            };

            HeroCard loTarjetaPublicacion = new HeroCard()
            {
                Title = "Publicaciones",
                Text = "Mantente al día con las principales noticias y actualidades.",
                Images = new List<CardImage>
                {
                    new CardImage
                    {
                        Url = "https://kwttoday.com/wp-content/uploads/2018/05/help-me-blogging-cage-contest-678x381.jpg"
                    }
                },
                Buttons = new List<CardAction>()
                {
                    new CardAction
                    {
                        Title = "Noticias",
                        Value = "Noticias",
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Title = "Actualidades",
                        Value = "Actualidades",
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Title = "Eventos",
                        Value = "Eventos",
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Title = "Galería de fotos",
                        Value = "Galería",
                        Type = ActionTypes.ImBack
                    }
                }
            };

            HeroCard loTarjetaPlanEstudio = new HeroCard()
            {
                Title = "Plan de estudios",
                Text = "Información a cerca del plan de estudio actual.",
                Images = new List<CardImage>
                {
                    new CardImage
                    {
                        Url = "https://kwttoday.com/wp-content/uploads/2018/05/help-me-blogging-cage-contest-678x381.jpg"
                    }
                },
                Buttons = new List<CardAction>()
                {
                    new CardAction
                    {
                        Title = "Plan de estudios",
                        Value = "Plan de estudios",
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Title = "Malla curricular",
                        Value = "Malla curricular",
                        Type = ActionTypes.ImBack
                    }
                }
            };

            HeroCard loTarjetaDocumento = new HeroCard()
            {
                Title = "Documentos",
                Text = "Documentos importantes para estudiantes y docentes.",
                Images = new List<CardImage>
                {
                    new CardImage
                    {
                        Url = "https://kwttoday.com/wp-content/uploads/2018/05/help-me-blogging-cage-contest-678x381.jpg"
                    }
                },
                Buttons = new List<CardAction>
                {
                    new CardAction
                    {
                        Title = "Formatos",
                        Value = "Formatos",
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Title = "Reglamentos",
                        Value = "Reglamentos",
                        Type = ActionTypes.ImBack
                    }
                }
            };

            HeroCard loTarjetaOpinion = new HeroCard()
            {
                Title = "Contáctenos",
                Text = "Tu opinión nos importa, no perdamos contacto.",
                Images = new List<CardImage>
                {
                    new CardImage
                    {
                        Url = "https://kwttoday.com/wp-content/uploads/2018/05/help-me-blogging-cage-contest-678x381.jpg"
                    }
                },
                Buttons = new List<CardAction>()
                {
                    new CardAction
                    {
                        Title = "Buzón de sugerencias",
                        Value = "Buzon",
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Title = "Calificanos",
                        Value = "Calificanos",
                        Type = ActionTypes.ImBack
                    }
                }
            };

            activity.Attachments.Add(loTarjetaInformacion.ToAttachment());
            activity.Attachments.Add(loTarjetaPublicacion.ToAttachment());
            activity.Attachments.Add(loTarjetaPlanEstudio.ToAttachment());
            activity.Attachments.Add(loTarjetaDocumento.ToAttachment());
            activity.Attachments.Add(loTarjetaOpinion.ToAttachment());

            await context.PostAsync(activity);

            context.Done(this);
        }
    }
}