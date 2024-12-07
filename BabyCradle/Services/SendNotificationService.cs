namespace BabyCradle.Services
{
    public class SendNotificationService
    {
      
        public Task SendNotification(NotificationItem notifiable )
        {
            Console.WriteLine($"{notifiable.Content} At {DateTime.Now}");
            
            return Task.CompletedTask;
        }
        
    }
}
