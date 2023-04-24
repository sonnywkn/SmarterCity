using Microsoft.AspNetCore.Mvc;
using SmarterCity.Model;
using SmarterCity.Services;

namespace SmarterCity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return _clientService.GetAllClients();
        }

        [HttpPost]
        public Client Post(Client client)
        {
            return _clientService.AddClient(client);
        }
    }
}