using OpenAI.Chat;

namespace Lum.Core.Adapters.Interfaces;

public interface IChatGptAdapter
{
    Task<ChatMessage> SendToChat(IEnumerable<ChatMessage> messages);
}