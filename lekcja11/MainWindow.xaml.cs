using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;

namespace lekcja11
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Osoba> Osoby { get; }

        public MainWindow()
        {
            InitializeComponent();
            Osoby = new ObservableCollection<Osoba>();
            // jeżeli nie dodamy DataContext to musimy ItemsSource przypisać w kodzie a nie xaml
            //  dataGrid.ItemsSource = Osoby;
            DataContext = this;
            serializuj_button.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!FormValid())
                return;
            this.Osoby.Add(new Osoba(imie_text.Text, nazwisko_text.Text, data_urodzenia.SelectedDate.Value.Date));
            // po dodaniu przynajmniej jednej osoby możemy już wybrać przycisk "Serializuj"
            serializuj_button.IsEnabled = true;
            // resetujemy wartość pól formularza
            imie_text.Clear();
            nazwisko_text.Clear();
            data_urodzenia.SelectedDate = null;
            data_urodzenia.DisplayDate = DateTime.Today;
        }

        private bool FormValid()
        {
            if(imie_text.Text != "" & nazwisko_text.Text.ToString() != "" & data_urodzenia.SelectedDate.ToString() != "")
            {
                return true;
            }
            return false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // można dodać dynamiczne określanie nazwy pliku zamiast zapisanej na sztywno
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