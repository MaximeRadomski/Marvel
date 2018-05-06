using Marvel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvel.ViewModels
{
    class MainDetailPageModel : ContentPage, INotifyPropertyChanged
    {
        public new INavigation Navigation { get; set; }
        private string url = "http://gateway.marvel.com/v1/public/characters";
        private readonly HttpClient _client = new HttpClient();
        public List<Hero> Heroes { get; set; }
        public int next { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string nameOfProperty)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nameOfProperty));
        }

        public MainDetailPageModel()
        {
            next = 0;
            Task.Run(async () => await LoadItems());
        }

        public async Task LoadItems()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                url = "http://gateway.marvel.com/v1/public/characters";
                url += "?ts=1&apikey=9c0d7803beda670aa96f3618e8cc78c4&hash=8d012c90ef8dfc4c1e53008a78ab3f9b";
                response = await _client.GetAsync(url);

                string responseText = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<MarvelApiResult<Hero>>(responseText);
                    Heroes = result.Data.Results;
                    OnPropertyChanged("Heroes");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public ICommand TestCallCommand => new Command(async () =>
        {
            HttpResponseMessage response = new HttpResponseMessage();
            next += 19;
            try
            {
                url = "http://gateway.marvel.com/v1/public/characters";
                url += "?ts=1&apikey=9c0d7803beda670aa96f3618e8cc78c4&hash=8d012c90ef8dfc4c1e53008a78ab3f9b&offset="+next;
                response = await _client.GetAsync(url);

                string responseText = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<MarvelApiResult<Hero>>(responseText);
                    Heroes = result.Data.Results;
                    OnPropertyChanged("Heroes");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        });
    }
}
