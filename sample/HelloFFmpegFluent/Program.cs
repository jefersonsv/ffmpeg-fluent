using System;
using System.IO;

namespace HelloFFmpegFluent
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\data\pen drive\English\00-11 Oxford Bookworms Library\03 Goodbye, Mr Hollywood";

            FFmpegFluent.Builder
                .Create()
                .AddLocalExecutable()
                .InputFile(Path.Combine(path, "04 Дорожка 4.wma"))
                .OutputFile(Path.Combine(path, "04 Дорожка 4.mp3"))
                .RunAndForget();

            Console.WriteLine("Hello World!");
        }
    }
}
