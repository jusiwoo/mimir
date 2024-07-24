using Bencodex;
using Bencodex.Types;
using Mimir.Worker.Models;

namespace Mimir.Worker.Handler;

public class AgentStateHandler : IStateHandler
{
    public IBencodable ConvertToState(StateDiffContext context)
    {
        var agentState = context.RawState switch
        {
            List list => new Nekoyume.Model.State.AgentState(list),
            Dictionary dictionary => new Nekoyume.Model.State.AgentState(dictionary),
            _
                => throw new InvalidCastException(
                    $"{nameof(context.RawState)} Invalid state type. Expected {nameof(List)} or {nameof(Dictionary)}, got {context.RawState.GetType().Name}."
                ),
        };

        return new AgentState(agentState);
    }
}
