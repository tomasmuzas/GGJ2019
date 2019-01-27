using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWin : MonoBehaviour
{
    public GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = GameObject.Find("GameOver");
        GameOver.gameObject.SetActive(false);
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

    public void GameLose()
    {
        // if (score > highscore)
        // {
        //     PlayerPrefs.SetInt("highscore", score);
        // }
        // PlayGames.AddScoreToLeaderBoard(GPGSIds.leaderboard_score, score);
        Time.timeScale = 0.0F;
        GameOver.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        GameOver.gameObject.SetActive(true);
        GetComponent<AudioSource>().Play();
    }
}
