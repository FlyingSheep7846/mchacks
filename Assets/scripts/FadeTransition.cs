using System.Collections;
using UnityEngine;

public class FadeTransition : MonoBehaviour
{

    IEnumerator Start(){
        LeanTween.alphaCanvas(GetComponent<CanvasGroup>(), 0f, 1f).setIgnoreTimeScale(true);
        yield return new WaitForSecondsRealtime(1f);

        gameObject.SetActive(false);   
    }
}
