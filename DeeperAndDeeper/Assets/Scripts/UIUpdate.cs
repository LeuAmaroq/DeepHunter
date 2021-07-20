using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIUpdate : MonoBehaviour
{
    public GameManager gm;
    public MapManager mm;
    [Space(10)]
    public CameraShake[] cameraShake;
    public float shakeResourceDuration;
    public float shakeScreenDuration;
    public float shakeMagnitude;
    [Space(10)]
    public BlinkingResources fuelUI;
    public BlinkingResources torpedoUI;
    public BlinkingResources crewUI;
    public BlinkingResources hullUI;
    [Space(10)]
    public GameObject[] fuel;
    public GameObject[] torpedo;
    public GameObject[] crew;
    public GameObject[] hull;
    public int previousFuel;
    public int previousTorpedo;
    public int previousCrew;
    public int previousHull;
    public CameraShake fuelShake;
    public CameraShake torpedoShake;
    public CameraShake crewShake;
    public CameraShake hullShake;
    public AudioSource hullAS;
    public AudioSource resourceAS;
    [Space(10)]
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    [Space(10)]
    private int initialStory;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        mm = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>();
        resourceAS = this.gameObject.GetComponent<AudioSource>();
        initialStory = 0;

        previousFuel = gm.fuel;
        previousTorpedo = gm.torpedo;
        previousCrew = gm.crew;
        previousHull = gm.hull;

        // Update fuel
        for (int i = fuel.Length - 1; i >= 0; i--)
        {
            if (i > gm.fuel - 1)
            {
                fuel[i].SetActive(false);
            }
            else
            {
                fuel[i].SetActive(true);
            }
        }
        // Update torpedo
        for (int i = torpedo.Length - 1; i >= 0; i--)
        {
            if (i > gm.torpedo - 1)
            {
                torpedo[i].SetActive(false);
            }
            else
            {
                torpedo[i].SetActive(true);
            }
        }
        // Update crew
        for (int i = crew.Length - 1; i >= 0; i--)
        {
            if (i > gm.crew - 1)
            {
                crew[i].SetActive(false);
            }
            else
            {
                crew[i].SetActive(true);
            }
        }
        // Update hull
        for (int i = hull.Length - 1; i >= 0; i--)
        {
            if (i > gm.hull - 1)
            {
                hull[i].SetActive(false);
            }
            else
            {
                hull[i].SetActive(true);
            }
        }
    }

    void Update()
    {

        // Gaining fuel
        if (gm.fuel > previousFuel)
        {
            // Play resource gaining sound

            // Update fuel
            for (int i = fuel.Length - 1; i >= 0; i--)
            {
                if (i > gm.fuel - 1)
                {
                    fuel[i].SetActive(false);
                }
                else
                {
                    fuel[i].SetActive(true);
                }
            }
            // Make the UI blink green
            StartCoroutine(fuelUI.BlinkingUI(shakeResourceDuration, false));
            previousFuel = gm.fuel;
        }
        // Losing fuel
        else if (gm.fuel < previousFuel)
        {
            // Play resource losing sound

            // Update fuel
            for (int i = fuel.Length - 1; i >= 0; i--)
            {
                if (i > gm.fuel - 1)
                {
                    fuel[i].SetActive(false);
                }
                else
                {
                    fuel[i].SetActive(true);
                }
            }
            // Make the UI blink red and slightly shake
            if (gm.fuel > 0)
            {
                StartCoroutine(fuelShake.Shake(shakeResourceDuration, 1f));
                StartCoroutine(fuelUI.BlinkingUI(shakeResourceDuration, true));
            }
            previousFuel = gm.fuel;
        }

        // Gaining torpedo
        if (gm.torpedo > previousTorpedo)
        {
            // Play resource gaining sound

            // Update torpedo
            for (int i = torpedo.Length - 1; i >= 0; i--)
            {
                if (i > gm.torpedo - 1)
                {
                    torpedo[i].SetActive(false);
                }
                else
                {
                    torpedo[i].SetActive(true);
                }
            }
            // Make the UI blink green
            StartCoroutine(torpedoUI.BlinkingUI(shakeResourceDuration, false));
            previousTorpedo = gm.torpedo;
        }
        // Losing torpedo
        else if (gm.torpedo < previousTorpedo)
        {
            // Play resource losing sound

            // Update torpedo
            for (int i = torpedo.Length - 1; i >= 0; i--)
            {
                if (i > gm.torpedo - 1)
                {
                    torpedo[i].SetActive(false);
                }
                else
                {
                    torpedo[i].SetActive(true);
                }
            }
            // Make the UI blink red and slightly shake
            if (gm.torpedo > 0)
            {
                StartCoroutine(torpedoShake.Shake(shakeResourceDuration, 1f));
                StartCoroutine(torpedoUI.BlinkingUI(shakeResourceDuration, true));
            }
            previousTorpedo = gm.torpedo;
        }

        // Gaining crew
        if (gm.crew > previousCrew)
        {
            // Play resource gaining sound

            // Update crew
            for (int i = crew.Length - 1; i >= 0; i--)
            {
                if (i > gm.crew - 1)
                {
                    crew[i].SetActive(false);
                }
                else
                {
                    crew[i].SetActive(true);
                }
            }
            // Make the UI blink green
            StartCoroutine(crewUI.BlinkingUI(shakeResourceDuration, false));
            previousCrew = gm.crew;
        }
        // Losing crew
        else if (gm.crew < previousCrew)
        {
            // Play resource losing sound

            // Update crew
            for (int i = crew.Length - 1; i >= 0; i--)
            {
                if (i > gm.crew - 1)
                {
                    crew[i].SetActive(false);
                }
                else
                {
                    crew[i].SetActive(true);
                }
            }
            // Make the UI blink red and slightly shake
            if (gm.crew > 0)
            {
                StartCoroutine(crewShake.Shake(shakeResourceDuration, 1f));
                StartCoroutine(crewUI.BlinkingUI(shakeResourceDuration, true));
            }
            previousCrew = gm.crew;
        }

        // Gaining hull
        if (gm.hull > previousHull)
        {
            // Play hull gaining sound
            hullAS.clip = gm.hullGainSound;
            hullAS.Play();
            // Update hull
            for (int i = hull.Length - 1; i >= 0; i--)
            {
                if (i > gm.hull - 1)
                {
                    hull[i].SetActive(false);
                }
                else
                {
                    hull[i].SetActive(true);
                }
            }
            // Make the UI blink green
            StartCoroutine(hullUI.BlinkingUI(shakeResourceDuration, false));
            previousHull = gm.hull;
        }
        // Losing hull
        else if (gm.hull < previousHull)
        {
            // Play hull losing sound
            hullAS.clip = gm.hullLoseSound;
            hullAS.Play();
            // Update hull
            for (int i = hull.Length - 1; i >= 0; i--)
            {
                if (i > gm.hull - 1)
                {
                    hull[i].SetActive(false);
                }
                else
                {
                    hull[i].SetActive(true);
                }
            }
            // Make the UI blink red and shake
            if (gm.hull > 0)
            {
                StartCoroutine(hullShake.Shake(shakeResourceDuration, 1f));
                StartCoroutine(hullUI.BlinkingUI(shakeResourceDuration, true));
            }
            // Make whole game UI shake
            for (int i = 0; i < cameraShake.Length; i++)
            {
                StartCoroutine(cameraShake[i].Shake(shakeScreenDuration, shakeMagnitude));
            }
            previousHull = gm.hull;
        }


        if (gm.end)
        {
            if (initialStory > 1)
            {
                gm.fuel--;
            }
            else
            {
                initialStory++;
            }
            mm.hideNav.gameObject.GetComponent<Image>().raycastTarget = false;
            gm.end = false;
            // Close the eventScreen
            Destroy(GameObject.FindGameObjectWithTag("EventScreen"));
        }

        gameOverScreen.SetActive(gm.gameover);
        victoryScreen.SetActive(gm.gameEnding > 0);
    }
}
