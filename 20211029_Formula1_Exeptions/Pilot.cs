using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20211019_Formula1
{
    class Pilot
    {
        private string _name;
        private int _age;
        private Team _team;         // Team or string
        private int[] _points = new int[20];

        public string Name {get => _name; set=>_name=value;}
        public int Age { get => _age; set => _age = value; }
        public Team TeamName { get => _team; set => _team = value; }
        public int[] Points { get => _points; set => _points = value; }

        public Pilot() { }
        public Pilot(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public override string ToString()
        {
            return $"{_name} {_age} years from {_team.Title} team ({_points.Sum()} points in current Season)";
        }
    }
}
