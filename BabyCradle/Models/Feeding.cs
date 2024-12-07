namespace BabyCradle.Model
{
    public class Feeding:NotificationItem , INotifiable
    {
        public string Title { get; set; } = "remember feeding time after two minutes";

        public string FoodType { get; set; } = string.Empty;


    }
}
