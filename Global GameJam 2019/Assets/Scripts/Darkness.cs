using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Darkness : MonoBehaviour
{
    public float CurrentDarkness = 0;
    public float DarknessSpeed = 0.25f;
    float TimeOnLastUpdate = 0;
    void Update()
    {
        IncreaseDarkness(Time.timeSinceLevelLoad - TimeOnLastUpdate);
        TimeOnLastUpdate = Time.timeSinceLevelLoad;
    }

    public GameObject[] darkSprites;
    void IncreaseDarkness(float delta)
    {
        CurrentDarkness = CurrentDarkness + delta * DarknessSpeed;
        foreach (var sprite in darkSprites)
        {
            var image = sprite.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = CurrentDarkness;
            image.color = tempColor;
        }
    }
}
