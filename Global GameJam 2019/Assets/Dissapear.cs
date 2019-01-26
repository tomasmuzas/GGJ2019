using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dissapear : MonoBehaviour
{
    public GameObject[] Sprites;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var transp = 5 - Time.timeSinceLevelLoad;
        foreach (var sprite in Sprites)
        {
            var image = sprite.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = transp;
            image.color = tempColor;
        }
    }
}
