using CommandLine;
using sln.add.csproj.CommandLine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace sln.add.csproj
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    var solutionFiles = SearchSolutionFiles();

                    if (!solutionFiles.Any())
                    {
                        Console.Error.WriteLine("No solution file *.sln were found in the current directory.");
                        return;
                    }

                    if (solutionFiles.Count() > 1)
                    {
                        Console.Error.WriteLine("This tool does not support multiple solutions in the same directory. (in the roadmap)");
                        return;
                    }

                    var projectFiles = SearchProjectFiles();
                    if (o.Verbose)
                    {
                        Console.WriteLine("Project files will be added to the solution :");
                        foreach (var projectFile in projectFiles)
                        {
                            Console.WriteLine($" - {projectFile}");
                        }
                    }
                    var projectPaths = string.Join(' ', projectFiles);
                    AddProjetToSolution(solutionFiles.First(), projectPaths);
                });
        }

        private static IEnumerable<string> SearchSolutionFiles()
            => Directory.EnumerateFiles(Environment.CurrentDirectory, "*.sln", SearchOption.TopDirectoryOnly);

        private static IEnumerable<string> SearchProjectFiles()
            => Directory
                .EnumerateFiles(Environment.CurrentDirectory, "*.csproj", SearchOption.AllDirectories)
                .Select(project =>
                {
                    return project.Replace($"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}", string.Empty);
                });

        private static void AddProjetToSolution(string solutionFile, string projectPath)
        {
            var si = new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = "dotnet",
                Arguments = $"sln {solutionFile} add {projectPath}",
                UseShellExecute = false
            };
            Process.Start(si);
        }
    }
}
