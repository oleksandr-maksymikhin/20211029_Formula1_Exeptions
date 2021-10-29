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
        private Team[] _teams = new Team[10];
        private int _raceNumber = 0;
        Random rand = new Random();

        public int Year {get => _year; }
        public Team[] Teams 
        { 
            get => _teams;
        }
        public int RaceNumber { get => _raceNumber; set => _raceNumber = value; }

        public Season() { }
        public Season (int year)
        {
            _year = year;
        }

        public void AddTeam(Team obj)
        {
            int counter = 0;
            foreach (var team in _teams)
            {
                if (team == null)
                {
                    break;
                }
                counter++;
            }
            _teams[counter] = obj;
        }
        
        //Array of Pilot Method
        private Pilot[] ArrayOfPilots()
        {
            Pilot[] arrayOfPilots = new Pilot[_teams.Length * 2];
            for (int i = 0; i < arrayOfPilots.Length; i++)
            {
                if (i < 10)
                {
                    arrayOfPilots[i] = _teams[i].Pilot1;
                }
                else
                {
                    arrayOfPilots[i] = _teams[i - 10].Pilot2;
                }
            }
            return arrayOfPilots;
        }

        private void SortPilotArrayDescending(Pilot[] arrayOfPilots, int race)
        {
            for (int i = 0; i < arrayOfPilots.Length; i++)
            {
                bool flag = true;
                for (int j = 0; j < arrayOfPilots.Length - (i + 1); j++)
                {
                    if (arrayOfPilots[j].Points[race] < arrayOfPilots[j + 1].Points[race])
                    {
                        (arrayOfPilots[j], arrayOfPilots[j + 1]) = (arrayOfPilots[j + 1], arrayOfPilots[j]);
                        flag = false;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
        }

        //void Race() - распределяет очки за гонку между пилотами
        public void Race()
        {
            if (RaceNumber <= 20)                                           // add exception
            {

/*                Pilot[] arrayOfPilots = new Pilot[_teams.Length * 2];
                for (int i = 0; i < arrayOfPilots.Length * 2; i++)
                {
                    if (i < 10)
                    {
                        arrayOfPilots[i] = _teams[i].Pilot1;
                    }
                    else
                    {
                        arrayOfPilots[i] = _teams[i - 10].Pilot2;
                    }
                }*/

                Pilot[] arrayOfPilots = ArrayOfPilots();
/*                Console.WriteLine("\n\nThe list of teams in Season 2021 BEFORE shuffle");
                for (int i = 0; i < arrayOfPilots.Length; i++)
                {
                    Console.WriteLine(arrayOfPilots[i]);
                }*/

                //shuffle
                for (int i = arrayOfPilots.Length - 1; i > 0; i--)
                {
                    int j = rand.Next(i + 1);

                    Pilot tmp = arrayOfPilots[j];
                    arrayOfPilots[j] = arrayOfPilots[i];
                    arrayOfPilots[i] = tmp;
                }

                //to verify of shuffle loop
                /*                Console.WriteLine("\n\nThe list of teams in Season 2021 AFTER shuffle");
                                for (int i = 0; i < arrayOfPilots.Length; i++)
                                {
                                    Console.WriteLine(arrayOfPilots[i]);
                                }*/
                int[] racingPoints = new int[10] { 25, 18, 15, 12, 10, 8, 6, 4, 2, 1 };
                for (int i = 0; i < racingPoints.Length; i++)
                {
                    arrayOfPilots[i].Points[RaceNumber] = racingPoints[i];
                }

/*                Console.WriteLine($"Results of the race# {_raceNumber + 1}");
                for (int i = 0; i < arrayOfPilots.Length; i++)
                {
                    Console.WriteLine($"{ arrayOfPilots[i].Points[_raceNumber]} - {arrayOfPilots[i]}");
                }*/
                    _raceNumber++;
            }
            else
            {
                Console.WriteLine("Season is finished");
            }
        }

        //Pilot Leader() - возвращает текущего лидера чемпионата.
        public Pilot Leader()
        {
            if (RaceNumber == 0)
            {
                Console.WriteLine("There were no race in the season");                      // there should be exception
                return _teams[0].Pilot1;
            }
            else
            {
                Pilot leader = null;
                int leaderPoints = 0;

                Pilot[] arrayOfPilots = ArrayOfPilots();
                for (int i = 0; i < arrayOfPilots.Length; i++)
                {
                    int pilotPoints = 0;
                    for (int j = 0; j < _teams[0].Pilot1.Points.Length; j++)                    // magic figure 20 races -> need to replace with field value
                    {
                        pilotPoints += arrayOfPilots[i].Points[j];
                    }
                    if (pilotPoints > leaderPoints)
                    {
                        leader = arrayOfPilots[i];
                        leaderPoints = pilotPoints;
                    }
                }
                return leader;
            }
        }

        //Pilot GetPilot(int pos) - возвращает пилота, который занимает pos - позицию в турнирной таблице.
        public Pilot GetPilot(int pos)
        {
            Pilot pilot = null;
            Pilot[] arrayOfPilots = ArrayOfPilots();
            for (int i = 0; i < arrayOfPilots.Length; i++)
            {
                bool flag = true;
                for (int j = 0; j < arrayOfPilots.Length - (i + 1); j++)
                {
                    if (arrayOfPilots[j].Points.Sum() < arrayOfPilots[j+1].Points.Sum() )
                    {
                        (arrayOfPilots[j], arrayOfPilots[j+1]) = (arrayOfPilots[j+1], arrayOfPilots[j]);        //swap
                        flag = false;                                                                           //quit the loop if there were no repaces in the last cycle
                    }
                }
                if (flag)
                {
                    break;
                }
            }
            pilot = arrayOfPilots[pos - 1];                                                                     // array from - 0 / places from - 1
            return pilot;
        }

        // int GetPoints(Pilot) - возвращает текущее количество очков определенного пилота.
        public int GetPoints(Pilot pilot)
        {
            int points = 0;
            Pilot[] arrayOfPilots = ArrayOfPilots();
            for (int i = 0; i < arrayOfPilots.Length; i++)
            {
                if (arrayOfPilots[i] == pilot)                                  // there shoud be exception that Pilot is out of the Season
                {
                    return arrayOfPilots[i].Points.Sum();
                }
            }

            return points;
        }

        //double GetAvgPoints(Pilot) - возвращает среднее арифметическое количество очков определенного пилота.
        public double GetAvgPoints(Pilot pilot)
        {
            double average = 0;
            Pilot[] arrayOfPilots = ArrayOfPilots();
            for (int i = 0; i < arrayOfPilots.Length; i++)
            {
                if (arrayOfPilots[i] == pilot)
                {
                    double sumOfPoints = 0;
                    for (int j = 0; j < RaceNumber; j++)
                    {
                        sumOfPoints += arrayOfPilots[i].Points[j];
                    }
                    average = sumOfPoints / RaceNumber;
                    return average;
                }
            }
            return average;
        }

        public void PrintLastRaceResults()
        {
            Console.WriteLine($"Results of the race# {RaceNumber}");
            Pilot[] arrayOfPilots = ArrayOfPilots();
            SortPilotArrayDescending(arrayOfPilots, _raceNumber - 1);

            /*for (int i = 0; i < arrayOfPilots.Length; i++)
            {
                bool flag = true;
                for (int j = i; j < arrayOfPilots.Length - 1; j++)
                {
                    if (arrayOfPilots[j].Points[RaceNumber] < arrayOfPilots[j + 1].Points[RaceNumber])
                    {
                        (arrayOfPilots[j].Points[RaceNumber], arrayOfPilots[j + 1].Points[RaceNumber]) = (arrayOfPilots[j + 1].Points[RaceNumber], arrayOfPilots[j].Points[RaceNumber]);
                        flag = false;
                    }
                }
                if (flag)
                {
                    break;
                }
            }*/
            foreach (var pilot in arrayOfPilots)
            {
                Console.WriteLine($"{pilot.Points[RaceNumber - 1]} - {pilot}");
            }
        }
    }
}
