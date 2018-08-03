using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FFmpegFluent
{
    /// <summary>
    /// <see cref="https://ffmpeg.org/"/>
    /// </summary>
    internal class FFmpeg
    {
        internal bool AddLocalExecutable { get; set; }
        internal string GlobalOptions { get; set; }
        internal string InputFileOptions { get; set; }
        internal string InputFile { get; set; }
        internal string OutputFileOptions { get; set; }
        internal string OutputFile { get; set; }

        public void Run()
        {
            this.AddLocalExecutable = false;
            var args = this.ToString();
            var settings = new CliWrap.Models.CliSettings
            {
                Encoding = new CliWrap.Models.EncodingSettings(System.Text.Encoding.UTF8)
            };

            using (var cli = new CliWrap.Cli("ffmpeg", settings))
            {
                cli.Execute(args);
            }
        }

        public async Task RunAsync()
        {
            this.AddLocalExecutable = false;
            var args = this.ToString();
            var settings = new CliWrap.Models.CliSettings
            {
                Encoding = new CliWrap.Models.EncodingSettings(System.Text.Encoding.UTF8)
            };

            using (var cli = new CliWrap.Cli("ffmpeg", settings))
            {
                await cli.ExecuteAsync(args);
            }
        }

        public void RunAndForget()
        {
            this.AddLocalExecutable = false;
            var args = this.ToString();
            var settings = new CliWrap.Models.CliSettings
            {
                Encoding = new CliWrap.Models.EncodingSettings(System.Text.Encoding.UTF8)
            };

            using (var cli = new CliWrap.Cli("ffmpeg", settings))
            {
                cli.ExecuteAndForget(args);
            }
        }

        public override string ToString()
        {
            // ffmpeg [global_options] {[input_file_options] -i input_url} ... {[output_file_options] output_url} ... 
            StringBuilder sb = new StringBuilder();
            if (AddLocalExecutable)
                sb.Append($@" ffmpeg");

            if (!string.IsNullOrEmpty(GlobalOptions))
                sb.Append($@" {GlobalOptions}");

            if (!string.IsNullOrEmpty(InputFileOptions))
                sb.Append($@" {InputFileOptions}");

            if (!string.IsNullOrEmpty(InputFile))
                sb.Append($@" -i ""{InputFile}""");

            if (!string.IsNullOrEmpty(OutputFileOptions))
                sb.Append($@" {OutputFileOptions}");

            if (!string.IsNullOrEmpty(OutputFile))
                sb.Append($@" ""{OutputFile}""");

            return sb.ToString().Trim();
        }
    }
}
