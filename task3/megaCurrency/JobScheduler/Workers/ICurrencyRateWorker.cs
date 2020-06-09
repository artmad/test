using System.Threading.Tasks;

namespace JobScheduler.Workers
{
    public interface ICurrencyRateWorker
    {
        public Task TrackCurrency();
    }
}
