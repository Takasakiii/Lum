using ChatAIze.GenerativeCS.Clients;
using ChatAIze.GenerativeCS.Models;
using Lum.Core.Adapters.Interfaces;
using Lum.Shared.Enums;
using Lum.Shared.ViewModels.IA;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace Lum.Core.Adapters;

[Adapter<IGeminiAdapter>]
public class GeminiAdapter(GeminiClient geminiClient) : IGeminiAdapter
{
    public async Task<IEnumerable<ConversationElementViewModel>> SendToChat(ICollection<ConversationElementViewModel> chat)
    {
        var conversation = new ChatConversation();

        foreach (var message in chat)
        {
            switch (message.Actor)
            {
                case ChatActor.System:
                {
                    await conversation.FromUserAsync(message.Message);
                    break;
                }
                case ChatActor.Ai:
                {
                    await conversation.FromChatbotAsync(message.Message);
                    break;
                }
                case ChatActor.User:
                {
                    await conversation.FromUserAsync(message.Message);
                    break;
                }
            }
        }
        
        var response = await geminiClient.CompleteAsync(conversation);
        var charVm = new ConversationElementViewModel(ChatActor.Ai, response);
        return chat.Append(charVm);
    }
}