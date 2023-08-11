namespace GameAssetsStore.Web.Controllers
{
    using GameAssetsStore.Data.Models;
    using GameAssetsStore.Data.Repositories.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Controller just for testing purposes.
    /// Working directly with the repository only for the test.
    /// </summary>
    public class FakeBankAPIController : Controller
    {
        private readonly IRepository<PaymentMethod> paymentRepository;

        public FakeBankAPIController(IRepository<PaymentMethod> paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string transactionId, decimal amount, string returnUrl)
        {
            var account = await this.paymentRepository.GetAll().FirstAsync(p => p.Id.ToString() == transactionId);
            string status = "Failed";

            if (account.Balance >= amount)
            {
                status = "Succeeded";

                account.Balance -= amount;

                this.paymentRepository.Update(account);
                await this.paymentRepository.SaveChangesAsync();
            }

            string redirectUrl = $"{returnUrl}?status={status}&amount={amount}";

            return Redirect(redirectUrl);
        }
    }
}
