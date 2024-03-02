using Unity.VisualScripting;
using UnityEngine;

public class InGameController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseBTN;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private bool _isMenuDisplay;

    private void OnEnable()
    {
        GameEventBus.Subcribe(GameEventsType.PAUSE, OnPause);
    }

    private void OnDisable()
    {
        GameEventBus.UnSubcribe(GameEventsType.PAUSE, OnPause);
    }

    private void OnPause()
    {
        DisplayMenu();
    }

    public void PauseButton()
    {
        GameEventBus.Publish(GameEventsType.PAUSE);
    }

    private void DisplayMenu()
    {
        if (_isMenuDisplay) return;

        _pauseBTN.SetActive(false);
        _pauseMenu.SetActive(true);
        _isMenuDisplay = true;
        Time.timeScale = 0f;
    }

    public void GameOverMenu()
    {
        if (_isMenuDisplay) return;

        _gameOverMenu.SetActive(true);
        _isMenuDisplay = true;
        Time.timeScale = 0f;
    }

    public void WinMenu()
    {
        if (_isMenuDisplay) return;

        _winMenu.SetActive(true);
        _isMenuDisplay = true;
        Time.timeScale = 0f;
    }

    public void HideMenu()
    {
        if (!_isMenuDisplay) return;

        _pauseBTN.SetActive(true);
        _pauseMenu.SetActive(false);
        _gameOverMenu.SetActive(false);
        _isMenuDisplay = false;
        Time.timeScale = 1f;
    }
}
