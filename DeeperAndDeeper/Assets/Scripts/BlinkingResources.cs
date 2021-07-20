using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingResources : MonoBehaviour
{
    [SerializeField] private bool resetColor;
    private bool isLosing;
    private bool isWinning;
    [SerializeField] private float blinkSpeed;
    [Space(10)]
    private Color w;
    private Color g;
    private Color r;
    [Space(10)]
    [SerializeField] private Image[] uiElement;

    // Start is called before the first frame update
    void Start()
    {
        isLosing = false;
        resetColor = true;
        w = new Color(1, 1, 1, 1);
        g = new Color(0.2980392f, 0.9176471f, 0.5176471f, 1);
        r = new Color(0.8313726f, 0.2039216f, 0.07450981f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // Blinking for red
        if (isLosing)
        {
            var t = Mathf.Round(Mathf.PingPong(Time.time * blinkSpeed, 1.0f));
            for (int i = 0; i < uiElement.Length; i++)
            {
                uiElement[i].color = Color.Lerp(r, w, t);
            }
            resetColor = true;
        }
        else if (isWinning)
        {
            var t = Mathf.Round(Mathf.PingPong(Time.time * blinkSpeed, 1.0f));
            for (int i = 0; i < uiElement.Length; i++)
            {
                uiElement[i].color = Color.Lerp(g, w, t);
            }
            resetColor = true;
        }
        else if (resetColor)
        {
            for (int i = 0; i < uiElement.Length; i++)
            {
                uiElement[i].color = w;
            }
            resetColor = false;
        }
    }

    public IEnumerator BlinkingUI(float blinkingDuration, bool isRed)
    {
        if (isRed)
        {
            isLosing = true;
            yield return new WaitForSeconds(blinkingDuration);
            isLosing = false;
        }
        else
        {
            isWinning = true;
            yield return new WaitForSeconds(blinkingDuration);
            isWinning = false;
        }
        yield return null;
    }
}
