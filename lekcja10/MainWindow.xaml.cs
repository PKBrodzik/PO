using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;

namespace lekcja10
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Osoba> Osoby { get; }

        public MainWindow()
        {
            InitializeComponent();
            Osoby = new ObservableCollection<Osoba>();
            //dataGrid.ItemsSource = Osoby;
            DataContext = this;
            serializuj_button.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!FormValid())
                return;
            this.Osoby.Add(new Osoba(imie_text.Text, nazwisko_text.Text, data_urodzenia.SelectedDate.Value.Date));
            serializuj_button.IsEnabled = true;
            // resetujemy pola
            imie_text.Clear();
            nazwisko_text.Clear();
            data_urodzenia.SelectedDate = null;
            data_urodzenia.DisplayDate = DateTime.Today;
            Console.WriteLine($"Osób na liście: {Osoby.Count}");
        }

        private bool FormValid()
        {
            if(imie_text.Text != "" & nazwisko_text.Text.ToString() != "")
            {
                return true;
            }
            return false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OsobaSerializer.SerializeOsoby(this.Osoby, "osoby.json");
        }

        private void OpenFileDeserialize(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                List<Osoba> osoby = OsobaSerializer.DeserializeOsoby(openFile.FileName);
                foreach(Osoba os in osoby)
                {
                    this.Osoby.Add(os);
                }
            }
                
        }
    }
}