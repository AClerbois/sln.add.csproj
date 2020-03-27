using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using sln.add.csproj.CommandLine;

namespace sln.add.csproj
{
    public class Application
    {
        private readonly Options options;
        private readonly ISearchProjectFiles searchProjectFiles;
        private readonly IProjectAdder projectAdder;
        public Application(Options options, ISearchProjectFiles searchProjectFiles, IProjectAdder projectAdder)
        {
            this.options = options;
            this.searchProjectFiles = searchProjectFiles;
            this.projectAdder = projectAdder;
        }
        public int Run()
        {
            var solutionFiles = SearchSolutionFiles();
            if (!IsValid(solutionFiles))
            {
                return -1;
            }
            var projects = searchProjectFiles.GetFiles();
            projectAdder.AddProjectToSln(solutionFiles.First(), projects);
            return 1;
        }

        private static IEnumerable<string> SearchSolutionFiles()
            => Directory.EnumerateFiles(Environment.CurrentDirectory, "*.sln", SearchOption.TopDirectoryOnly);

        private bool IsValid(IEnumerable<string> solutionFiles)
        {
            if (!solutionFiles.Any())
            {
                Console.Error.WriteLine("No solution file *.sln were found in the current directory.");
                return false;
            }

            if (solutionFiles.Count() > 1)
            {
                Console.Error.WriteLine("This tool does not support multiple solutions in the same directory. (in the roadmap)");
                return false;
            }
            return true;
        }

    }
}