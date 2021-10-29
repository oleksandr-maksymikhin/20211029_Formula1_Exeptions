using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20211019_Formula1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
Написать программу, позволяющую просматривать информацию о чемпионате формулы 
1. Реализовать следующие классы:
Pilot:
    Поля:
        ▪ name;
        ▪ age;
        ▪ team;
        ▪ points[20].
Team:
    Поля:
        ▪ title
        ▪ pilot1;
        ▪ pilot2.
Season:
    Поля:
        ▪ year;
        ▪ teams[10].
        ▪ raceNumber
    Методы:
        ▪ void Race() - распределяет очки за гонку между пилотами.
        ▪ Pilot Leader() - возвращает текущего лидера чемпионата.
        ▪ Pilot GetPilot(int pos) - возвращает пилота, который занимает pos позицию в турнирной таблице.
        ▪ int GetPoints(Pilot) - возвращает текущее количество очков определенного пилота.
        ▪ double GetAvgPoints(Pilot) - возвращает среднее арифметическое количество очков определенного пилота.
Во всех методах предусмотреть обработку исключительных ситуаций. 
             */

            Pilot LewisHamilton = new Pilot("Lewis Hamilton", 36);
            Pilot ValtteriBottas = new Pilot("Valtteri Bottas", 32);
            Team MERCEDES = new Team("MERCEDES");
            MERCEDES.Pilot1 = LewisHamilton;
            MERCEDES.Pilot2 = ValtteriBottas;
            Console.WriteLine(LewisHamilton);
            Console.WriteLine(MERCEDES);

            Pilot SergioPerez = new Pilot("Sergio Perez", 31);
            Pilot MaxVerstappen = new Pilot("Max Verstappen", 24);
            Team RED_BULL_RACING_HONDA = new Team("RED BULL RACING HONDA");
            RED_BULL_RACING_HONDA.Pilot1 = SergioPerez;
            RED_BULL_RACING_HONDA.Pilot2 = MaxVerstappen;

            Pilot DanielRicciardo = new Pilot("Daniel Ricciardo", 32);
            Pilot LandoNorris = new Pilot("Lando Norris", 21);
            Team MCLAREN_MERCEDES = new Team("MCLAREN MERCEDES");
            MCLAREN_MERCEDES.Pilot1 = DanielRicciardo;
            MCLAREN_MERCEDES.Pilot2 = LandoNorris;

            Pilot CharlesLeclerc = new Pilot("Charles Leclerc", 24);
            Pilot CarlosSainzJr = new Pilot("Carlos Sainz Jr", 27);
            Team FERRARI = new Team("FERRARI");
            FERRARI.Pilot1 = CharlesLeclerc;
            FERRARI.Pilot2 = CarlosSainzJr;

            Pilot FernandoAlonso = new Pilot("Fernando Alonso", 40);
            Pilot EstebanOcon = new Pilot("Esteban Ocon", 25);
            Team ALPINE_RENAULT = new Team("ALPINE RENAULT");
            ALPINE_RENAULT.Pilot1 = FernandoAlonso;
            ALPINE_RENAULT.Pilot2 = EstebanOcon;

            Pilot PierreGasly = new Pilot("Pierre Gasly", 25);
            Pilot YukiTsunoda = new Pilot("Yuki Tsunoda", 21);
            Team ALPHATAURI_HONDA = new Team("ALPHATAURI HONDA");
            ALPHATAURI_HONDA.Pilot1 = PierreGasly;
            ALPHATAURI_HONDA.Pilot2 = YukiTsunoda;

            Pilot SebastianVettel = new Pilot("Sebastian Vettel", 34);
            Pilot LanceStroll = new Pilot("Lance Stroll", 22);
            Team ASTON_MARTIN_MERCEDES = new Team("ASTON MARTIN MERCEDES");
            ASTON_MARTIN_MERCEDES.Pilot1 = SebastianVettel;
            ASTON_MARTIN_MERCEDES.Pilot2 = LanceStroll;

            Pilot NicholasLatifi = new Pilot("Nicholas Latifi", 26);
            Pilot GeorgeRussell = new Pilot("George Russell", 23);
            Team WILLIAMS_MERCEDES = new Team("WILLIAMS MERCEDES");
            WILLIAMS_MERCEDES.Pilot1 = NicholasLatifi;
            WILLIAMS_MERCEDES.Pilot2 = GeorgeRussell;

            Pilot AntonioGiovinazzi = new Pilot("Antonio Giovinazzi", 27);
            Pilot KimiRaikkonen = new Pilot("Kimi Raikkonen", 42);
            Team ALFA_ROMEO_RACING_FERRARI = new Team("ALFA ROMEO RACING FERRARI");
            ALFA_ROMEO_RACING_FERRARI.Pilot1 = AntonioGiovinazzi;
            ALFA_ROMEO_RACING_FERRARI.Pilot2 = KimiRaikkonen;

            Pilot NikitaMazepin = new Pilot("Nikita Mazepin", 22);
            Pilot MickSchumacher = new Pilot("Mick Schumacher", 22);
            Team HAAS_FERRARI = new Team("HAAS FERRARI");
            HAAS_FERRARI.Pilot1 = NikitaMazepin;
            HAAS_FERRARI.Pilot2 = MickSchumacher;

            Season _2021 = new Season(2021);
            _2021.AddTeam(MERCEDES);
            _2021.AddTeam(RED_BULL_RACING_HONDA);
            _2021.AddTeam(MCLAREN_MERCEDES);
            _2021.AddTeam(FERRARI);
            _2021.AddTeam(ALPINE_RENAULT);
            _2021.AddTeam(ALPHATAURI_HONDA);
            _2021.AddTeam(ASTON_MARTIN_MERCEDES);
            _2021.AddTeam(WILLIAMS_MERCEDES);
            _2021.AddTeam(ALFA_ROMEO_RACING_FERRARI);
            _2021.AddTeam(HAAS_FERRARI);

            Console.WriteLine("The list of teams in Season 2021");
            for (int i = 0; i < _2021.Teams.Length; i++)
            {
                Console.WriteLine(_2021.Teams[i]); 
            }


            Console.WriteLine("Test of void Race():");
            _2021.Race();
            _2021.PrintLastRaceResults();
            _2021.Race();
            _2021.PrintLastRaceResults();
            _2021.Race();
            _2021.PrintLastRaceResults();
            _2021.Race();
            _2021.PrintLastRaceResults();
            _2021.Race();
            _2021.PrintLastRaceResults();

            Console.WriteLine();

            Console.Write("\nCurrent leader -> ");
            Pilot leader = _2021.Leader();
            Console.WriteLine(leader);
            Console.WriteLine();

            Console.WriteLine("\nPoints of pilot.");
            int pointsOfPilot = _2021.GetPoints(SergioPerez);
            Console.Write($"Points of pilot {SergioPerez.Name} = {pointsOfPilot}");
            Console.WriteLine("\nverify function results");
            Console.WriteLine(SergioPerez);

            Console.WriteLine("\nArithmetic mean points of pilot.");
            double arithmeticMeanOfPilot = _2021.GetAvgPoints(SergioPerez);
            Console.WriteLine($"Arithmetic mean points of {SergioPerez.Name} = {arithmeticMeanOfPilot:f2} ");
            Console.WriteLine();

            Console.WriteLine("\nPlace of the pilot.");
            Console.WriteLine($"The first place -> {_2021.GetPilot(1)}");
            Console.WriteLine($"The second place -> {_2021.GetPilot(2)}");
            Console.WriteLine($"The third place -> {_2021.GetPilot(3)}");

            Console.WriteLine();
        }
    }
}
