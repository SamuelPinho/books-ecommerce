using System;
using System.Linq;
using Modelo.Infra;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using System.Collections.Generic;
using Modelo.Cadastros;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class UserStore : IUserStore<Usuario>, IUserPasswordStore<Usuario>, IUserRoleStore<Usuario>, IUserEmailStore<Usuario>
    {

        private readonly ECommerceDeLivrosContext _context;

        public UserStore(ECommerceDeLivrosContext context)
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

        public Task<string> GetUserIdAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            return Task.FromResult(usuario.Id.ToString());
        }

        public Task<string> GetUserNameAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            return Task.FromResult(usuario.usr_primeiro_nome + "_" + usuario.usr_sobrenome);
        }

        public Task SetUserNameAsync(Usuario usuario, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(SetUserNameAsync));
        }

        public Task<string> GetNormalizedUserNameAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(GetNormalizedUserNameAsync));
        }

        public Task SetNormalizedUserNameAsync(Usuario usuario, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult((object)null);
        }

        public async Task<IdentityResult> CreateAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            _context.Add(usuario);

            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(IdentityResult.Success);
        }

        public async Task<IdentityResult> DeleteAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            _context.Remove(usuario);

            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(IdentityResult.Success);
        }

        public async Task<IdentityResult> UpdateAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            _context.Usuarios.Update(usuario);

            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(IdentityResult.Success);
        }

        public async Task<Usuario> FindByIdAsync(string usuarioId, CancellationToken cancellationToken)
        {
            if (int.TryParse(usuarioId, out int id))
            {
                return _context.Usuarios
                    .Where(u => u.Id == id)
                    .Include(u => u.Papel)
                    .Include(u => u.EnderecosDoUsuario)
                        .ThenInclude(e => e.Endereco)
                    .Include(u => u.CartoesDoUsuario)
                        .ThenInclude(c => c.Cartao)
                            .ThenInclude(c => c.Bandeira)
                    .Include(u => u.CuponsDoUsuario)
                        .ThenInclude(c => c.Cupom)
                    .Include(u => u.TelefonesDoUsuario)
                        .ThenInclude(t => t.Telefone)
                    .FirstOrDefault();
            }
            else
            {
                return await Task.FromResult((Usuario)null);
            }
        }

        public async Task<Usuario> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await _context.Usuarios
                .AsAsyncEnumerable()
                .SingleOrDefault(u => u.usr_primeiro_nome.Equals(normalizedUserName, StringComparison.OrdinalIgnoreCase), cancellationToken);
        }

        public Task SetPasswordHashAsync(Usuario usuario, string passwordHash, CancellationToken cancellationToken)
        {
            usuario.usr_senha = passwordHash;

            return Task.FromResult((object)null);
        }

        public Task<string> GetPasswordHashAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            return Task.FromResult(usuario.usr_senha);
        }

        public Task<bool> HasPasswordAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(usuario.usr_senha));
        }

        public async Task AddToRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            var papel = _context.Papeis.First(p => p.pap_nome.Equals(roleName, StringComparison.OrdinalIgnoreCase));
            if (papel != null)
            {
                user.usr_papel_id = papel.Id;
            }
            _context.Update(user);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task RemoveFromRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(Usuario user, CancellationToken cancellationToken)
        {
            IList<string> listaPapeis = new List<string>();

            var papeisUsuario = _context.Papeis.Where(p => p.Id == user.usr_papel_id).ToList();

            foreach(var papel in papeisUsuario)
            {
                listaPapeis.Add(papel.pap_nome.ToString());
            }

            return Task.FromResult(listaPapeis);

        }

        public Task<bool> IsInRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            var papel = _context.Papeis.First(p => p.pap_nome.Equals(roleName, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(user.usr_papel_id == papel.Id);
        }

        public async Task<IList<Usuario>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            var papel = _context.Papeis.First(p => p.pap_nome.Equals(roleName, StringComparison.OrdinalIgnoreCase));

            return await Task.FromResult(papel.Usuarios.ToList());
        }

        public Task SetEmailAsync(Usuario user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(Usuario user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.usr_email.ToString());
        }

        public Task<bool> GetEmailConfirmedAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(Usuario user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return await _context.Usuarios
                .AsAsyncEnumerable()
                .SingleOrDefault(u => u.usr_email.Equals(normalizedEmail, StringComparison.OrdinalIgnoreCase), cancellationToken);
        }

        public Task<string> GetNormalizedEmailAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(GetNormalizedEmailAsync));
        }

        public Task SetNormalizedEmailAsync(Usuario user, string normalizedEmail, CancellationToken cancellationToken)
        {
            return Task.FromResult((object)null);
        }

    }

}
