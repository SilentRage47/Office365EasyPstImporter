
using Office365EasyImporter.Models;
using Office365EasyImporter.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Office365EasyImporter.ViewModels
{
    public class CopyOptionViewModel : INotifyPropertyChanged
    {
        private AzCopyOption copyOption;

        public CopyOptionViewModel()
        {
            copyOption = new AzCopyOption
            {
                AzCopyPath = "%ProgramFiles(x86)%\\Microsoft SDKs\\Azure\\AzCopy\\",
                Source = @"D:\temp\pst",
                Destination = "https://cf6cc6e4bd9f463f8a063e7.blob.core.windows.net/ingestiondata?sv=2015-04-05&sr=c&si=IngestionSasForAzCopy202004171211163451&sig=wBp11sYsJtD2iVYONqMMjf2z9L3MOA2I2bnzV5SkvJs%3D&se=2020-05-17T12%3A11%3A21Z",
                LogFilePath = @"D:\temp\AzCopy.log",
                UseRecursiveMode = false
            };
            UploadCommand = new RelayCommand(ExecuteUpload, CanExecuteUpload);
            CanUpload = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string AzCopyPath
        {
            get { return copyOption.AzCopyPath; }
            set
            {
                if (copyOption.AzCopyPath != value)
                {
                    copyOption.AzCopyPath = value;
                    OnPropertyChange("AzCopyPath");
                    OnPropertyChange("CmdCommand");
                }
            }
        }

        public string Destination
        {
            get { return copyOption.Destination; }
            set
            {
                if (copyOption.Destination != value)
                {
                    copyOption.Destination = value;
                    OnPropertyChange("Destination");
                    OnPropertyChange("CmdCommand");
                }
            }
        }

        public string LogFilePath
        {
            get { return copyOption.LogFilePath; }
            set
            {
                if (copyOption.LogFilePath != value)
                {
                    copyOption.LogFilePath = value;
                    OnPropertyChange("LogFilePath");
                    OnPropertyChange("CmdCommand");
                }
            }
        }

        public string Source
        {
            get { return copyOption.Source; }
            set
            {
                if (copyOption.Source != value)
                {
                    copyOption.Source = value;
                    OnPropertyChange("Source");
                    OnPropertyChange("CmdCommand");
                }
            }
        }

        public bool UseRecursiveMode
        {
            get { return copyOption.UseRecursiveMode; }
            set
            {
                if(copyOption.UseRecursiveMode != value)
                {
                    copyOption.UseRecursiveMode = value;
                    OnPropertyChange("UseRecursiveMode");
                    OnPropertyChange("CmdCommand");
                }
            }
        }

        public string CmdCommand
        {
            get { return UploadController.GetCommand(copyOption); }
        }

        public ICommand UploadCommand { get; set; }
        private bool CanUpload { get; set; }

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private bool CanExecuteUpload(object parameter)
        {
            if (copyOption.Source == "")
            {
                CanUpload = false;
                return false;
            }
            else
            {
                CanUpload = true;
                return true;
            }
        }

        private void ExecuteUpload(object parameter)
        {
            if (CanUpload)
                UploadController.UploadPsts(copyOption);
            else
                MessageBox.Show("Nope!");
        }
    }
}
