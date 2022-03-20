using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Ow.DataSource.CommonsLibrary
{
    [DebuggerDisplay("{ToString()}")]
    public class VoteCount
    {
        public VoteCount(string electorate)
        {
            Electorate = electorate;
        }

        public string Electorate { get; }
        public IEnumerable<VotePile> Piles => PilesInternal;
        private List<VotePile> PilesInternal { get; } = new();
        public void AddPile(VotePile pile) => PilesInternal.Add(pile);
        
        public override string ToString() => Piles.Aggregate(new StringBuilder(), (b, v) => b.Append($", {v}"), a => a.Remove(0, 2).ToString());
    }
}