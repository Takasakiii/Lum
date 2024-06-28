using GraphQL;
using GraphQL.Client.Abstractions;
using Lum.Core.Adapters.Interfaces;
using Lum.Shared.ViewModels.AnilistGraphQl;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace Lum.Core.Adapters;

[Adapter<IAnilistAdapter>]
public class AnilistAdapter(IGraphQLClient anilistClient) : IAnilistAdapter
{
    public async Task<DataMediaListViewModel?> GetUserAnimeList(string userName)
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
        var response = await anilistClient.SendQueryAsync<DataMediaListViewModel>(request);
        return response.Data;
    }

    public async Task<DataMediaViewModel?> GetAnimeInfo(string name)
    {
        var request = new GraphQLRequest
        {
            Query = """
                    query($search:String){
                      Media(search: $search, type: ANIME) {
                        id,
                        idMal
                        title {
                          romaji
                        },
                        genres,
                        status,
                        description,
                      }
                    }
                    """,
            Variables = new
            {
                search = name
            }
        };

        var response = await anilistClient.SendQueryAsync<DataMediaViewModel>(request);
        return response.Data;
    }

    public async Task<IEnumerable<DataMediaViewModel>> GetAnimesInfo(IEnumerable<string> names)
    {
        var tasks = names.Select(x => Task.Run(async () => await GetAnimeInfo(x)));
        var results = await Task.WhenAll(tasks);
        return results.Where(x => x is not null)!;
    }
}