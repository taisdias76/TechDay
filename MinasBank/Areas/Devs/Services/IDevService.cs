using MinasBank.Areas.Devs.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MinasBank.Areas.Devs.Services
{
    public interface IDevService
    {
        Task<bool> Adicionar(Dev dev, CancellationToken cancellationToken);
        Task<bool> Alterar(Dev dev, CancellationToken cancellationToken);
       Task<IEnumerable<Dev>> ObterTodos(CancellationToken cancellationToken);
        Task<bool> Apagar(Guid id, CancellationToken cancellationToken);
        Task<Dev> ObterPorId(Guid id, CancellationToken cancellationToken);    
    }
}
