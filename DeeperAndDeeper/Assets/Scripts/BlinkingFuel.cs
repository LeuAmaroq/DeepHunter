using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlinkingFuel : MonoBehaviour
{
    public GameManager gm;
    private Image uiEmergency;

    [SerializeField] private float blinkSpeed;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        uiEmergency = this.gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        if (gm.fuel < 2)
        {
            var tempColor = uiEmergency.color;
            tempColor.a = (Mathf.Sin(Time.time * blinkSpeed) + 1.0f) / 2.0f;
            uiEmergency.color = tempColor;
        }
        else
        {
            var tempColor = uiEmergency.color;
            tempColor.a = 0f;
            uiEmergency.color = tempColor;
        }
    }
}
