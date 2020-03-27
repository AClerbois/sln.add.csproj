using System.Collections.Generic;

namespace sln.add.csproj
{
    public interface IProjectAdder
    {
        void AddProjectToSln(string solutionFile, IEnumerable<string> listOfProjectsToAdd);
    }
}