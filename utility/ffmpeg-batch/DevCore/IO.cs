using System;
using System.Collections.Generic;
using System.Text;

namespace FFmpegBatch.DevCore
{
    public static class IO
    {
        public static(string, string) SplitVolumePath(string dir)
        {
            var volumeIdx = dir.IndexOf(System.IO.Path.VolumeSeparatorChar);
            if (volumeIdx > -1)
            {
                // has drive
                var volume = dir.Substring(0, volumeIdx) + ":";
                var path = dir.Substring(volumeIdx + 1);

                return (volume, path);
            }
            else
            {
                var volume = SplitVolumePath(Environment.CurrentDirectory).Item1;
                var path = dir;

                return (volume, path);
            }
        }
    }
}
