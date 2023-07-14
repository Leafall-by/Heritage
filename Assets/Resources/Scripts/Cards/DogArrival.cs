public class DogArrival : Card, IDependet
{
    public override void Use()
    {
        FindObjectOfType<Dog>().Spawn();
    }

    public bool IsCan()
    {
        if (FindObjectOfType<Dog>().IsExist)
        {
            return false;
        }
        return true;
    }
}
