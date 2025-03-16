using UserActivities.Core.ValueObjects;

namespace UserActivities.Core.Models
{
    public class UserActivity
    {
        public int Id { get; set; }
        public List<MouseMovement> MouseMoves { get; set; } = new List<MouseMovement>();
    }
}
