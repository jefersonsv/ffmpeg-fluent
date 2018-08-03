using System;
using System.Text;
using System.Threading.Tasks;

namespace FFmpegFluent
{
    public class Builder
    {
        readonly FFmpeg ffmped = new FFmpeg();

        public static Builder Create()
        {
            return new Builder();
        }

        public Builder AddLocalExecutable()
        {
            ffmped.AddLocalExecutable = true;
            return this;
        }
        
        public Builder GlobalOptions(string globalOptions)
        {
            ffmped.GlobalOptions = globalOptions;
            return this;
        }

        public Builder InputFileOptions(string inputFileOptions)
        {
            ffmped.InputFileOptions = inputFileOptions;
            return this;
        }

        public Builder InputFile(string inputFile)
        {
            ffmped.InputFile = inputFile;
            return this;
        }

        public Builder OutputFileOptions(string inputFileOptions)
        {
            ffmped.OutputFileOptions = inputFileOptions;
            return this;
        }

        public Builder OutputFile(string outputFile)
        {
            ffmped.OutputFile = outputFile;
            return this;
        }

        public override string ToString()
        {
            return ffmped.ToString();
        }

        public void Run()
        {
            ffmped.Run();
        }

        public async Task RunAsync()
        {
            await ffmped.RunAsync();
        }

        public void RunAndForget()
        {
            ffmped.RunAndForget();
        }
    }
}
