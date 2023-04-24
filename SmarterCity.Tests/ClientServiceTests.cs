using SmarterCity.Model;
using SmarterCity.Repository;
using SmarterCity.Services;

namespace SmarterCity.UnitTests
{
    [TestFixture]
    public class ClientServiceTests
    {
        [Test]
        [TestCase("Sonny", "Wong", "myemail@address", "my home address", "123214123")]
        public void Add_Client_Success(string firstName, string lastName, string email, string address, string mobile)
        {
            //Arrange
            var clientService = new ClientService(new ClientRepository());
            var client = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Address = address,
                MobileNumber = mobile
            };

            //Act
            var actual = clientService.AddClient(client);

            //Assert
            Assert.NotNull(actual?.Id);
            Assert.AreEqual(firstName, actual.FirstName);
            Assert.AreEqual(lastName, actual.LastName);
            Assert.AreEqual(email, actual.Email);
            Assert.AreEqual(address, actual.Address);
            Assert.AreEqual(mobile, actual.MobileNumber);
        }

        [Test]
        public void Add_Client_Failure()
        {
            //Arrange
            var clientService = new ClientService(new ClientRepository());

            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => { clientService.AddClient(null); });
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void Get_Client_Success(int clientSize)
        {
            //arrange
            var clientService = new ClientRepository();

            for (int i = 0; i < clientSize; i++)
            {
                clientService.Add(new Client
                {
                    FirstName = "Sonny",
                    LastName = "Wong",
                    Email = "myemail@address",
                    Address = "my home address",
                    MobileNumber = "123214123"
                });

            }

            //Act
            var clients = clientService.Get();

            //Assert
            if (clientSize == 0)
            {
                Assert.IsEmpty(clients);
            }
            else
            {
                Assert.AreEqual(clientSize, clients.Count);
            }
        }
    }
}
