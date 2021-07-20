using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeButton : MonoBehaviour
{
    public int code;

    public GameObject eventScreen;

    public MapManager mm;
    public InkStoryHandler sh;

    public List<int> possiblePath;

    public bool visited;

    public GameManager gm;

    public void Start()
    {
        mm = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        visited = false;
    }

    public void LoadNewStory()
    {
        gm.activeNode = code;
        eventScreen = Instantiate(Resources.Load("eventScreen")) as GameObject;
        eventScreen.transform.SetParent(mm.canvasNodes.gameObject.transform, false);
        sh = eventScreen.GetComponent<InkStoryHandler>();

        if (!visited)
        {
            sh.inkJSON = mm.nodes[code];
            gm.visitedNodes.Add(code);
            visited = true;
        }
        else
        {
            sh.inkJSON = mm.revisitingNode;
        }
        sh.LoadFullStory();
    }
}
