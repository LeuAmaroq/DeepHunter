using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkStoryHandler : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;

    public Text textPrefab;
    public Button buttonPrefab;

    public GameManager gm;
    public MapManager mm;

    // Start is called before the first frame update
    void Start()
    {
        LoadFullStory();
    }

    void Update()
    {
        gm.fuel = (int)story.variablesState["fuel"];
        gm.torpedo = (int)story.variablesState["torpedo"];
        gm.crew = (int)story.variablesState["crew"];
        gm.hull = (int)story.variablesState["hull"];
        gm.encounter = (bool)story.variablesState["encounter"];
        gm.gameEnding = (int)story.variablesState["gameEnding"];
        gm.end = (bool)story.variablesState["end"];
    }

    public void LoadFullStory()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        mm = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>();

        story = new Story(inkJSON.text);

        mm.hideNav.gameObject.GetComponent<Image>().raycastTarget = true;

        // Load Unity GameManager variables to story
        story.variablesState["fuel"] = gm.fuel;
        story.variablesState["torpedo"] = gm.torpedo;
        story.variablesState["crew"] = gm.crew;
        story.variablesState["hull"] = gm.hull;
        story.variablesState["encounter"] = gm.encounter;

        RefreshUI();
    }

    void RefreshUI()
    {
        EraseUI();

        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = LoadStoryChunk();
        storyText.transform.SetParent(mm.choiceText.gameObject.transform, false);

        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            choiceButton.transform.SetParent(mm.choiceButtons.gameObject.transform, false);
            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = choice.text;

            choiceButton.onClick.AddListener(delegate
            {
                ChooseStoryChoice(choice);
            });
        }
    }

    void EraseUI()
    {
        for (int i = 0; i < mm.choiceText.transform.childCount; i++)
        {
            Destroy(mm.choiceText.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < mm.choiceButtons.transform.childCount; i++)
        {
            Destroy(mm.choiceButtons.transform.GetChild(i).gameObject);
        }
    }

    void ChooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshUI();
    }

    string LoadStoryChunk()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.ContinueMaximally();
        }

        return text;
    }
}
