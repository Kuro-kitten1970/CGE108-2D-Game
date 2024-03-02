using UnityEngine;

public interface IInteractable
{
    public void Interact(InteractionType type, Collision2D collision);
}
