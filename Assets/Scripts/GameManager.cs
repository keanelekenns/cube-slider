using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public score score;
    public float restartDelay = 1.5f;
    public GameObject levelCompleteUI;
    bool gameHasEnded = false;

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        if(!gameHasEnded)
        {
            Debug.Log("GAME OVER");
            gameHasEnded = true;
            score.SaveScore();
            Invoke("RestartGame", restartDelay);
        }
    }
    public void CompleteLevel()
    {
        score.SaveScore();
        levelCompleteUI.SetActive(true);
    }
}
