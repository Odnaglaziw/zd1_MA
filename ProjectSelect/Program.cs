using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ProjectSelect
{
    internal class Program
    {
        static readonly string path2Projects = @"..\..\..\projects.txt";
        static List<Project> projects = new List<Project>();
        static void Main(string[] args)
        {
            CursorVisible = false;
            ReadProjects();
            int selected = 0;
            while (true)
            {
                WriteLine("Стрелки и W,S");
                WriteLine("Выберите проект:");
                for (int i = 0; i < projects.Count; i++)
                {
                    if (i == selected)
                    {
                        ForegroundColor = ConsoleColor.Black;
                        BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        ResetColor();
                    }
                    WriteLine(projects[i].Name);
                }
                switch (ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        {
                            RunProject(projects[selected].path);
                        }
                        break;
                    case ConsoleKey.W:
                        {
                            if (--selected < 0)
                            {
                                selected = 0;
                            }
                        }
                        break;
                    case ConsoleKey.S:
                        {
                            if (++selected >= projects.Count)
                            {
                                selected--;
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        {
                            if (--selected < 0)
                            {
                                selected = 0;
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        {
                            if (++selected >= projects.Count)
                            {
                                selected--;
                            }
                        }
                        break;
                    default: { } break;
                }
                ResetColor();
                Clear();
            }
        }
        static void ReadProjects()
        {
            string[] lines = File.ReadAllLines(path2Projects);
            foreach (string line in lines)
            {
                string[] parts = line.Split(new char[] { ';' });
                projects.Add(new Project { Name = parts[0], path = parts[1] });
            }
        }
        static void RunProject(string projectPath)
        {
            try
            {
                Process.Start(projectPath);
                Console.WriteLine($"Проект {projectPath} запущен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запуске проекта: {ex.Message}");
            }
        }
    }
    internal struct Project
    {
        public string Name;
        public string path;
    }
}
