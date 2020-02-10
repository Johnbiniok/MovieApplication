using System;
using System.IO;

namespace MovieApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            string file = @"movies.csv";
                string userOption1;
                int movieID = 0;
                String title = "";
                String genres = "";

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
                            if (File.Exists(file))
                            {
                                // read data from file
                                StreamReader sr = new StreamReader(file);
                                while (!sr.EndOfStream)
                                {
                                    string theLine = sr.ReadLine();
                                    // convert string to array
                                    string[] arr = theLine.Split(',');
                                    // display array data
                                    Console.WriteLine($"{arr[0],-10}    {arr[1],-60}    {arr[2],0}");

                                }

                            }
                            else
                            {
                                Console.WriteLine("File does not exist");
                            }
                            break;
                        //add a movie to the file
                        case "2":
                            Console.WriteLine("Enter the Movie ID: ");
                            movieID = Console.Read();
                            Console.ReadLine();
                            Console.WriteLine("Enter the movie title: ");
                            title = Console.ReadLine();
                            Console.WriteLine("Enter the genres");
                            genres = Console.ReadLine();
                            Console.WriteLine("Movie ID        title        genres");
                            using (FileStream fs = new FileStream(file, FileMode.Append, FileAccess.Write))
                            {
                                using TextWriter tw = new StreamWriter(fs);

                                tw.WriteLine("{0}        {1}        {2}", movieID, title, genres);

                            }

                            break;
                        //select a genre
                        case "3":
                            break;
                        case "4":
                            break;
                    }
                    /*String[] userFull = new string[7];
                    if (userStart.Equals("Y") || userStart.Equals("y"))
                    {

                        Console.Write("Enter ticket ID: ");
                        ticketID = Console.Read();
                        Console.ReadLine();
                        Console.Write("Enter a summary: ");
                        summary = Console.ReadLine();
                        Console.Write("Enter a status: ");
                        status = Console.ReadLine();
                        Console.Write("Enter priority: ");
                        priority = Console.ReadLine();
                        Console.Write("Enter submitter name: ");
                        submitter = Console.ReadLine();

                        Console.Write("Names of assigned: ");
                        assigned = Console.ReadLine();

                        Console.Write("Name of watching: ");
                        watching = Console.ReadLine();


                        using (FileStream fs = new FileStream(file, FileMode.Append, FileAccess.Write))
                        {
                            using TextWriter tw = new StreamWriter(fs);

                            tw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketID, summary, status, priority, submitter,
                                assigned, watching);

                        }
                    }*/

                }while (userOption1 == "1" || userOption1 == "2" || userOption1 == "3");
                if (File.Exists(file))
                {
                    // read data from file
                    StreamReader sr = new StreamReader(file);
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        // convert string to array
                        string[] arr = line.Split(',');
                        // display array data
                        Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", arr[0], arr[1], arr[2]));

                    }

                }
                else
                {
                    Console.WriteLine("File does not exist");
                }



        }


    }
}