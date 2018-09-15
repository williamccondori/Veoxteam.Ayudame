using Veoxteam.Application.Dtos.Bot;

namespace Veoxteam.Application.Services.Bot
{
    public interface IMessageService
    {
        bool Save(MessageDto mensaje);
    }
}
