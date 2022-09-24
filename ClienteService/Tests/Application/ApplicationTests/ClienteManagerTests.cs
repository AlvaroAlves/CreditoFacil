using Application;
using Application.Clientes.DTO;
using Application.Clientes.Requests;
using Domain.Entities;
using Domain.Ports;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ApplicationTests
{
    public class Tests
    {
        ClienteManager clienteManager;
        [SetUp]
        public void Setup()
        {
            var fakeRepo = new Mock<IClienteRepository>();
            fakeRepo.Setup(x => x.Create(It.IsAny<Cliente>())).Returns(Task.FromResult("10994999097"));
            clienteManager = new ClienteManager(fakeRepo.Object);
        }

        [Test]
        public async Task DadosParametrosValidosDeveSalvarClienteComSucesso()
        {
            var expectedCpf = "10994999097";
            //cpf gerado a partir de ferramenta automatica
            var cliente = new InsertClienteDTO
            {
                Celular = "41999992222",
                Cpf = "10994999097",
                Nome = "Fulano",
                UF = "PR"
            };

            var request = new CreateClienteRequest
            {
                Data = cliente
            };

            var response = await clienteManager.CreateCliente(request);
            Assert.AreEqual(expectedCpf, response.Data.Cpf);
            Assert.IsNotNull(response);
            Assert.True(response.Success);
        }

        [Test]
        public async Task DadoCpfInvalidoDeveRetornarErrorCodeInvalidCPF()
        {
            var cliente = new InsertClienteDTO
            {
                Celular = "41999992222",
                Cpf = "4999097",
                Nome = "Fulano",
                UF = "PR"
            };

            var request = new CreateClienteRequest
            {
                Data = cliente
            };

            var response = await clienteManager.CreateCliente(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.ErrorCode, ErrorCodes.INVALID_CPF);
            Assert.False(response.Success);
        }

        [Test]
        public async Task DadoObjetoVazioDeveRetornarMissingRequiredInformation()
        {
            var cliente = new InsertClienteDTO();

            var request = new CreateClienteRequest
            {
                Data = cliente
            };

            var response = await clienteManager.CreateCliente(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.ErrorCode, ErrorCodes.MISSING_REQUIRED_INFORMATION);
            Assert.False(response.Success);
        }

        [TestCase("","","","")]
        [TestCase("10994999097", "", "", "")]
        [TestCase("10994999097", "41999992222", "", "")]
        [TestCase("10994999097", "41999992222", "Fulano", "")]
        [TestCase("10994999097", "41999992222", "", "PR")]
        public async Task DeveRetornarMissingRequiredInformationQuandoInformadoAlgumCampoNecessarioVazio(string cpf, string celular, string nome, string uf)
        {
            var cliente = new InsertClienteDTO()
            {
                Celular = celular,
                Cpf = cpf,
                Nome = nome,
                UF = uf
            };

            var request = new CreateClienteRequest
            {
                Data= cliente
            };

            var response = await clienteManager.CreateCliente(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.ErrorCode, ErrorCodes.MISSING_REQUIRED_INFORMATION);
            Assert.False(response.Success);
        }

        [Test]
        public async Task DeveRetornarNotFoundQuandoUserNaoExiste()
        {
            var fakeRepo = new Mock<IClienteRepository>();
            fakeRepo.Setup(x => x.Create(It.IsAny<Cliente>())).Returns(Task.FromResult("10994999097"));
            fakeRepo.Setup(x => x.Get("12312312332")).Returns(Task.FromResult<Cliente?>(null));
            clienteManager = new ClienteManager(fakeRepo.Object);

            var response = await clienteManager.GetCliente("12312312332");
            Assert.IsNotNull(response);
            Assert.AreEqual(response.ErrorCode, ErrorCodes.NOT_FOUND);
            Assert.False(response.Success);
        }
    }
}