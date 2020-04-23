using Office365EasyImporter.Models;
using System.Diagnostics;

namespace Office365EasyImporter
{
    static class UploadController
    {
        public static string GetCommand(AzCopyOption options)
        {
            var path = $"cd \"{options.AzCopyPath}\"";
            var copyCmd = $"azcopy /Source:\"{options.Source}\" /Dest:\"{options.Destination}\" /V:\"{options.LogFilePath}\" {(options.UseRecursiveMode ? "/S" : "")} /Y /NC:2";
            return $"{path}& {copyCmd}";
        }
        public static void UploadPsts(AzCopyOption options)
        {
            var command = GetCommand(options);

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.Arguments = $"/K {command}";
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.RedirectStandardOutput = false;
            cmd.StartInfo.RedirectStandardError = false;
            cmd.Start();
        }
    }
}
