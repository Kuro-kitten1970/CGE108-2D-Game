using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public enum SceneSelection
    {
        MainMenu,
        Gameplay,
        Bonus01
    }

    private static float _score;
    private static float _coin;
    private static int _playerHealth = 3;
    private static Vector2 _savePoint;

    public static float Coin { get { return _coin; } set { _coin = value; } }
    public static float Score { get { return _score; } set { _score = value; } }
    public static int PlayerHealth { get { return _playerHealth; } }
    public static Vector2 SavePoint { get { return _savePoint; } set { _savePoint = value; } }
    public static bool IsRun;
    public static bool IsJump;
    public static bool IsGrounded;

    public static bool IsDead = false;
    public static bool IsWin = false;

    #region Change Scene
    public static void SceneChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        GameEventBus.Subcribe(GameEventsType.GAMEOVER, GameOver);
        GameEventBus.Subcribe(GameEventsType.FINISH, WinGame);
    }

    private void OnDisable()
    {
        GameEventBus.Subcribe(GameEventsType.GAMEOVER, GameOver);
        GameEventBus.Subcribe(GameEventsType.FINISH, WinGame);
    }

    public static void SceneChange(SceneSelection scene)
    {
        SceneManager.LoadScene(scene.ToString());
        Time.timeScale = 1f;
    }
    #endregion

    public static void ExitGame() => Application.Quit();

    public static void PlayerGotAttack()
    {
        _playerHealth--;

        if (PlayerHealth <= 0)
        {
            IsDead = true;
            GameEventBus.Publish(GameEventsType.GAMEOVER);
        }
    } 

    public static void GameOver()
    {
        InGameController inGameController = FindAnyObjectByType<InGameController>();
        inGameController.GameOverMenu();
    }

    public static void WinGame()
    {
        InGameController inGameController = FindAnyObjectByType<InGameController>();
        inGameController.WinMenu();
    }

    public static void ResetGame()
    {
        _coin = 0;
        _score = 0;
        _playerHealth = 3;
        _savePoint = Vector2.zero;
        IsDead = false;
    }
}
