using CommandLine;

namespace sln.add.csproj.CommandLine
{
    public class Options
    {
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }
        [Option('i', "interactive", Required = false, HelpText = "Set interactive mode")]
        public bool Interactive { get; set; }
    }
}
