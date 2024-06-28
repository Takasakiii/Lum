using Lum.Shared.ViewModels.IA;

namespace Lum.Core.Adapters.Interfaces;

public interface IGeminiAdapter
{
    Task<IEnumerable<ConversationElementViewModel>> SendToChat(ICollection<ConversationElementViewModel> chat);
}