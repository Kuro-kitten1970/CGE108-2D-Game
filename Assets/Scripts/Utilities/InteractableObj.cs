using TMPro;
using UnityEngine;

public class InteractableObj : MonoBehaviour, IInteractable, IBreakable
{
    [Header("Mystery Box Properties")]
    [SerializeField] private int _maxInteraction;
    [SerializeField] private Sprite _newSprite;

    private ScoreDisplay _display;
    private SpriteRenderer _sprite;

    private int _interactCount = 0;

    private void Start()
    {
        _display = FindAnyObjectByType<ScoreDisplay>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Interact(InteractionType type, Collision2D collision)
    {
        switch (type)
        {
            case InteractionType.MysteryBox:
                GameManager.Coin++;
                _display.UpdateCoin(GameManager.Coin);
                _interactCount++;

                if (_interactCount == _maxInteraction)
                {
                    collision.gameObject.tag = InteractionType.UnbreakBox.ToString();
                    _sprite.sprite = _newSprite;
                }
                break;
            case InteractionType.Stump:
                GameManager.SceneChange(GameManager.SceneSelection.Bonus01);
                break;
            default: Debug.Log("Error Type Not Found!"); break;
        }
    }

    public void BreakObject(Collision2D collision)
    {
        GameManager.Score += 100;
        _display.UpdateScore(GameManager.Score);
        Destroy(gameObject);
    }
}
