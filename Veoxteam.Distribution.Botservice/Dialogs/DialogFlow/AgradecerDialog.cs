using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace Veoxteam.Distribution.Botservice.Dialogs.DialogFlow
{
    [Serializable]
    public class AgradecerDialog : IDialog<object>
    {
        private string _message;

        public AgradecerDialog(string message)
        {
            _message = message;
        }

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync(_message);

            context.Done(this);
        }
    }
}