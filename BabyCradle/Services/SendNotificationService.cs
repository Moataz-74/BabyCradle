namespace BabyCradle.Services
{
    public class SendNotificationService
    {
       

        
        public Task SendNotification(NotificationItem notifiable )
        {
            Console.WriteLine($"{notifiable.Title} At {DateTime.Now}");
            
            return Task.CompletedTask;
        }
        
    }
}
