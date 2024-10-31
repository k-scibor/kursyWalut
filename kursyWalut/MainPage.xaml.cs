using System.Net;
using System.Text.Json;

namespace KursyWalut
{
    public class Currency
    {
        public string? table { get; set; }
        public string? currency { get; set; }
        public string? code { get; set; }
        public IList<Rate> rates { get; set; }
    }
    //****************
    // nazwa funkcji: Currency()
    // parametry wejściowe: table - string, używana w tym momencie tablica
    //                      currency - string, waluta
    //                      code - string, kod waluty
    //                      rates - IList<Rate>, kurs danej waluty
    // zwracana wartość:    Currency - obiekt, którego polami są informacje o 
    // informacje:          klasa Currency zbiera informacje o walucie i tworzy 
    //                      obiekt na ich podstawie
    //****************
    public class Rate
    {
        public string? no { get; set; }
        public string? effectiveDate { get; set; }
        public double? bid { get; set; }
        public double? ask { get; set; }
    }

    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            DateTime dzis = DateTime.Now;
            Currency c1 = new Currency();
            Currency c2 = new Currency();
            double kursZD, kursSD, kursW;

            c1 = deserializujJson(pobierzKurs("usd", dzis));
            kursZD = (double)c1.rates[0].bid;
            kursSD = (double)c1.rates[0].ask;
            lblUSDks.Text = $"Kurs sprzedaży: {kursSD}";
            lblUSDkz.Text = $"Kurs skupu:     {kursZD}";

            c1 = deserializujJson(pobierzKurs("eur", dzis));
            kursZD = (double)c1.rates[0].bid;
            kursSD = (double)c1.rates[0].ask;
            lblEURks.Text = $"Kurs sprzedaży: {kursSD}";
            lblEURkz.Text = $"Kurs skupu:     {kursZD}";

            c1 = deserializujJson(pobierzKurs("gbp", dzis));
            kursZD = (double)c1.rates[0].bid;
            kursSD = (double)c1.rates[0].ask;
            lblGBPks.Text = $"Kurs sprzedaży: {kursSD}";
            lblGBPkz.Text = $"Kurs skupu:     {kursZD}";

        }
        private Currency deserializujJson(string json)
        {
            return JsonSerializer.Deserialize<Currency>(json);
        }
        private string pobierzKurs(string waluta, DateTime data)
        {
            string d = data.ToString("yyyy-MM-dd");
            string url = "https://api.nbp.pl/api/exchangerates/rates/c/" + waluta + "/" + d + "/?format=json";
            string json;
            using (var webClient = new WebClient())
            {
                json = webClient.DownloadString(url);
            }
            return json;
        }


    }

}
