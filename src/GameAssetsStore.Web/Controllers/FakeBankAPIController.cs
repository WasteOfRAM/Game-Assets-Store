﻿namespace GameAssetsStore.Web.Controllers
{
    using GameAssetsStore.Data.Models;
    using GameAssetsStore.Data.Repositories.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    // TODO

    /// <summary>
    /// Controller just for testing purposes.
    /// Working directly with the repository only for the test.
    /// </summary>
    public class FakeBankAPIController : Controller
    {
        private readonly IPaymentMethodRepository paymentRepository;

        public FakeBankAPIController(IPaymentMethodRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string transactionId, decimal amount, string returnUrl)
        {
            var account = await this.paymentRepository.GetById(Guid.Parse(transactionId));
            string status = "Failed";

            if (account!.Balance >= amount)
            {
                status = "Succeeded";

                account.Balance -= amount;

                this.paymentRepository.Update(account);
                await this.paymentRepository.Save();
            }

            string redirectUrl = $"{returnUrl}?status={status}&amount={amount}";

            return Redirect(redirectUrl);
        }
    }
}
