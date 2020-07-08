using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MarsRover
{
    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Header { get; set; }

        public string Run(string command)
        {
            for (int c = 0; c < command.Length; ++c)
            {

                if (command[c] == 'M')
                {
                    if (Header == "N")
                    {
                        Y += 1;
                    }
                    else if (Header == "W")
                    {
                        X -= 1;
                    }
                    else if (Header == "S")
                    {
                        Y -= 1;
                    }
                    else if (Header == "E")
                    {
                        X += 1;
                    }
                }
                else
                {
                    var destination = command[c];
                    if (Header == "N")
                    {
                        if (destination == 'L')
                        {
                            Header = "W";
                        }
                        else if (destination == 'R')
                        {
                            Header = "E";
                        }

                    }
                    else if (Header == "W")
                    {
                        if (destination == 'L')
                        {
                            Header = "S";
                        }
                        else if (destination == 'R')
                        {
                            Header = "N";
                        }
                    }
                    else if (Header == "E")
                    {
                        if (destination == 'L')
                        {
                            Header = "N";
                        }
                        else if (destination == 'R')
                        {
                            Header = "S";
                        }
                    }
                    else if (Header == "S")
                    {
                        if (destination == 'L')
                        {
                            Header = "E";
                        }
                        else if (destination == 'R')
                        {
                            Header = "W";
                        }
                    }
                }
            }
            return this.X + " " + this.Y + " " + this.Header; 
        }
    }
    public class MainClass
    {

        public static void WriteRovers(List<Rover> rovers)
        {
            foreach (var item in rovers)
            {
                Console.WriteLine(item.X + " " + item.Y + " " + item.Header);
            }
        }
        public static void WriteCommands(List<string> commands)
        {
            foreach (var item in commands)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(String[] args)
        {
            string line;
            string filePath = "..\\..\\..\\..\\Mars Rover.rtf";
            StreamReader file = new StreamReader(filePath);
            int lineIndex = 0;
            string rightTop = "";
            List<Rover> rovers = new List<Rover>();
            List<string> commands = new List<string>();
            /* 
             * Read the file at first
             */
            while ((line = file.ReadLine()) != null)
            {
                if (lineIndex == 0)
                {
                    rightTop = line;
                }
                else
                {
                    if (lineIndex % 2 == 1) //this is first line per rover
                    {
                        var words = line.Split(' ');
                        var x = words[0];
                        var y = words[1];
                        var h = words[2];
                        Rover rover = new Rover();
                        rover.X = Int32.Parse(x);
                        rover.Y = Int32.Parse(y);
                        rover.Header = h.ToString();
                        rovers.Add(rover);
                    }
                    else if (lineIndex % 2 == 0) //this is second line per rover
                    {
                        commands.Add(line);
                    }
                }
                lineIndex++;
            }
            file.Close();
            /*
             * Move the rovers
             * 
             * 
             * 
             */
            for (int i = 0; i < commands.Count; ++i)
            {
                var rover = rovers[i];
                var command = commands[i];
                var output = rover.Run(command);
            }
            /*
             * Output the rovers
             */
            WriteRovers(rovers);
        }
    }
}
