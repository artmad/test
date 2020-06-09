using MegaNote.Services.Interfaces;
using MegaNote.Services.Interfaces.Models.Note;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JobScheduler.Workers
{
    public class CurrencyRateWorker : ICurrencyRateWorker
    {

        private readonly IRateEntryService _rateEntryService;

        public CurrencyRateWorker(IRateEntryService rateEntryService)
        {
            _rateEntryService = rateEntryService;
        }

        public async Task TrackCurrency()
        {
            var response = await SendGetRequest<CurrencyRateResponce>("https://free.currconv.com/api/v7/convert?q=EUR_RUB,USD_RUB&compact=ultra&apiKey=f43c4602eb44c397ca61");
            await _rateEntryService.Create(new CreateRateEntryRequest { DollarToRubleRate = response.USD_RUB, EuroToRubleRate = response.EUR_RUB });
        }


        private async Task<T> SendGetRequest<T>(string requestUri)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(requestUri);

            return await GetResponseData<T>(response);
        }

        private async Task<T> GetResponseData<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(responseStream);
        }
    }


    public class CurrencyRateResponce
    {
        public decimal EUR_RUB { get; set; }
        public decimal USD_RUB { get; set; }
    }
}
