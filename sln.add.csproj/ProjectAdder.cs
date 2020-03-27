using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace sln.add.csproj
{
    public class ProjectAdder : IProjectAdder
    {
        public void AddProjectToSln(string solutionFile, IEnumerable<string> listOfProjectsToAdd)
        {
            NotifyProjects(listOfProjectsToAdd);
            var projectPaths = string.Join(' ', listOfProjectsToAdd);
            var si = new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = "dotnet",
                Arguments = $"sln {solutionFile} add {projectPaths}",
                UseShellExecute = false
            };
            Process.Start(si);
        }

        private void NotifyProjects(IEnumerable<string> listOfProjectsToAdd)
        {
            Console.WriteLine("Project files will be added to the solution :");
            foreach (var projectFile in listOfProjectsToAdd)
            {
                Console.WriteLine($" - {projectFile}");
            }
        }
    }
}