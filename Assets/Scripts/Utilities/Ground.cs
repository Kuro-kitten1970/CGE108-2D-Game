using UnityEngine;

public class Ground : MonoBehaviour, IGround
{
    public bool Interact(GroundChecker groundChecker)
    {
        return true;
    }
}
