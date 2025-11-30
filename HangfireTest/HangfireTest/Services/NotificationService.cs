using HangfireTest.Models;

namespace HangfireTest.Services
{
    public interface INotificationService
    {
        void SendNotification(Product product);
    }
    public class NotificationService : INotificationService
    {
        public void SendNotification(Product product)
        {
            Console.WriteLine($"[BACKGROUND JOB] Notification: Product '{product.name}' with Prize {product.price} has been created/updated.");
        }
    }
}
