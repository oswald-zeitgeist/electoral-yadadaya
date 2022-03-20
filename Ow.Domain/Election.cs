using System.Collections.Generic;
using System.Diagnostics;

namespace Ow.DataSource.CommonsLibrary
{
    [DebuggerDisplay("{ToString()}")]
    public class Election : IIdentifiable<string>
    {
        public Election(string id)
        {
            Id = id;
        }

        public string Id { get; }
        public IEnumerable<ConstituencyResult> Seats => SeatsInternal;
        private List<ConstituencyResult> SeatsInternal { get; } = new();
        public void AddSeat(ConstituencyResult constituencyResult) => SeatsInternal.Add(constituencyResult);

        public override string ToString() => Id;
    }
}