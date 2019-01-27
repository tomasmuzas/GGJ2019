using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            //PlayGames.AddScoreToLeaderBoard(GPGSIds.leaderboard_score, score);
            SceneManager.LoadScene(0);
            Time.timeScale = 1F;
        }
    }
}
