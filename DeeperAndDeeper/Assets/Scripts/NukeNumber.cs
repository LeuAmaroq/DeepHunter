using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NukeNumber : MonoBehaviour
{
    public GameManager gm;

    public Sprite nn0;
    public Sprite nn1;
    private Image nn;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        nn = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameEnding == 1)
        {
            nn.sprite = nn0;
        }
        else
        {
            nn.sprite = nn1;
        }
    }
}
