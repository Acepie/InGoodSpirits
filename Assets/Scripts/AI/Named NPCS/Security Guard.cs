public class SecurityGuard : NPC
{
    private int numWorking;

    private new void Awake()
    {
        base.Awake();
        currentFloor = Floor.Ground;
    }

    private void Loop()
    {
    }
}