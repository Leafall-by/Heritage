public class Rain : TimeCard
{
    private Weather weather;
    public override void Use()
    {
        weather = FindObjectOfType<Weather>();
        weather.StartRain();
    }

    public override void CancelAction()
    {
        weather = FindObjectOfType<Weather>();
        weather.StopRain();
    }
}
