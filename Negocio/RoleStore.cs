using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Modelo.Cadastros;

namespace Negocio
{
    public class RoleStore : IRoleStore<Papel>
    {

        private readonly ECommerceDeLivrosContext _context;

        public RoleStore(ECommerceDeLivrosContext context)
        {
            this._context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }

        public async Task<IdentityResult> CreateAsync(Papel papel, CancellationToken cancellationToken)
        {
            _context.Add(papel);

            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(IdentityResult.Success);
        }

        public async Task<IdentityResult> UpdateAsync(Papel papel, CancellationToken cancellationToken)
        {
            _context.Update(papel);

            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(IdentityResult.Success);
        }

        public async Task<IdentityResult> DeleteAsync(Papel papel, CancellationToken cancellationToken)
        {
            _context.Remove(papel);

            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(IdentityResult.Success);
        }

        public Task<string> GetRoleIdAsync(Papel papel, CancellationToken cancellationToken)
        {
            return Task.FromResult(papel.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(Papel papel, CancellationToken cancellationToken)
        {
            return Task.FromResult(papel.pap_nome);
        }

        public Task SetRoleNameAsync(Papel papel, string papelName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(Papel papel, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(Papel papel, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult((object)null);
        }

        public Task<Papel> FindByIdAsync(string papelId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Papel> FindByNameAsync(string normalizedPapelName, CancellationToken cancellationToken)
        {
            return await _context.Papeis
                .AsAsyncEnumerable()
                .FirstOrDefault(p => p.pap_nome.Equals(normalizedPapelName, StringComparison.OrdinalIgnoreCase), cancellationToken);
                
        }

        //public Task<IList<Claim>> GetClaimsAsync(Papel role, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    throw new NotImplementedException();
        //}

        //public Task AddClaimAsync(Papel role, Claim claim, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    throw new NotImplementedException();
        //}

        //public Task RemoveClaimAsync(Papel role, Claim claim, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    throw new NotImplementedException();
        //}
    }
}
