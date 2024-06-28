namespace Lum.Shared.Exceptions;

public class AnilistUserNotFoundException(string username) : Exception($"Anilist username: {username} not found");