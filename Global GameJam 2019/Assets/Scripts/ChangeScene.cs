using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class ChangeScene : MonoBehaviour
{
    #region FIELDS
    public Image fadeOutUIImage;
    public float fadeSpeed = 0.3f;
    public enum FadeDirection
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }
    #endregion
    #region MONOBHEAVIOR
    public bool fading = false;
    void Update()
    {
        if (Time.timeSinceLevelLoad > 3 && !fading)
        {
            fading = true;
            StartCoroutine(FadeAndLoadScene(FadeDirection.Out));
        }

        if (Input.GetKeyDown("escape"))
        {
            if (SceneManager.GetActiveScene().buildIndex > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                Time.timeScale = 1F;
            }
            else
            {
                Application.Quit();
            }
        }
    }
    void OnEnable()
    {
        //StartCoroutine(Fade(FadeDirection.Out));

    }
    public void Skip()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion
    #region FADE
    private IEnumerator Fade(FadeDirection fadeDirection)
    {
        float alpha = (fadeDirection == FadeDirection.Out) ? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.Out) ? 0 : 1;
        if (fadeDirection == FadeDirection.Out)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            fadeOutUIImage.enabled = false;
        }
        else
        {
            fadeOutUIImage.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
    }
    #endregion
    #region HELPERS
    public IEnumerator FadeAndLoadScene(FadeDirection fadeDirection)
    {
        yield return Fade(fadeDirection);
        Debug.Log("scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out) ? -1 : 1);
    }
    #endregion
}