namespace BabyCradle.Model
{
    public class Feeding:NotificationItem , INotifiable
    {
      public const string Notification  = "remember feeding time after two minutes";

        public string FoodType { get; set; } = string.Empty;


    }
}
