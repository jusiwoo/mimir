using Bencodex;
using Bencodex.Types;
using Libplanet.Crypto;
using Mimir.Worker.Models;
using Mimir.Worker.Services;
using Nekoyume.Model;

namespace Mimir.Worker.Handler;

public class WorldInformationStateHandler : IStateHandler
{
    public IBencodable ConvertToState(StateDiffContext context)
    {
        if (context.RawState is Dictionary dict)
        {
            return new WorldInformationState(new WorldInformation(dict));
        }
        else
        {
            throw new InvalidCastException(
                $"{nameof(context.RawState)} Invalid state type. Expected Dictionary."
            );
        }
    }
}
