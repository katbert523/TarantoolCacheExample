using System.Threading.Tasks;

namespace CacheContract
{
    /// <summary>
    /// Контракт кэша.
    /// </summary>
    public interface ICacheContract<TKey, TValue>
    {
        /// <summary>
        /// Получить данные из кэша.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns></returns>
        Task<TValue> GetOrCreateAsync(TKey key);
    }
}
