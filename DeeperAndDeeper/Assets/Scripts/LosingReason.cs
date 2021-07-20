using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosingReason : MonoBehaviour
{
    public GameManager gm;

    public Sprite sentenceHull;
    public Sprite sentenceFuel;
    public Sprite sentenceCrew;

    public Image losingSentence;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        losingSentence = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.fuel <= 0)
        {
            losingSentence.sprite = sentenceFuel;
        }
        else if (gm.hull <= 0)
        {
            losingSentence.sprite = sentenceHull;
        }
        else if (gm.crew <= 0)
        {
            losingSentence.sprite = sentenceCrew;
        }

    }
}
