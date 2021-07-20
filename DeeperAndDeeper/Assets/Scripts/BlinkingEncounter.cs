using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingEncounter : MonoBehaviour
{
    public GameManager gm;
    public Sprite uiUVD;
    public Sprite uiWarning;
    private Image uiEncounter;

    private bool warningActive;
    private bool high;
    private bool resetWarning;

    [SerializeField] private float blinkSpeed;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        uiEncounter = this.gameObject.GetComponent<Image>();
        resetWarning = false;
        high = false;
        warningActive = true;
    }

    private void Update()
    {
        if (gm.encounter)
        {
            var tempColor = uiEncounter.color;
            tempColor.a = (Mathf.Sin(Time.time * blinkSpeed) + 1.0f) / 2.0f;
            //Debug.Log(tempColor.a);
            uiEncounter.color = tempColor;

            if (warningActive && high == true && tempColor.a <= 0.05)
            {
                high = false;
                uiEncounter.sprite = uiUVD;
                warningActive = false;
            }

            if (!warningActive && high == true && tempColor.a <=0.05)
            {
                high = false;
                uiEncounter.sprite = uiWarning;
                warningActive = true;
            }

            if (tempColor.a >= 0.95 && high == false)
            {
                high = true;
            }

            if (resetWarning)
            {
                resetWarning = false;
            }
        }
        else
        {
            var tempColor = uiEncounter.color;
            tempColor.a = 0f;
            uiEncounter.color = tempColor;

            if (!resetWarning)
            {
                uiEncounter.sprite = uiWarning;
                resetWarning = true;
            }
        }
    }
}
