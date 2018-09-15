using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;
using Veoxteam.DistributedSystems.DialogFlow;
using Veoxteam.DistributedSystems.DialogFlow.Models;
using Veoxteam.Distribution.Botservice.Dialogs.DialogFlow;
using Veoxteam.Distribution.Botservice.Dialogs.DialogFlow.Reporte;
using Veoxteam.Distribution.Botservice.Dialogs.DialogFlow.Urgencia;
using Veoxteam.Distribution.Botservice.Intents;

namespace Veoxteam.Distribution.Botservice.Dialogs
{
    [Serializable]
    public class RootDialog : IntentDialog, IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await Task.Run(() => context.Wait(MessageReceivedAsync));
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            Activity message = (Activity)await result;
            FlowQuery _flowMessage = new FlowQuery(_flowApi);
            FlowResponseQueryModel intent = new FlowQuery(_flowApi).Send(message.Text);
            switch (intent.Intent)
            {
                case Intent.GeneralPredeterminado:
                    await Predeterminado(context, intent.Message); break;
                case Intent.GeneralSaludar:
                    await Saludar(context, intent.Message); break;
                case Intent.GeneralAgradecer:
                    await Agradecer(context, intent.Message); break;

                case Intent.UrgenciaMordeduraPicadura:
                    await MordeduraPicadura(context, intent.Message); break;
                case Intent.UrgenciaFractura:
                    await Fractura(context, intent.Message); break;
                case Intent.UrgenciaBebeAtragantado:
                    await BebeAtragantado(context, intent.Message); break;
                default:
                    throw new ApplicationException("Ocurrió un problema al momento de detectar la intención");
            }
        }

        private async Task Predeterminado(IDialogContext context, string message)
        {
            await Empezar(() => StartDialog(context, new PredeterminadoDialog(message)));
        }

        private async Task Saludar(IDialogContext context, string message)
        {
            await Empezar(() => StartDialog(context, new SaludarDialog(message)));
        }

        private async Task Agradecer(IDialogContext context, string message)
        {
            await Empezar(() => StartDialog(context, new FacebookLocationDialog()));
        }

        // Urgencia

        private async Task BebeAtragantado(IDialogContext context, string message)
        {
            await Empezar(() => StartDialog(context, new BebeAtragantadoDialog(message)));
        }

        private async Task MordeduraPicadura(IDialogContext context, string message)
        {
            await Empezar(() => StartDialog(context, new MordeduraPicaduraDialog(message)));
        }

        private async Task Fractura(IDialogContext context, string message)
        {
            await Empezar(() => StartDialog(context, new FracturaDialog(message)));
        }
    }
}