using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace Veoxteam.Distribution.Botservice.Intents
{
    [Serializable]
    public class IntentDialog
    {
        protected string _flowApi;

        public IntentDialog()
        {
            string flowApiUrl = "https://api.dialogflow.com";
            string flowApiVersion = "v1";
            _flowApi = string.Format("{0}/{1}", flowApiUrl, flowApiVersion);
        }

        protected void StartDialog(IDialogContext context, IDialog<object> dialogo, ResumeAfter<object> siguiente = null)
        {
            ResumeAfter<object> resumen = siguiente ?? Terminar;
            context.Call(dialogo, resumen);
        }

        protected async Task Empezar(Action funcion)
        {
            await Task.Run(funcion);
        }

        protected async Task Terminar(IDialogContext context, IAwaitable<object> result)
        {
            await Task.Run(() => context.Done(this));
        }
    }
}