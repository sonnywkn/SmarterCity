using SmarterCity.Model;
using SmarterCity.Repository;

namespace SmarterCity.Services
{
    public class ClientService : IClientService
    {
        IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client AddClient(Client client)
        {
            return _clientRepository.Add(client);
        }

        public List<Client> GetAllClients()
        {
            return _clientRepository.Get();
        }
    }

    public interface IClientService
    {
        List<Client> GetAllClients();
        Client AddClient(Client client);
    }
}
