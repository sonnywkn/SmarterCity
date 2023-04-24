using SmarterCity.Model;

namespace SmarterCity.Repository
{
    public class ClientRepository : IClientRepository
    {
        private static List<Client> _clients = new List<Client>();

        public ClientRepository()
        {
            _clients = new List<Client>();
        }
        
        public List<Client> Get()
        {
            return _clients;
        }

        public Client Add(Client client)
        {
            if(client == null) 
                throw new ArgumentNullException("client");

            client.Id = Guid.NewGuid();

            _clients.Add(client);

            return client;
        }
    }

    public interface IClientRepository
    {
        List<Client> Get();
        Client Add(Client client);
    }
}
