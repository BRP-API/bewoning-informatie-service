using Gba = Bewoning.Informatie.Service.Generated.Gba;
using Newtonsoft.Json;
using Bewoning.Informatie.Service.Profiles;
using Brp.Shared.Infrastructure.Json;

namespace Bewoning.Informatie.Service.Helpers;

public static class TransformHelpers
{
    private static bool IsProxyResponse(this string payload)
    {
        var proxyTokens = new List<string>
        {
            "\"inOnderzoek\":",
            "\"geheimhoudingPersoonsgegevens\":true",
        };

        return proxyTokens.Exists(t => payload.Contains(t));
    }

    public static string Transform(this string payload, ILogger logger)
    {
        if (payload.IsProxyResponse())
        {
            logger.LogInformation("proxy2proxy");
            return payload;
        }

        var response = JsonConvert.DeserializeObject<Gba.GbaBewoningenQueryResponse>(payload);

        return response!.Map().ToJsonCompact();
    }
}
