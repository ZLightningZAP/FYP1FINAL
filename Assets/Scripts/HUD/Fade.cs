using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public float FadeSpeed = 0.1f;
    public int SceneInt = 0;
    public CanvasGroup canvasgroup;

    public void FadeMe()
    {
        StartCoroutine(DoFade());
    }

    private IEnumerator DoFade()
    {
        //CanvasGroup canvasgroup = GetComponent<CanvasGroup>();
        while (canvasgroup.alpha > 0)
        {
            canvasgroup.alpha -= Time.deltaTime * FadeSpeed;
            yield return null;
        }
        canvasgroup.interactable = false;
        yield return null;

        if (canvasgroup.alpha <= 0)
        {
            SceneManager.LoadScene(SceneInt);
        }
        yield return null;
    }
}