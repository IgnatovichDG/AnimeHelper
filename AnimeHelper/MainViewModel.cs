using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Windows;
using System.Xml;
using AnimeHelper.Data;

namespace AnimeHelper
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //TODO:Описать MV
        Model _model;
        private ObservableCollection<Anime> _animes;

        public MainViewModel()
        {
            _model = new Model();
        }
        public ObservableCollection<Anime> ListAnimes
        {
            get { return _animes; }
            set
            {
                _animes = value;
               
                OnPropertyChanged("ListAnimes");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public async void RefreshList(string str)
        {
            try
            {
                var data = await _model.LoadAnimeFromRequest(str);
                ListAnimes = new ObservableCollection<Anime>(data);
            }
            catch (XmlException)
            {

                MessageBox.Show("По Вашему запросу мы не смогли ничего найти");

            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Проверьте Ваше интернет-соединение");
            }
            
        }
    }
}