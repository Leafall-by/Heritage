public class War : Card
{
    public override void Use()
    {
        FindObjectOfType<WarController>().StartWar();
    }
}
