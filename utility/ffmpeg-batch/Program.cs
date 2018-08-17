using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Services;
using Colorful;
using CommandLineParser.Arguments;
using CommandLineParser.Exceptions;
using Microsoft.Extensions.FileSystemGlobbing;
using Console = Colorful.Console;

namespace FFmpegBatch
{
    public class Program
    {
        static void Main(string[] args)
        {
            var desc = "FFmpeg batch";

            var fontArr = System.Text.Encoding.Default.GetBytes(ContessaFont.CONTESSA);
            FigletFont font = FigletFont.Load(fontArr);
            Figlet figlet = new Figlet(font);
            Console.WriteLine(figlet.ToAscii(desc), Color.Blue);

            ValueArgument<string> source = new ValueArgument<string>(
                's', "source", "Specify the path and search pattern of source files");
            source.Optional = false;

            ValueArgument<string> output = new ValueArgument<string>(
                'o', "output", "Specify the output format extension");
            output.Optional = false;

            var parser = new CommandLineParser.CommandLineParser();
            parser.Arguments.Add(source);
            parser.Arguments.Add(output);

            Console.WriteFormatted("Convert multiple audio and video files using ", Color.White);
            Console.WriteLineFormatted("FFmpeg", Color.Green);

            try
            {
                parser.ParseCommandLine(args);

                Run(source.Value, output.Value).Wait();
                Environment.Exit(0);
            }
            catch (CommandLineException e)
            {
                parser.ShowUsage();

                Console.WriteLine("Examples:");
                Console.WriteLine(string.Empty);
                Console.WriteLine($@"        > To convert all wav files in currenty folder (and sub-directories recursivelly) and convert to mp3 format");
                Console.WriteLineFormatted($@"        ffmpeg-batch -s /**/*.wav -o mp3", Color.Green);
                Console.WriteLine(string.Empty);
                Console.WriteLine($@"        > To convert all wma files in c:\music and convert to mp3 format");
                Console.WriteLineFormatted($@"        ffmpeg-batch -s c:\music\*.wma -o mp3", Color.Green);

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Install/Uninstall tool:");
                Console.WriteLine(string.Empty);
                Console.WriteLine($@"        > To install tool from system");
                Console.WriteLineFormatted($@"        dotnet tool install -g ffmpeg-batch", Color.Green);
                Console.WriteLine(string.Empty);
                Console.WriteLine($@"        > To uninstall tool from system");
                Console.WriteLineFormatted($@"        dotnet tool uninstall -g ffmpeg-batch", Color.Green);

                Environment.Exit(1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error executing utility");
                Console.WriteLine(e.ToString());
                Environment.Exit(2);
            }
        }

        static async Task Run(string source, string output)
        {
            // Split volume
            var volumePathSplited = DevCore.IO.SplitVolumePath(source);

            Matcher matcher = new Matcher(StringComparison.InvariantCultureIgnoreCase);
            matcher.AddInclude(volumePathSplited.Item2);

            var results = MatcherExtensions.GetResultsInFullPath(matcher, volumePathSplited.Item1 + System.IO.Path.DirectorySeparatorChar);

            Console.WriteLine(string.Empty);
            Console.WriteLineFormatted($@"Volume: {volumePathSplited.Item1}", Color.Green);
            Console.WriteLineFormatted($@"Path: {volumePathSplited.Item2}", Color.Green);
            Console.WriteLineFormatted($@"{results.Count()} files found", Color.Green);
            results.ToList().ForEach(e => Console.WriteLine(e));

            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var item in results)
            {
                using (var cli = new Cli("ffmpeg"))
                {
                    var destiny = Path.ChangeExtension(item, output);
                    var args = $@"-i ""{item}"" ""{destiny}""";

                    var handler = new BufferHandler(
                            stdOutLine => Console.WriteLine(stdOutLine),
                            stdErrLine => Console.WriteLine(stdErrLine));

                    Console.WriteLine(string.Empty);
                    Console.WriteFormatted($@"Executing: ", Color.Green);
                    Console.WriteLineFormatted($"ffmpeg {args}", Color.White);
                    Console.WriteLine(string.Empty);

                    await cli.ExecuteAsync(args, bufferHandler: handler);
                }
            }
            sw.Stop();

            if (results.Any())
            {
                Console.WriteLine(string.Empty);
                Console.Write($"The process has been executed in: ");
                Console.WriteFormatted($"{sw.Elapsed.TotalSeconds}", Color.Green);
                Console.WriteLine($" seconds.");
            }
        }
    }
}
