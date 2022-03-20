using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Ow.DataSource.CommonsLibrary
{
    public class CommonsLibraryCsvReader
    {
        private readonly string filePath;
        private readonly IDictionary<string, Election> elections = new Dictionary<string, Election>();

        public CommonsLibraryCsvReader(string filePath)
        {
            this.filePath = filePath;
        }

        public IEnumerable<Election> Read()
        {
            var reader = new CsvReader(filePath);
            var rows = reader.GetAll();
            int rowCount = 0;
            foreach (var row in rows)
            {
                var election = GetOrCreateElection(row);
                var seat = new ConstituencyResult(
                    row.ConstitencyId,
                    row.Electorate,
                    row.ConstituencyName,
                    row.Region,
                    row.BoundarySet);
                if(!CommonsLibraryExcelDatasource.IsNullOrEmpty(row.ConVotes)) seat.AddVotes(new VotePile("Conservative", ConvertToIntInternal(row.ConVotes, nameof(row.ConVotes), rowCount)));
                if(!CommonsLibraryExcelDatasource.IsNullOrEmpty(row.LibVotes)) seat.AddVotes(new VotePile("Liberal", ConvertToIntInternal(row.LibVotes, nameof(row.LibVotes), rowCount)));
                if(!CommonsLibraryExcelDatasource.IsNullOrEmpty(row.LabVotes)) seat.AddVotes(new VotePile("Labour", ConvertToIntInternal(row.LabVotes, nameof(row.LabVotes), rowCount)));
                if(!CommonsLibraryExcelDatasource.IsNullOrEmpty(row.NatSwVotes)) seat.AddVotes(new VotePile("NatSw", ConvertToIntInternal(row.NatSwVotes, nameof(row.NatSwVotes), rowCount)));
                if(!CommonsLibraryExcelDatasource.IsNullOrEmpty(row.OthVotes)) seat.AddVotes(new VotePile("Other", ConvertToIntInternal(row.OthVotes, nameof(row.OthVotes), rowCount)));
                election.AddSeat(seat);
                rowCount++;
            }

            return elections.Values.ToList();
        }

        private int ConvertToIntInternal(string candidate, string source, int rowCount)
        {
            if (int.TryParse(candidate, out var result)) return result;
            throw new InvalidOperationException($"couldn't convert value in {source} on row: {rowCount} from {candidate} into a number");
        }

        private Election GetOrCreateElection(CsvRow row)
        {
            if (!elections.TryGetValue(row.ElectionId, out var election))
            {
                election = new Election(row.ElectionId);
                elections.Add(row.ElectionId, election);
            }
            return election;
        }
    }
}