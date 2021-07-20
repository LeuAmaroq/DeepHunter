using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Live Value Game Variables")]
    public int fuel;
    public int torpedo;
    public int crew;
    public int hull;
    public bool encounter;
    public int gameEnding;
    [Space(10)]
    [Header("Initial Value Game Variables")]
    [SerializeField] private int initFuel;
    [SerializeField] private int initTorpedo;
    [SerializeField] private int initCrew;
    [SerializeField] private int initHull;
    [SerializeField] private bool initEncounter;
    [SerializeField] private int initGameEnding;
    [Space(10)]
    [Header("Max Value Game Variables")]
    [SerializeField] private int maxFuel;
    [SerializeField] private int maxTorpedo;
    [SerializeField] private int maxCrew;
    [SerializeField] private int maxHull;
    [Space(10)]
    public int activeNode;
    public List<int> visitedNodes;
    [Space(10)]
    public bool end;
    [Space(10)]
    public bool canvaMap;
    public bool canvaNode;
    [Space(10)]
    public bool gameover;
    [Space(10)]
    [SerializeField] public List<int> endingsCompleted;
    [Space(10)]
    [SerializeField] private AudioClip encounterMusic;
    [SerializeField] private AudioClip explorationMusic;
    [SerializeField] public AudioClip alarmSound;
    [SerializeField] public AudioClip btnHoverSound;
    [SerializeField] public AudioClip btnClickSound;
    [SerializeField] public AudioClip hullLoseSound;
    [SerializeField] public AudioClip hullGainSound;
    [SerializeField] public AudioClip resourceLoseSound;
    [SerializeField] public AudioClip resourceGainSound;
    [Space(10)]
    [SerializeField] private bool musicSwapped;
    private AudioSource currentSource;
    


    void Start()
    {
        musicSwapped = false;
        fuel = initFuel;
        torpedo = initTorpedo;
        crew = initCrew;
        hull = initHull;
        encounter = initEncounter;
        gameEnding = initGameEnding;

        gameover = false;

        maxFuel = 5;
        maxTorpedo = 8;
        maxCrew = 5;
        maxHull = 3;

        currentSource = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (fuel > maxFuel)
        {
            fuel = 5;
        }
        if (torpedo > maxTorpedo)
        {
            torpedo = 8;
        }
        if (crew > maxCrew)
        {
            crew = 5;
        }
        if (hull > maxHull)
        {
            hull = 3;
        }

        if ((crew <= 0 || fuel <= 0 || hull <= 0) && !gameover)
        {
            gameover = true;
        }

        if (encounter && musicSwapped)
        {
            currentSource.clip = encounterMusic;
            currentSource.Play();
            musicSwapped = !musicSwapped;
        }
        else if (!encounter && !musicSwapped)
        {
            currentSource.clip = explorationMusic;
            currentSource.Play();
            musicSwapped = !musicSwapped;
        }

        if (gameEnding > 0)
        {
            fuel = initFuel;
            torpedo = initTorpedo;
            crew = initCrew;
            hull = initHull;
            encounter = initEncounter;
            gameover = false;
        }

        if (gameEnding > 0 && !endingsCompleted.Contains(gameEnding))
        {
            endingsCompleted.Add(gameEnding);
        }
    }

    public void ResetVariables()
    {
        // Reset all the game variables
        fuel = initFuel;
        torpedo = initTorpedo;
        crew = initCrew;
        hull = initHull;
        encounter = initEncounter;
        gameEnding = 0;
        visitedNodes.Clear();
        gameover = false;
    }

    public void ReloadScene()
    {
        ResetVariables();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
