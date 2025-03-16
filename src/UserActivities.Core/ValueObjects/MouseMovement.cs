
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;

namespace UserActivities.Core.ValueObjects
{
    public class MouseMovement : ValueObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DateTime Time { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return X;
            yield return Y;
            yield return Time;
        }
    }
}
