using ProGaudi.Tarantool.Client;
using ProGaudi.Tarantool.Client.Model;
using ProGaudi.Tarantool.Client.Model.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace Tarantool.Cache
{
    public class TarantoolCache
    {
        public async Task SetAsync(long id, string value)
        {
            var space = await GetSpace();

            await space.Insert((id, value));
        }

        public async Task<string> Get(long id)
        {
            var space = await GetSpace();

            var index = await space.GetIndex("primary");

            var result = await index
                .Select<TarantoolTuple<long>, TarantoolTuple<long, string>>(
                TarantoolTuple.Create(id),
                new SelectOptions { Iterator = Iterator.All });

            return result.Data.Select(x => x.Item2).FirstOrDefault();
        }

        private async Task<ISpace> GetSpace()
        {
            var box = await Box.Connect("127.0.0.1:3301");

            var schema = box.GetSchema();

            return await schema.GetSpace("examples");
        }

        public async Task<string> AlterGet(long id)
        {
            using (var box = await Box.Connect("127.0.0.1:3301"))
            {
                var schema = box.GetSchema();

                var space = await schema.GetSpace("examples");

                var index = await space.GetIndex("primary");

                var result = await index
                    .Select<TarantoolTuple<long>, TarantoolTuple<long, string>>(
                    TarantoolTuple.Create(id),
                    new SelectOptions { Iterator = Iterator.All });

                return result.Data.Select(x => x.Item2).FirstOrDefault();
            }
        }
    }
}
