using Microsoft.Data.SqlClient;
using Pagos.Domain.Contract;
using Pagos.Domain.Entities;

namespace Pagos.Domain.Repositories
{
    public class TransactionRepository: ITransaction
    {
        private readonly string _connectionString;

        public TransactionRepository()
        {
            _connectionString = "Server=localhost;Database=Pagos;User Id=usr2;Password=123456;Encrypt=true;TrustServerCertificate=true;";

        }

        public async Task SavePaymentRecord(Transaction paymentRecord)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO PaymentRecords (Customer, ProviderName, TransactionId, Amount,TransactionType, IsSuccessfull) " +
                               "VALUES (@Customer,@ProviderName, @TransactionId, @Amount, @TransactionType, @IsSuccessfull)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Customer", paymentRecord.ProviderName);
                    command.Parameters.AddWithValue("@ProviderName", paymentRecord.ProviderName);
                    command.Parameters.AddWithValue("@TransactionId", paymentRecord.TransactionId);
                    command.Parameters.AddWithValue("@Amount", paymentRecord.Amount.Value);
                    command.Parameters.AddWithValue("@TransactionType", paymentRecord.TransactionId);
                    command.Parameters.AddWithValue("@IsSuccessfull", 1);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
