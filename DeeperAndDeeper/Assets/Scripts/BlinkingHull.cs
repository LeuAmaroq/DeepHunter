using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlinkingHull : MonoBehaviour
{
    public GameManager gm;
    private Image uiEmergency;

    [SerializeField] private float blinkSpeed;
    [SerializeField] private bool musicPlay;

    private AudioSource currentSource;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        uiEmergency = this.gameObject.GetComponent<Image>();

        currentSource = this.gameObject.GetComponent<AudioSource>();
        currentSource.clip = gm.alarmSound;
        musicPlay = false;
    }

    private void Update()
    {
        if (gm.hull == 1)
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

        if ((gm.fuel == 1 || gm.hull == 1) && !musicPlay)
        {
            currentSource.Play();
            musicPlay = !musicPlay;
        }
        else if (((gm.fuel > 1 && gm.hull > 1) || (gm.fuel <= 0 || gm.hull <= 0)) && musicPlay)
        {
            currentSource.Stop();
            musicPlay = !musicPlay;
        }
    }
}
