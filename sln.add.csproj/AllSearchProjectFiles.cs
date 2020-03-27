using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace sln.add.csproj
{
    public class AllSearchProjectFiles : ISearchProjectFiles
    {
        public IEnumerable<string> GetFiles()
        {
            return Directory
                .EnumerateFiles(Environment.CurrentDirectory, "*.csproj", SearchOption.AllDirectories)
                .Select(project =>
                {
                    return project.Replace($"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}", string.Empty);
                });
        }
    }
}