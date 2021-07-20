using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextColorUpdate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text text;

    // This doesn't work as intended. fadeDuration should be a changing value to make it fade.
    private float fadeDuration;
    private Color a;
    private Color b;

    private void Start()
    {
        a = this.gameObject.GetComponent<Button>().colors.highlightedColor;
        b = this.gameObject.GetComponent<Button>().colors.normalColor;
        fadeDuration = this.gameObject.GetComponent<Button>().colors.fadeDuration;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FadeColor(a, b, fadeDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FadeColor(b, a, fadeDuration);
    }

    public void FadeColor(Color a, Color b, float t)
    {
        text.color = Color.Lerp(a, b, t);
    }
}
