using Ecommerce.Data.Models;
using Ecommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepo;

        public ClienteService(ClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }
        public async Task<Cliente> RegistraClienteAsync(string nome, string cognome, string email, string indirizzo)
        {
            var clienteEsistente = await _clienteRepo.GetByEmailAsync(email);
            if (clienteEsistente != null)
                throw new Exception("Email già registrata");

            Cliente cliente = new Cliente { Nome = nome, Cognome = cognome, Email = email, Indirizzo = indirizzo};
            await _clienteRepo.AddAsync(cliente);
            return cliente;
        }
        public async Task<IEnumerable<Cliente>> ListaClientiAsync()
        {
            return await _clienteRepo.GetAllAsync();
        }
    }
}
