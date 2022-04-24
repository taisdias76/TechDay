using Microsoft.AspNetCore.Hosting;
using MinasBank.Areas.Devs.Models;
using MinasBank.Areas.Devs.Repository;
using MinasBank.Shared.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MinasBank.Areas.Devs.Services
{
    public class DevService : IDevService
    {
        private readonly IGenericRepository<Dev> _genericRepository;
        private readonly IDevRepository _devRepository;
        private readonly IWebHostEnvironment _env;

        public DevService(IGenericRepository<Dev> genericRepository, 
            IDevRepository devRepository,
            IWebHostEnvironment env)
        {
            _genericRepository = genericRepository;
            _devRepository = devRepository;
            _env = env;
        }

        public async Task<bool> Adicionar(Dev dev, CancellationToken cancellationToken)
        {
            //salvar a imagem
            dev.Id = Guid.NewGuid();
            await UploadFoto(dev, cancellationToken).ConfigureAwait(false);

            await _genericRepository.AddAsync(dev, cancellationToken).ConfigureAwait(false);
            var result = await _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }

        public async Task<bool> Alterar(Dev dev, CancellationToken cancellationToken)
        {
            if(dev.Foto != null)
            {
                await UploadFoto(dev, cancellationToken).ConfigureAwait(false);
                _genericRepository.Update(dev);
            }
            else
            {
                _devRepository.AtualizarSemFoto(dev);
            }

            return await _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> Apagar(Guid id, CancellationToken cancellationToken)
        {
            var dev = await _genericRepository.GetByKeysAsync(cancellationToken, id).ConfigureAwait(false);
            _genericRepository.Delete(dev);

            return await _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Dev> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetByKeysAsync(cancellationToken, id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Dev>> ObterTodos(CancellationToken cancellationToken)
        {
            return await _genericRepository.GetAllAsync(noTracking: true, 
                cancellationToken: cancellationToken);
        }

        private async Task UploadFoto(Dev dev, CancellationToken cancellationToken)
        {
            if(dev.Foto != null)
            {
                dev.FotoUrl = Path.Combine("Images", "Cliente", $"{dev.Id}.{dev.Foto.FileName}");
                var fulPath = Path.Combine(_env.WebRootPath, dev.FotoUrl);
                using (var fileStream = new FileStream(fulPath, FileMode.Create))
                {
                    await dev.Foto.CopyToAsync(fileStream, cancellationToken).ConfigureAwait(false);
                }
            }
        }
    }
}
