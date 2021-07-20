using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public GameManager gm;

    public Sprite sentence1;
    public Sprite sentence2;
    public Sprite sentence3;
    public Sprite sentence4;

    public Sprite ending1;
    public Sprite ending2;
    public Sprite ending3;
    public Sprite ending4;

    public Image victorySentence;
    public Image endingsCompleted;

    public GameObject fullPercentImage;
    public GameObject newGameBtn;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        victorySentence = this.gameObject.GetComponent<Image>();
        fullPercentImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (gm.gameEnding)
        {
            case 1:
                victorySentence.sprite = sentence1;
                break;
            case 2:
                victorySentence.sprite = sentence2;
                break;
            case 3:
                victorySentence.sprite = sentence3;
                break;
            case 4:
                victorySentence.sprite = sentence4;
                break;
            default:
                break;
        }

        if (gm.endingsCompleted.Contains(1) && gm.endingsCompleted.Contains(2) && gm.endingsCompleted.Contains(3) && gm.endingsCompleted.Contains(4))
        {
            newGameBtn.SetActive(false);
            fullPercentImage.SetActive(true);
        }

        switch (gm.endingsCompleted.Count)
        {
            case 1:
                endingsCompleted.sprite = ending1;
                break;
            case 2:
                endingsCompleted.sprite = ending2;
                break;
            case 3:
                endingsCompleted.sprite = ending3;
                break;
            case 4:
                endingsCompleted.sprite = ending4;
                break;
            default:
                break;
        }

    }
}
