using System.Diagnostics;

namespace Ow.DataSource.CommonsLibrary
{
    [DebuggerDisplay("{ToString()}")]
    public class VotePile
    {
        public VotePile(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public string Name { get; }
        public int Count { get; }

        public override string ToString() => $"Name: {Name}, Count: {Count}";
    }
}