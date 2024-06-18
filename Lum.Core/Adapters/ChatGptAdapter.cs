using Lum.Core.Adapters.Interfaces;
using OpenAI.Chat;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace Lum.Core.Adapters;

[Adapter<IChatGptAdapter>]
public class ChatGptAdapter(ChatClient chatClient) : IChatGptAdapter
{
    public async Task<ChatMessage> SendToChat(IEnumerable<ChatMessage> messages)
    {
        var result = await chatClient.CompleteChatAsync(messages);
        return new AssistantChatMessage(result.Value);
    }
}