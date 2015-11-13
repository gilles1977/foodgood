using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultra.Services.Contracts
{
    public interface IApiClientService<TQuery, TResult>
    {
        Task<TResult> Search(TQuery query);
    }
}
