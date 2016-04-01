using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public float FadeSpeed = 0.1f;

    public void FadeMe()
    {
        StartCoroutine(DoFade());
    }

    private IEnumerator DoFade()
    {
        CanvasGroup canvasgroup = GetComponent<CanvasGroup>();
        while (canvasgroup.alpha > 0)
        {
            canvasgroup.alpha -= Time.deltaTime * FadeSpeed;
            yield return null;
        }
        canvasgroup.interactable = false;
        yield return null;

        if (canvasgroup.alpha <= 0)
        {
            SceneManager.LoadScene(1);
        }
        yield return null;
    }

    public void FadeIn()
    {
        StartCoroutine(DoFadeIn());
    }

    private IEnumerator DoFadeIn()
    {
        CanvasGroup canvasgroup = GetComponent<CanvasGroup>();
        while (canvasgroup.alpha > 0)
        {
            canvasgroup.alpha += Time.deltaTime * FadeSpeed;
            yield return null;
        }
        canvasgroup.interactable = false;
        yield return null;
    }
}