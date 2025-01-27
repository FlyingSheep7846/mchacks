using System.Collections;
using System;
using TMPro;
using UnityEngine;

public class TextNotice : MonoBehaviour
{
    private CanvasGroup cg;
    private TextMeshProUGUI textmesh;

    void Awake(){
        textmesh = GetComponent<TextMeshProUGUI>();
        cg = GetComponent<CanvasGroup>();

    }

    IEnumerator Start(){
        textmesh.text = "+" + ClickingManager.instance.numberBought * (int)Math.Pow(2.0, ClickingManager.instance.upgradeMultiplier);

        LeanTween.alphaCanvas(cg, 0f, 0.4f);
        LeanTween.moveLocalY(gameObject, transform.localPosition.y + 50f, 0.4f);
        yield return new WaitForSecondsRealtime(0.4f);
        Destroy(gameObject);
    }
}
