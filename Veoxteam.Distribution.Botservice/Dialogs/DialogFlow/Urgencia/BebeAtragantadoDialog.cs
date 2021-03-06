﻿using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Veoxteam.Distribution.Botservice.Dialogs.DialogFlow.Urgencia
{
    [Serializable]
    public class BebeAtragantadoDialog : IDialog<object>
    {
        private string _message;

        public BebeAtragantadoDialog(string message)
        {
            _message = message;
        }

        public async Task StartAsync(IDialogContext context)
        {
            IMessageActivity activity = context.MakeMessage();
            activity.Recipient = activity.From;
            activity.Type = ActivityTypes.Message;
            activity.Text = _message;
            activity.AttachmentLayout = AttachmentLayoutTypes.List;
            activity.Attachments = new List<Attachment>();

            activity.Attachments.Add(new Attachment()
            {
                ContentUrl = "https://pbs.twimg.com/media/DUvLBEIVAAArB_e.jpg",
                ContentType = "image/jpg"
            });

            await context.PostAsync(activity);

            context.Done(this);
        }
    }
}