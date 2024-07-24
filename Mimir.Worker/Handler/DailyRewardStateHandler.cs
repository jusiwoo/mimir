using Bencodex;
using Bencodex.Types;
using Mimir.Worker.Models;

namespace Mimir.Worker.Handler;

public class DailyRewardStateHandler : IStateHandler
{
    public IBencodable ConvertToState(StateDiffContext context)
    {
        if (context.RawState is not Integer value)
        {
            throw new ArgumentException(
                $"Invalid state type. Expected {nameof(Integer)}, got {context.RawState.GetType().Name}.",
                nameof(context.RawState)
            );
        }

        return new DailyRewardState(value);
    }
}
