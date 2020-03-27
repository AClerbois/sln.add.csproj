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
                    var app = new ApplicationBuilder()
                        .ConfigureFromOptions(o)
                        .Build();
                    app.Run();
                });
        }
    }
}
