using Lum.Shared.Enums;

namespace Lum.Shared.ViewModels.IA;

public record ConversationElementViewModel(
    ChatActor Actor,
    string Message);