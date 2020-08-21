using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nibo.Core.Interfaces
{
    public interface IOfxParserService<T> where T : class
    {
        public Task<T> Parse(IEnumerable<IFormFile> files);
    }
}
