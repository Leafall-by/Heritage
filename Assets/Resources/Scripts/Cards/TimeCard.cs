public abstract class TimeCard : Card
{
    public int dayDuration;

    public void DecreaseDuration()
    {
        dayDuration--;

        if (dayDuration <= 0)
        {
            CancelAction();
        }
    }

    public abstract void CancelAction();
}
