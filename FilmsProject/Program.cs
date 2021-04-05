using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject
{
    class Program
    {
        // VARIABLE DECLARATION
        public static Index index = new Index();
        public static bool filmsToAdd = true;

        // ***********************************************************************
        // MAIN
        static void Main(string[] args)
        {
            index.films = new List<Film>();

            Console.WriteLine("What would you like to do?");
            string answer = Console.ReadLine().ToLower();
            switch (answer)
            {
                case "list":
                    ListFilms(index.films);
                    break;
                case "ls":
                    ListFilms(index.films);
                    break;
                case "add":
                    AddFilms();
                    break;
                default:
                    Console.WriteLine("Case not recognised");
                    Console.Read();
                    break;
            }                                   

            ListFilms(index.films);

            Console.Read();
        }


        // ***********************************************************************
        // ADD FILMS METHODS
        private static void InputFilm()
        {
            Film newFilm = new Film();
            Console.Clear();
            Console.WriteLine("Enter the film's name:");
            newFilm.filmName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("In which year do you think you viewed this?");
            newFilm.yearViewed = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please write a few words about it:");
            newFilm.yearViewed = Console.ReadLine();
            index.films.Add(newFilm);
            Console.Clear();
            Console.WriteLine("Film added to index");
        }

        private static void CheckForMore()
        {
            Console.WriteLine("Would you like to add any more?");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                filmsToAdd = true;
            }
            else
            {
                filmsToAdd = false;
            }
        }

        private static void AddFilms()
        {
            while (filmsToAdd)
            {
                InputFilm();
                CheckForMore();
            }
        }


        // ***********************************************************************
        // LIST FILMS METHOD
        private static void ListFilms(List<Film> films)
        {
            Console.Clear();
            Console.WriteLine("Your films:");
            try
            {
                foreach (Film film in films)
                {
                    Console.WriteLine(film.filmName);
                }
            }
            catch
            {
                Console.WriteLine("Error: was unable to list films");
                Console.Read();
            }
        }

    }

    [System.Serializable]
    struct Film
    {
        public string filmName;
        public string yearViewed;
        public string description;

        public Film(string filmName, string yearViewed, string description)
        {
            this.filmName = filmName;
            this.yearViewed = yearViewed;
            this.description = description;
        }
    }

    [System.Serializable]
    struct Index
    {
        public List<Film> films;

        public Index(List<Film> films)
        {
            this.films = films;
        }
    }
}
