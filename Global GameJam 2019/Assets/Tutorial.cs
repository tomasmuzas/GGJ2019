using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] TutorialImages;

    void Start()
    {
        if (PlayerPrefs.GetInt("Watched Tutorial", 0) > 0)
        {
            foreach (var img in TutorialImages)
            {
                Destroy(img);
            }
        }
    }

    public void HideTutorial()
    {
        PlayerPrefs.SetInt("Watched Tutorial", 1);
        foreach (var img in TutorialImages)
        {
            Destroy(img);
        }
    }
}
