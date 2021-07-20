using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NodeDisplay : MonoBehaviour
{
    public GameManager gm;

    public Node node;

    public Text nameText;
    public Text textText;
    public Text[] choicesText;
    public Button[] choicesButton;

    public Node[] specialNodes;

    public int changeFuel;
    public int changeTorpedo;
    public int changeCrew;
    public int changeHull;
    public int specialNodeCode;

    [SerializeField] UnityEvent UpdateUI;

    // Start is called before the first frame update
    void Start()
    {
        LoadNewNode(node);
    }

    public void buttonChoice1()
    {
        ParseResult(node.resultTexts[0]);
        ClosingChoice();
    }

    public void buttonChoice2()
    {
        ParseResult(node.resultTexts[1]);
        ClosingChoice();
    }

    public void buttonChoice3()
    {
        ParseResult(node.resultTexts[2]);
        ClosingChoice();
    }

    void ParseResult(string text)
    {
        //char[] separators = { ',', ';', '|' };
        string[] strValues = text.Split(';');

        textText.text = strValues[0];
        choicesText[0].text = strValues[1];
        changeFuel = int.Parse(strValues[2]);
        changeTorpedo = int.Parse(strValues[3]);
        changeCrew = int.Parse(strValues[4]);
        changeHull = int.Parse(strValues[5]);
        specialNodeCode = int.Parse(strValues[6]);

        UpdateResources(changeFuel, changeTorpedo, changeCrew, changeHull);
    }

    public void UpdateResources(int f, int t, int c, int h)
    {
        gm.fuel = gm.fuel + f;
        gm.torpedo = gm.torpedo + t;
        gm.crew = gm.crew + c;
        gm.hull = gm.hull + h;

        UpdateUI.Invoke();
    }

    public void ClosingChoice()
    {
        // Trigger special event dialogue
        if (specialNodeCode != 0)
        {
            node = specialNodes[specialNodeCode - 1];
            LoadNewNode(node);
        }
        // Trigger closing dialogue
        else
        {
            for (int i = 1; i < choicesText.Length; i++)
            {
                choicesButton[i].gameObject.SetActive(false);
            }
            choicesButton[0].gameObject.SetActive(true);
        }
    }

    public void LoadNewNode(Node n)
    {
        for (int i = 0; i < 4; i++)
        {
            choicesText[i].text = "";
        }
        nameText.text = n.name;
        textText.text = n.text;
        choicesButton[0].gameObject.SetActive(false);

        for (int i = 1; i < n.choices.Length + 1; i++)
        {
            choicesButton[i].gameObject.SetActive(true);
            choicesButton[i].interactable = true;
            choicesText[i].text = n.choices[i - 1];
        }
    }
}
