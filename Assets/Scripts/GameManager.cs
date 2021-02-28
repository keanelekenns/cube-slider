using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public score score;
    bool gameHasEnded = false;
    public float restartDelay = 1.5f;
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

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
