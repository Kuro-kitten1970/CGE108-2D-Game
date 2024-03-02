using UnityEngine;

public enum InteractionType
{
    MysteryBox, UnbreakBox, Box, Stump, Coin
}

public class InteractObject : MonoBehaviour
{
    public float _n;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<InteractableObj>())
        {
            InteractableObj obj = collision.gameObject.GetComponent<InteractableObj>();

            ContactPoint2D contact = collision.GetContact(0);
            if (Vector2.Dot(contact.normal, Vector2.down) <= 0.95f) return;

            if (collision.gameObject.CompareTag(InteractionType.MysteryBox.ToString()))
                obj.Interact(InteractionType.MysteryBox, collision);

            if (collision.gameObject.CompareTag(InteractionType.Box.ToString()))
                obj.BreakObject(collision);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<InteractableObj>())
        {
            InteractableObj obj = collision.gameObject.GetComponent<InteractableObj>();

            ContactPoint2D contact = collision.GetContact(0);
            if (Vector2.Dot(contact.normal, Vector2.up) != 1f) return;

            if (Input.GetKey(KeyCode.S))
            {
                if (!collision.gameObject.CompareTag(InteractionType.Stump.ToString())) return;

                obj.Interact(InteractionType.Stump, collision);
            }
        }
    }
}
