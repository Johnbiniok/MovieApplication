using System;
using System.IO;

namespace MovieApplication
{
    class Program
    {
        private static String file = @"movies.csv";

        static void Main(string[] args)
        {

        //string file = @"movies.csv";
                String userOption1;

                do
                {
                    Console.WriteLine("1.Read all movies ");
                    Console.WriteLine("2.Add a movie ");
                    Console.WriteLine("3.Select a genre ");
                    Console.WriteLine("4.Exit ");
                    userOption1 = Console.ReadLine();
                    switch (userOption1)
                    {
                        //read all movie info
                        case "1":
                            readFromFile();
                            break;
                        //add a movie to the file
                        case "2":
                            writeToFile();
                            break;
                        //select a genre
                        case "3":
                            Console.WriteLine("What genre do you want to search for? ");
                            string userGenre = Console.ReadLine();
                            forGenre(userGenre);
                            break;
                        //quit
                        case "4":
                            Console.WriteLine("GoodBye! ");
                            continue;
                    }

                } while (userOption1 != "4");

        }

        static void writeToFile()
        {
            int movieID = 0;
            String title = "";
            String genres = "";
            Console.WriteLine("Enter the Movie ID: ");
            movieID = Console.Read();
            Console.ReadLine();
            Console.WriteLine("Enter the movie title: ");
            title = Console.ReadLine();
            Console.WriteLine("Enter the genres");
            genres = Console.ReadLine();
            using (FileStream fs = new FileStream(file, FileMode.Append, FileAccess.Write))
            {
                using TextWriter tw = new StreamWriter(fs);

                tw.WriteLine("{0},{1},{2}", movieID, title, genres);

            }
            Console.WriteLine("Successfully added to file.");

        }

        static void readFromFile()
        {
            if (File.Exists(file))
            {
                // read data from file
                StreamReader sr = new StreamReader(file);
                while (!sr.EndOfStream)
                {
                    String theLine = sr.ReadLine();
                    // convert string to array
                    String[] arr = theLine.Split(',');
                    // display array data
                    Console.WriteLine($"{arr[0],-10}    {arr[1],-60}    {arr[2],0}");

                }

            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }

        static void forGenre(string genre)
        {
            if (File.Exists(file))
            {
                // read data from file
                StreamReader sr = new StreamReader(file);
                while (!sr.EndOfStream)
                {
                    string theLine = sr.ReadLine();
                    // convert string to array
                    string[] data = theLine.Split(',');
                    // display array data
                    try
                    {
                        if (data[2].Contains(genre))
                        {
                            Console.WriteLine($"{data[0],-10}    {data[1],-60}    {data[2],0}");
                        }
                        else
                        {

                        }

                    }
                    catch(IndexOutOfRangeException i)
                    {
                    }

                }

            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }


    }
}