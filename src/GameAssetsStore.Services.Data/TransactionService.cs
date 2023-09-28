namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data.Interfaces;
using System.Threading.Tasks;
using Common.Enumerators;

public class TransactionService : ITransactionService
{
    private readonly IRepository<Transaction> transactionRepository;

    public TransactionService(IRepository<Transaction> transactionRepository)
    {
        this.transactionRepository = transactionRepository;
    }

    public async Task AddTransactionAsync(string userId, string status, decimal amount)
    {
        var entity = new Transaction
        {
            UserId = new Guid(userId),
            Status = Enum.Parse<TransactionStatus>(status),
            Amount = amount
        };

        await this.transactionRepository.AddAsync(entity);
        await this.transactionRepository.SaveAsync();
    }
}
