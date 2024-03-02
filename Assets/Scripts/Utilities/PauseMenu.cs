using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    InGameController gameController;

    private void Start()
    {
        gameController = GetComponentInParent<InGameController>();
    }

#region Events Register
    private void OnEnable()
    {
        GameEventBus.Subcribe(GameEventsType.RESUME, OnResume);
        GameEventBus.Subcribe(GameEventsType.RESTART, OnRestart);
        GameEventBus.Subcribe(GameEventsType.MAINMENU, OnMainMenu);
        GameEventBus.Subcribe(GameEventsType.RESTART, OnQuit);
    }

    private void OnDisable()
    {
        Debug.Log("Disable Event");
        GameEventBus.UnSubcribe(GameEventsType.RESUME, OnResume);
        GameEventBus.UnSubcribe(GameEventsType.RESTART, OnRestart);
        GameEventBus.UnSubcribe(GameEventsType.MAINMENU, OnMainMenu);
        GameEventBus.UnSubcribe(GameEventsType.RESTART, OnQuit);
    }

    private void OnResume()
    {
        gameController.HideMenu();
    }

    private void OnRestart()
    {
        GameManager.ResetGame();
        GameManager.SceneChange(GameManager.SceneSelection.Gameplay);
    }

    private void OnMainMenu()
    {
        GameManager.ResetGame();
        GameManager.SceneChange(GameManager.SceneSelection.MainMenu);
    }

    private void OnQuit()
    {
        GameManager.ExitGame();
    }
#endregion

    public void ResumeButton() => GameEventBus.Publish(GameEventsType.RESUME);
    public void RestartButton() => GameEventBus.Publish(GameEventsType.RESTART);
    public void MainMenuButton() => GameEventBus.Publish(GameEventsType.MAINMENU);
    public void QuitButton() => GameEventBus.Publish(GameEventsType.MAINMENU);
}
