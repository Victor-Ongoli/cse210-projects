using System;

namespace EternalQuest
{
    public class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        public string GetName() { return _name; }
        public string GetDescription() { return _description; }
        public int GetPoints() { return _points; }

        public virtual int RecordEvent()
        {
            return _points;
        }

        public virtual bool IsComplete()
        {
            return false;
        }

        public virtual string GetDetailsString()
        {
            string checkbox = IsComplete() ? "[X]" : "[ ]";
            return $"{checkbox} {_name} ({_description})";
        }

        public virtual string GetStringRepresentation()
        {
            return $"Goal:{_name}|{_description}|{_points}";
        }
    }
}