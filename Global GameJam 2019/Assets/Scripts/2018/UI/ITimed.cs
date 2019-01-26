namespace Assets.Scripts._2018.UI
{
    public interface ITimed
    {
        float TickIntervalInSeconds { get; set; }

        void StartTicking();
    }
}
