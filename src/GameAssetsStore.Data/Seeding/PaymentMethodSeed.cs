namespace GameAssetsStore.Data.Seeding;

using GameAssetsStore.Data.Models;

public static class PaymentMethodSeed
{
    public static PaymentMethod[] GeneratePaymentMethods()
    {
        ICollection<PaymentMethod> paymentMethods = new HashSet<PaymentMethod>();

        PaymentMethod paymentMethod;

        paymentMethod = new PaymentMethod
        {
            Id = new Guid("11FC7D8E-9363-47AF-8D0C-E0EF73C471F7"),
            Name = "Bank1"
        };

        paymentMethods.Add(paymentMethod);

        paymentMethod = new PaymentMethod
        {
            Id = new Guid("4AB3226D-A16D-49E6-8D91-0BD99CC15D8F"),
            Name = "Bank2"
        };

        paymentMethods.Add(paymentMethod);

        paymentMethod = new PaymentMethod
        {
            Id = new Guid("DDF474C6-7D5F-4DE4-9976-88E63BA81956"),
            Name = "PalPay"
        };

        paymentMethods.Add(paymentMethod);

        return paymentMethods.ToArray();
    }
}
