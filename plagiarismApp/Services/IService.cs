using System.Collections.Generic;

namespace plagiarismApp.Services
{
    public interface IService<T, TSearch>
    {
        IList<T> Get(TSearch search = default(TSearch));
        T GetById(int id);
    }
}
