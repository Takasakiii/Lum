using GraphQL;
using GraphQL.Client.Abstractions;
using Lum.Core.Adapters.Interfaces;
using Lum.Shared.ViewModels.AnilistGraphQl;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace Lum.Core.Adapters;

[Adapter<IAnilistAdapter>]
public class AnilistAdapter(IGraphQLClient anilistClient) : IAnilistAdapter
{
    public async Task<DataViewModel?> GetUserAnimeList(string userName)
    {
        var request = new GraphQLRequest
        {
            Query = """
                    query($userName:String){
                      MediaListCollection(userName: $userName, type:ANIME) {
                        lists {
                          name
                          isSplitCompletedList:entries {
                            media {
                              title {
                                romaji
                              }
                            },
                            score
                          }
                          status
                        }
                      }
                    }
                    """,
            Variables = new
            {
                userName
            }
        };
        var response = await anilistClient.SendQueryAsync<DataViewModel>(request);
        return response.Data;
    }
}