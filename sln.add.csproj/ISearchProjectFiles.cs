using System.Collections.Generic;

namespace sln.add.csproj
{
    public interface ISearchProjectFiles
    {
        IEnumerable<string> GetFiles();
    }
}