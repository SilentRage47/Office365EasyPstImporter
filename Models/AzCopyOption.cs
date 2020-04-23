namespace Office365EasyImporter.Models
{
    public class AzCopyOption
    {
        public string AzCopyPath { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string LogFilePath { get; set; }
        public bool UseRecursiveMode { get; set; }

    }
}
