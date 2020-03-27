using System;
using sln.add.csproj.CommandLine;

namespace sln.add.csproj
{
    public class ApplicationBuilder
    {
        private Options opt;
        public ApplicationBuilder ConfigureFromOptions(Options opt)
        {
            this.opt = opt;
            return this;
        }
        public Application Build()
        {
            if (opt == default)
            {
                throw new InvalidOperationException("Missing options to run");
            }
            ISearchProjectFiles fileSearcher;
            if (opt.Interactive)
            {
                fileSearcher = new AskSearchProjectFiles();
            }
            else
            {
                fileSearcher = new AllSearchProjectFiles();
            }

            return new Application(opt, fileSearcher, new ProjectAdder());
        }
    }
}