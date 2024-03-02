using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private TMP_Text _healthText;

    private void OnEnable()
    {
        UpdateScore(GameManager.Score);
        UpdateCoin(GameManager.Coin);
        UpdateHealth(GameManager.PlayerHealth);
    }

    public void UpdateScore(float n) => _scoreText.text = "Score : " + n;
    public void UpdateCoin(float n) => _coinText.text = "Coin : " + n;
    public void UpdateHealth(float n) => _healthText.text = "Player Health : " + n;
}
