using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (SaveSystem.Instance.highScore == 0)
        {
            highScoreText.text = "Best Score";
        }
        else
        {
            highScoreText.text = "Best Score : " + SaveSystem.Instance.playerName + " : " + SaveSystem.Instance.highScore;
       }

    }

    // Update is called once per frame
    void Update()
    {
        if (SaveSystem.Instance.highScore == 0)
        {
            highScoreText.text = "Best Score";
        }
        else
        {
            highScoreText.text = "Best Score : " + SaveSystem.Instance.playerName + " : " + SaveSystem.Instance.highScore;
        }
    }
}
