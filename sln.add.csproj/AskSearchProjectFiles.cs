using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace sln.add.csproj
{
    public class AskSearchProjectFiles : ISearchProjectFiles
    {
        private AllSearchProjectFiles allProjectFiles;
        public AskSearchProjectFiles()
        {
            allProjectFiles = new AllSearchProjectFiles();
        }
        public IEnumerable<string> GetFiles()
        {
            Console.WriteLine("In AskSearchProjectFiles");
            return allProjectFiles
                .GetFiles()
                .Where(projectFile =>
                {
                    Console.WriteLine($"Add - {projectFile} ? ");
                    var input = Console.ReadLine();
                    return input != null && input.Equals("y", StringComparison.InvariantCultureIgnoreCase);
                }).ToList();
        }
    }
}