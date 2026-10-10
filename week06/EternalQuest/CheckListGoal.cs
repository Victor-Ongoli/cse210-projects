namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _target;
        private int _bonus;
        private int _amountCompleted;

        public ChecklistGoal(string name, string description, int points,
                             int target, int bonus, int amountCompleted = 0)
            : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = amountCompleted;
        }

        public override int RecordEvent()
        {
            _amountCompleted++;
            int earned = _points;

            // Bonus on the final completion.
            if (_amountCompleted == _target)
            {
                earned += _bonus;
            }

            return earned;
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            string checkbox = IsComplete() ? "[X]" : "[ ]";
            return $"{checkbox} {_name} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_name}|{_description}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
        }
    }
}