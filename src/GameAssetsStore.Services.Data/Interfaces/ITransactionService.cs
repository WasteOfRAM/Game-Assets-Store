namespace GameAssetsStore.Services.Data.Interfaces;

public interface ITransactionService
{
    Task AddTransactionAsync(string userId, string status, decimal value);
}
