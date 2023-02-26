using dal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using wpf.Viewmodels;
using wpf.views;

namespace wpf.viewmodels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Initialization
        private MainWindow _view;
        public MainWindow MainWindow
        {
            get { return _view; }
            set { _view = value; }
        }

        public MainWindowViewModel(MainWindow view)
        {
            _view = view;
            GetWantedWords();
            NotifyPropertyChanged();
        }
        #endregion

        #region Properties
        // my privates
        private readonly string InputFile = "input.txt";
        private int _wordLength = 6;

        private string _noDataFound = "Visible";
        private string _dataFound = "Collapsed";

        private string _selectedWord;
        private string _combinations = "Combinations: \n";

        private ObservableCollection<string> _wordList;
        private ObservableCollection<string> _allWords;
        private ObservableCollection<string> _three;

        // publics
        public int WordLength
        {
            get { return _wordLength; }
            set { _wordLength = value; }
        }

        public string NoDataFound
        {
            get { return _noDataFound; }
            set { _noDataFound = value; NotifyPropertyChanged(); }
        }
        public string DataFound
        {
            get { return _dataFound; }
            set { _dataFound = value; NotifyPropertyChanged(); }
        }

        public string SelectedWord
        {
            get { return _selectedWord; }
            set { _selectedWord = value; ResetLabel(); GetCombinations(); }
        }
        public string Combinations
        {
            get { return _combinations; }
            set { _combinations = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<string> WordList
        {
            get { return _wordList; }
            set { _wordList = value; }
        }
        public ObservableCollection<string> AllWords
        {
            get { return _allWords; }
            set { _allWords = value; }
        }
        public ObservableCollection<string> Three
        {
            get { return _three; }
            set { _three = value; }
        }
        #endregion

        #region Methods
        public void FillWordList()
        {
            // vul de lijst op met woorden gevonden in inputFile
            AllWords = new ObservableCollection<string>(FileOperations.ReadFromFile(InputFile));

            // Als geen data wordt gevonden toon de error, anders toon de combobox
            if (AllWords.Count > 0)
            {
                DataFound = "Visible";
                NoDataFound = "Collapsed";
            }

            NotifyPropertyChanged();
        }

        public void GetWantedWords()
        {
            FillWordList();
            // vul de lijst op met woorden met een lengte van WordLength
            WordList = new ObservableCollection<string>(AllWords.Where(x => x.Length == WordLength));
            NotifyPropertyChanged();
        } 

        public void GetCombinations()
        {
            /*
             * rudimentair voorbeeld van een mogelijke oplossing:
             * AllWords opdelen in lijsten van verschillende lengtes om combinaties te berekenen
             * vb: als de eerste letter van het woord gevonden wordt in lijst "3-letters",
             *      zijn mogelijke opties om het resterende woord te maken:
             *      * 3
             *      * 2 + 1
             *      * 1 + 1 + 1
             * 
             * Gebruikte onderdelen worden uit de gebruikte lijst verwijderd om dezelfde letter niet meermaals te gebruiken
             * 
             * Mijn voorbeeld gebruikt enkel 3-letters (lijst genaamd "Three") om de functionaliteit te tonen
             */
            
            // vul de lijst op met 3-letter woorden die voorkomen in het geselecteerde 6-letter woord
            Three = new ObservableCollection<string>(AllWords.Where(x => x.Length == 3 && SelectedWord.Contains(x)));

            // splits het woord op in twee delen
            string partOne = SelectedWord.Substring(0, 3);
            string partTwo = SelectedWord.Substring(3, 3);

            // vul combinaties met alle mogelijkheden (in dit voorbeeld 1 combinatie mogelijk)
            Combinations += Three.First(x => x.Contains(partOne));
            Combinations += " + " + Three.First(x => x.Contains(partTwo)) + "\n";

            NotifyPropertyChanged();
        }

        public void ResetLabel()
        {
            // label leegmaken bij selectie van een nieuw woord
            Combinations = "Combinations: \n";
            NotifyPropertyChanged();
        }
        #endregion
    }
}
