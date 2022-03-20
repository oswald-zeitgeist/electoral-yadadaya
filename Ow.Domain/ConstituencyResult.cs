using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace Ow.DataSource.CommonsLibrary
{
    [DebuggerDisplay("{ToString()}")]
    public class ConstituencyResult : IIdentifiable<string>
    {
        public ConstituencyResult(
            string id,
            string electorate,
            string name,
            string region,
            string boundarySet)
        {
            Id = id;
            Name = name;
            Region = region;
            BoundarySet = boundarySet;
            VoteCount = new VoteCount(electorate);
        }

        public string Id { get; }
        public string Name { get; }
        public string Region { get; }
        public string BoundarySet { get; }
        public VoteCount VoteCount { get; }

        public void AddVotes(VotePile pile) => VoteCount.AddPile(pile);

        public override string ToString() => $"{Name} - Winner: {VoteCount.Piles.OrderBy(x => x.Count).Last()}";
    }
}