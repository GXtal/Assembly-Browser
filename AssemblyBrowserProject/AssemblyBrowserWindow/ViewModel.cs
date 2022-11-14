
using AssemblyBrowserLibrary;
using AssemblyBrowserLibrary.Elements;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Runtime.CompilerServices;


namespace AssemblyBrowserWindow
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private readonly Browser assemblyBrowser = new Browser();
        public RelayCommand SearchCommand
        {
            get;          
        }

        public RelayCommand CheckCommand
        {
            get;
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {               
               _path = value;
               OnPropertyChanged("Path");
            }
        }

        private Element _tree;
        public Element Tree
        {
            get { return _tree; }
            set
            {
                _tree = value;
                OnPropertyChanged("Tree");
            }
        }
        public ViewModel()
        {
            SearchCommand = new RelayCommand(
                obj =>
                {
                    var openFileDialog = new OpenFileDialog();
                    if  (openFileDialog.ShowDialog() == true)                        
                    Path = openFileDialog.FileName;

                });

            CheckCommand = new RelayCommand(
               obj =>
               {
                   Tree=assemblyBrowser.WorkWith(Path);
                   //Tree=assemblyBrowser.Temp();
               });

            Path = "Nya";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
