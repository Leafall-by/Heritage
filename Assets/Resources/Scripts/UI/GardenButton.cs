using UnityEngine;

public class GardenButton : MonoBehaviour
{
    [SerializeField] private SeedMenuController seedMenuController;
    [SerializeField] private GardenAnimation _animation;
    private bool isOpen = false;

    public void Click()
    {
        if (isOpen)
        {
            _animation.Exit();
            seedMenuController.CloseSeedMenu();
            isOpen = false;
        }
        else
        {
            _animation.Exit();
            seedMenuController.ShowSeedMenu();
            isOpen = true;
        }
    }
}
