using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    bool scoreSaved = false;

    // Update is called once per frame
    void Update()
    {
        if(!scoreSaved)
        {
            scoreText.text = player.position.z.ToString("0");
        }
    }

    public void SaveScore()
    {
        //This doesn't do much right now
        scoreSaved = true;
    }
}
