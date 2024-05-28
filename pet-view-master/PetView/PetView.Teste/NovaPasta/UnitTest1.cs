using System;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace PetView.Teste.NovaPasta
{
    public class DonoTests : IDisposable
    {
        private readonly string _connectionString;
        private readonly SqlConnection _connection;

        public DonoTests()
        {
            _connectionString = "Server=your_server;Database=your_test_database;User Id=your_user;Password=your_password;";
            _connection = new SqlConnection(_connectionString);
            _connection.Open();

            // Ensure the database is in a known state before each test
            CleanDatabase();
        }

        private void CleanDatabase()
        {
            var cleanCommand = new SqlCommand("DELETE FROM Donos; DELETE FROM Enderecos;", _connection);
            cleanCommand.ExecuteNonQuery();
        }

        [Fact]
        public void Insert_ShouldInsertDonoSuccessfully()
        {
            // Arrange
            var dono = new Dono
            {
                NomeDono = "Teste",
                CPFDono = "12345678900",
                RGDono = "RG123456",
                CelDono = "11999999999",
                TelDono = "",
                EmailDono = "email@teste.com",
                Endereco = new Endereco
                {
                    CEP = "12345678",
                    NumCasa = 1,
                    Rua = "Rua Teste",
                    Bairro = "Bairro Teste",
                    Complemento = "Apt 101",
                    Cidade = "Cidade Teste",
                    UF = "SP"
                }
            };

            // Act
            dono.Insert();

            // Assert
            var command = new SqlCommand("SELECT COUNT(*) FROM Donos WHERE NomeDono = 'Teste'", _connection);
            int count = (int)command.ExecuteScalar();
            Assert.Equal(1, count);
        }

        [Fact]
        public void Select_ShouldReturnDataTable_WhenValidParametersAreGiven()
        {
            // Arrange
            var insertCommand = new SqlCommand(@"
                INSERT INTO Enderecos (CEP, NumCasa, Rua, Bairro, Complemento, Cidade, UF) 
                VALUES ('12345678', 1, 'Rua Teste', 'Bairro Teste', 'Apt 101', 'Cidade Teste', 'SP');
                INSERT INTO Donos (NomeDono, CPFDono, RGDono, CelDono, TelDono, EmailDono, EnderecoId)
                VALUES ('Teste', '12345678900', 'RG123456', '11999999999', '', 'email@teste.com', SCOPE_IDENTITY());
            ", _connection);
            insertCommand.ExecuteNonQuery();

            // Act
            DataTable result = Dono.Select("Nome", "Teste");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Rows.Count);
        }

        [Fact]
        public void Delete_ShouldDeleteDonoSuccessfully()
        {
            // Arrange
            var insertCommand = new SqlCommand(@"
                INSERT INTO Enderecos (CEP, NumCasa, Rua, Bairro, Complemento, Cidade, UF) 
                VALUES ('12345678', 1, 'Rua Teste', 'Bairro Teste', 'Apt 101', 'Cidade Teste', 'SP');
                INSERT INTO Donos (NomeDono, CPFDono, RGDono, CelDono, TelDono, EmailDono, EnderecoId)
                VALUES ('Teste', '12345678900', 'RG123456', '11999999999', '', 'email@teste.com', SCOPE_IDENTITY());
            ", _connection);
            insertCommand.ExecuteNonQuery();

            var command = new SqlCommand("SELECT TOP 1 CodigoDono FROM Donos WHERE NomeDono = 'Teste'", _connection);
            int codigoDono = (int)command.ExecuteScalar();

            var dono = new Dono
            {
                CodigoDono = codigoDono
            };

            // Act
            dono.Delete();

            // Assert
            var countCommand = new SqlCommand("SELECT COUNT(*) FROM Donos WHERE CodigoDono = @codigoDono", _connection);
            countCommand.Parameters.AddWithValue("@codigoDono", codigoDono);
            int count = (int)countCommand.ExecuteScalar();
            Assert.Equal(0, count);
        }

        public void Dispose()
        {
            CleanDatabase();
            _connection.Close();
        }
    }
}




