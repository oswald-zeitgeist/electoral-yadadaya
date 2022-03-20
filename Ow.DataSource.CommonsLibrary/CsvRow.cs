using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Ow.DataSource.CommonsLibrary
{
    public class CsvRow
    {
        private readonly IList<string> data;

        public CsvRow(IList<string> data)
        {
            this.data = data;
        }

        private string Get(int index) => data[index];

        public string ConstitencyId => Get(0);
        public string Seats => Get(1);
        public string ConstituencyName => Get(2);
        public string Region => Get(3);
        public string Electorate => Get(4);
        public string ConVotes => Get(5);
        public string ConShare => Get(6);
        public string LibVotes => Get(7);
        public string LibShare => Get(8);
        public string LabVotes => Get(9);
        public string LabShare => Get(10);
        public string NatSwVotes => Get(11);
        public string NatSwShare => Get(12);
        public string OthVotes => Get(13);
        public string OthShare => Get(14);
        public string TotalVotes => Get(15);
        public string Turnout => Get(16);
        public string ElectionId => Get(17);
        public string BoundarySet => Get(18);

        public override string ToString() => data.Aggregate(new StringBuilder(), (b, v) => b.Append($",{v}"), a => a.Remove(0, 2).ToString());
    }
}