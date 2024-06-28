using ChatAIze.GenerativeCS.Extensions;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Lum.Core.Adapters;
using Lum.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using TakasakiStudio.Lina.AutoDependencyInjection;
using TakasakiStudio.Lina.Utils.LoaderConfig;

namespace Lum.Core;

public static class LumCore
{
    public static void AddLum(this IServiceCollection collection)
    {
        collection.SetupGraphQl();
        collection.AddAutoDependencyInjection<AnilistAdapter>();
        var config = collection.AddLoaderConfig<ILumConfig>();
        collection.AddGeminiClient(config.GeminiIaToken);
    }

    private static void SetupGraphQl(this IServiceCollection collection)
    {
        var anilistGraphQlClient = new GraphQLHttpClient("https://graphql.anilist.co/", new SystemTextJsonSerializer());
        collection.AddSingleton<IGraphQLClient>(anilistGraphQlClient);
    }
}