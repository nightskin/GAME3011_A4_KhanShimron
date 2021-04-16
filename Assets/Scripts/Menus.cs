using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public static Menus instance;
    public enum Difficulty
    {
        EASY,
        NORMAL,
        HARD
    }

    public Difficulty diff;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void EasyGame()
    {
        instance.diff = Difficulty.EASY;
        SceneManager.LoadScene("GameScene");
    }

    public void NormalGame()
    {
        instance.diff = Difficulty.NORMAL;
        SceneManager.LoadScene("GameScene");
    }

    public void HardGame()
    {
        instance.diff = Difficulty.HARD;
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void DifficultySelect()
    {
        SceneManager.LoadScene("DifficultySelect");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
}
