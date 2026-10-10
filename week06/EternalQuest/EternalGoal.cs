namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            return _points;
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{_name}|{_description}|{_points}";
        }
    }
}