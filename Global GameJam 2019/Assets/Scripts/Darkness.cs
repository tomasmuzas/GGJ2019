using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Darkness : MonoBehaviour
{
    public float CurrentDarkness = 0;
    public float DarknessSpeed = 0.25f;
    float TimeOnLastUpdate = 0;
    public bool ItsDarkening = false;

    public GameObject[] darkSprites;
    public GameObject[] pulsingSprites;

    void Start()
    {
        StopDarkening();
    }

    void Update()
    {
        if (ItsDarkening)
        {
            IncreaseDarkness(Time.timeSinceLevelLoad - TimeOnLastUpdate);
            TimeOnLastUpdate = Time.timeSinceLevelLoad;
        }
    }

    public void StartDarkening()
    {
        TimeOnLastUpdate = Time.timeSinceLevelLoad;
        ItsDarkening = true;
        foreach (var sprite in pulsingSprites)
        {
            sprite.GetComponent<Image>().transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void StopDarkening()
    {
        CurrentDarkness = 0;
        SetDarkness();
        ItsDarkening = false;
        TimeOnLastUpdate = 0;
        foreach (var sprite in pulsingSprites)
        {
            sprite.GetComponent<Image>().transform.localScale = new Vector3(0, 0, 0);
        }
    }
    void IncreaseDarkness(float delta)
    {
        CurrentDarkness = CurrentDarkness + delta * DarknessSpeed;
        SetDarkness();
    }

    void SetDarkness()
    {
        foreach (var sprite in darkSprites)
        {
            var image = sprite.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = CurrentDarkness;
            image.color = tempColor;
        }
    }
}
