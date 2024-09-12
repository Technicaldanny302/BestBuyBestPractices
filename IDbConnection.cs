
namespace BestBuyBestPractices
{
    public class IDbConnection
    {
        internal IEnumerable<T> Query<T>()
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<T> Query<T>(string v)
        {
            throw new NotImplementedException();
        }
    }
}