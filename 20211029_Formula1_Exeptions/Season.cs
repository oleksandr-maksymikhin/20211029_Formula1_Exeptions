using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20211019_Formula1
{
    class Season
    {
        private int _year;
        private Team[] _teams;
        private int _raceNumber;

        public int Year {get => _year; set => _year = value; }
        public Team[] Teams { get => _teams; set => _teams = value; }
        public int RaceNumber { get => _raceNumber; set => _raceNumber = value; }

        public Season() { }
        public Season (int year, Team[] teams, int raceNumber)
        {
            _year = year;
            _teams = teams;
            _raceNumber = raceNumber;
        }

        void Race()
        {

        }
    }
}
