using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    //public Node[] allNodes;
    //public Node[] nodes;
    public TextAsset[] allNodes;
    public TextAsset[] nodes;

    public TextAsset endingNode;
    public TextAsset revisitingNode;

    public List<int> numberAllNodes;
    public int numberOfNodes;
    public Button[] buttonNodes;

    public Button button;
    public GameObject map;
    public GameObject choiceText;
    public GameObject choiceButtons;
    public GameObject hideNav;

    public Canvas canvasNodes;
    public Image eventScreen;

    public Vector2[] nodePositions;

    public float nbCol;
    public float nbRow;
    [Range(0, 0.5f)] public float gridXOffset;
    [Range(0, 0.5f)] public float gridYOffset;

    private int pathCode;

    public GameManager gm;
    public Sprite visitedSprite;
    public Sprite highlightedSprite;
    public Sprite unvisitedSprite;
    public Sprite activeSprite;

    public GameObject enemyBase;

    public Vector2 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gm.gameover = false;

        // Instantiate all the arrays and lists
        buttonNodes = new Button[numberOfNodes];
        nodes = new TextAsset[numberOfNodes];
        numberAllNodes = new List<int>(allNodes.Length);

        // Instantiate starting position of the first reference node
        startingPosition = new Vector2(0.7f, 0.345f);

        // Populate with int the reference List<int> for allNodes[] to avoid copying twice the same event from allNodes[] to nodes[]
        for (int i = 0; i < allNodes.Length; i++)
        {
            numberAllNodes.Add(i);
        }

        CreateGrid();

        // Populate the first node with the 00 story
        InstantiateButton(0);
        nodes[0] = allNodes[numberAllNodes[0]];
        numberAllNodes.RemoveAt(0);
        buttonNodes[0].gameObject.GetComponent<NodeButton>().possiblePath.Add(1);
        buttonNodes[0].gameObject.GetComponent<NodeButton>().code = 0;

        // Populate the second node with the 01 story
        InstantiateButton(1);
        nodes[1] = allNodes[numberAllNodes[0]];
        numberAllNodes.RemoveAt(0);
        buttonNodes[1].gameObject.GetComponent<NodeButton>().code = 1;

        // Decide Layout for setting up the ending node
        int pathLayout = Random.Range(0, 3);
        int finalBossPos = Random.Range(0, 1);
        if (finalBossPos == 0)
        {
            switch (pathLayout)
            {
                case 0:
                        finalBossPos = 8;
                    break;
                case 1:
                        finalBossPos = 7;
                    break;
                case 2:
                        finalBossPos = 6;
                    break;
                case 3:
                        finalBossPos = 7;
                    break;
                default:
                    break;
            }
        }
        else
        {
            finalBossPos = 9;
        }

        for (int i = 2; i < numberOfNodes; i++)
        {
            InstantiateButton(i);
            if (i == finalBossPos)
            {
                nodes[i] = endingNode;
            }
            else
            {
                // Populate the nodes[] with some of the allNodes[] (no doubles)
                int index = Random.Range(0, numberAllNodes.Count);
                nodes[i] = allNodes[numberAllNodes[index]];
                numberAllNodes.RemoveAt(index);
            }
            // Assign a node from nodes[] to a button
            buttonNodes[i].gameObject.GetComponent<NodeButton>().code = i;
        }

        // Set up the links between nodes
        for (int i = 0; i < numberOfNodes; i++)
        {
            switch (i)
            {
                case 1:
                    switch (pathLayout)
                    {
                        case 0:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(2);
                            break;
                        case 1:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(2);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(4);
                            break;
                        case 2:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(2);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            break;
                        case 3:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(4);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            break;
                        default:
                            break;
                    }
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(2);
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(4);
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                    //GeneratePath(i);
                    break;

                case 2:
                    switch (pathLayout)
                    {
                        case 0:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(1);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(3);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            break;
                        case 1:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(1);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(6);
                            break;
                        case 2:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(1);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(6);
                            break;
                        case 3:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(3);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(6);
                            break;
                        default:
                            break;
                    }
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(3);
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(4);
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(6);

                    //// Check buttonNodes[1] to avoid crosspath
                    //if (buttonNodes[1].gameObject.GetComponent<NodeButton>().possiblePath.Contains(5))
                    //{
                    //    buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Remove(5);
                    //}
                    //GeneratePath(i);
                    break;

                case 3:
                    switch (pathLayout)
                    {
                        case 0:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(2);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(6);
                            break;
                        case 1:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(6);
                            break;
                        case 2:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(6);
                            break;
                        case 3:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(2);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(6);
                            break;
                        default:
                            break;
                    }
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(6);

                    //// Check buttonNodes[2] to avoid crosspath
                    //if (buttonNodes[2].gameObject.GetComponent<NodeButton>().possiblePath.Contains(6))
                    //{
                    //    buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Remove(6);
                    //}
                    //GeneratePath(i);
                    break;

                case 4:
                    switch (pathLayout)
                    {
                        case 0:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            break;
                        case 1:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(1);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                            break;
                        case 2:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(7);
                            break;
                        case 3:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(1);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                            break;
                        default:
                            break;
                    }
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(7);
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                    //GeneratePath(i);
                    break;

                case 5:
                    switch (pathLayout)
                    {
                        case 0:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(2);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(4);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(7);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(9);
                            break;
                        case 1:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(2);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(9);
                            break;
                        case 2:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(1);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(4);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(7);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                            break;
                        case 3:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(1);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(2);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                            break;
                        default:
                            break;
                    }
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(6);
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(7);
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(9);

                    //// Check buttonNodes[4] to avoid crosspath
                    //if (buttonNodes[4].gameObject.GetComponent<NodeButton>().possiblePath.Contains(8))
                    //{
                    //    buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Remove(8);
                    //}
                    //GeneratePath(i);
                    break;

                case 6:
                    switch (pathLayout)
                    {
                        case 0:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(3);
                            break;
                        case 1:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(2);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(3);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(9);
                            break;
                        case 2:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(2);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(3);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                            break;
                        case 3:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(2);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(3);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(9);
                            break;
                        default:
                            break;
                    }
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(9);
                    //// Check buttonNodes[5] to avoid crosspath
                    //if (buttonNodes[5].gameObject.GetComponent<NodeButton>().possiblePath.Contains(9))
                    //{
                    //    buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Remove(9);
                    //}
                    //GeneratePath(i);
                    break;

                case 7:
                    switch (pathLayout)
                    {
                        case 0:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                            break;
                        case 1:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                            break;
                        case 2:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(4);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            break;
                        case 3:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                            break;
                        default:
                            break;
                    }
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                    //GeneratePath(i);
                    break;

                case 8:
                    switch (pathLayout)
                    {
                        case 0:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(7);
                            break;
                        case 1:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(4);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(7);
                            break;
                        case 2:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(6);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(9);
                            break;
                        case 3:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(4);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(7);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(9);
                            break;
                        default:
                            break;
                    }
                    //buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(9);
                    //GeneratePath(i);
                    break;

                case 9:
                    switch (pathLayout)
                    {
                        case 0:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            break;
                        case 1:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(5);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(6);
                            break;
                        case 2:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                            break;
                        case 3:
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(6);
                            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Add(8);
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }

        // Instantiate the enemy base image at the same position as the final boss node
        SetEnemyBase(finalBossPos);

        // Start the story automatically after a while with the first node
        StartCoroutine(LateStart(0.1f));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        buttonNodes[0].onClick.Invoke();
    }

    public void InstantiateButton(int i)
    {
        // Instantiate the buttons that will store the nodes
        buttonNodes[i] = Instantiate(button) as Button;
        buttonNodes[i].transform.SetParent(map.transform, false);
        RectTransform parent = (RectTransform)buttonNodes[i].transform.parent;
        Vector2 nodePosition = Vector2.Scale(parent.rect.size, nodePositions[i] - parent.pivot);
        buttonNodes[i].transform.localPosition = nodePosition;
        buttonNodes[i].onClick.AddListener(() => canvasNodes.gameObject.SetActive(true));
        buttonNodes[i].onClick.AddListener(() => this.gameObject.GetComponent<MapManager>().UpdatePossibleNodes());
        //buttonNodes[i].onClick.AddListener(() => this.gameObject.GetComponent<MapManager>().UpdateVisitedNodes());
    }

    // Only used if the path is not using layouts
    public void GeneratePath(int i)
    {
        // Define how many paths exit this node and to where
        int count = buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.Count;
        int nbPath = Random.Range(1, count);
        int nbPathRemoved = count - nbPath;

        for (int y = 0; y < nbPathRemoved; y++)
        {
            int removeIndex = Random.Range(0, count);
            buttonNodes[i].gameObject.GetComponent<NodeButton>().possiblePath.RemoveAt(removeIndex);
            count--;
        }
    }

    public void CreateGrid()
    {
        // Instantiate the Vector2 array
        nodePositions = new Vector2[numberOfNodes];

        // Depending on the number of nodes make a grid of different size
        if (numberOfNodes < 6)
        {
            nbCol = 2f;
            nbRow = Mathf.Ceil((numberOfNodes-1) / nbCol);
        }
        else if (numberOfNodes < 11)
        {
            nbCol = 3f;
            nbRow = Mathf.Ceil((numberOfNodes - 1) / nbCol);
        }

        // Place nodePositions[0] to a fix location
        nodePositions[0] = startingPosition;

        // Assign all nodePositions[] with a random offset
        int currentNode = 1;

        float currentX = startingPosition.x;
        float currentY = startingPosition.y;
        for (int x = 0; x < nbCol; x++)
        {
            for (int y = 0; y < nbRow; y++)
            {
                if (currentNode >= numberOfNodes)
                {
                    break;
                }
                // Randomize offset
                float randX = Random.Range(0, 50);
                float randY = Random.Range(0, 50);

                // Set the nodePositions[] of the currentNode
                nodePositions[currentNode] = new Vector2(currentX + (randX/1000), currentY - (randY/1000));

                currentY = currentY - gridYOffset;
                currentNode++;
            }
            currentY = startingPosition.y;
            currentX = currentX + gridXOffset;
        }
    }

    public void SetEnemyBase(int bossPos)
    {
        enemyBase = Instantiate(enemyBase) as GameObject;
        enemyBase.transform.SetParent(map.transform, false);
        enemyBase.transform.position = buttonNodes[bossPos].transform.position;
    }

    public void UpdatePossibleNodes()
    {
        // untic all buttonNodes[] RaycastTarget & make them look default
        for (int i = 0; i < buttonNodes.Length; i++)
        {
            buttonNodes[i].gameObject.GetComponent<Image>().raycastTarget = false;
            buttonNodes[i].gameObject.GetComponent<Button>().interactable = true;

            if (gm.visitedNodes.Contains(i) && gm.activeNode != buttonNodes[i].gameObject.GetComponent<NodeButton>().code)
            {
                buttonNodes[i].gameObject.GetComponent<Image>().sprite = visitedSprite;
            }
            else
            {
                buttonNodes[i].gameObject.GetComponent<Image>().sprite = unvisitedSprite;
            }
        }

        // pull list from the buttonNodes[gm.activeNode] of possible nodes to go to and re-tic the buttonNodes[] RaycastTarget
        for (int i = 0; i < buttonNodes[gm.activeNode].gameObject.GetComponent<NodeButton>().possiblePath.Count; i++)
        {
            buttonNodes[buttonNodes[gm.activeNode].gameObject.GetComponent<NodeButton>().possiblePath[i]].gameObject.GetComponent<Button>().interactable = true;
            buttonNodes[buttonNodes[gm.activeNode].gameObject.GetComponent<NodeButton>().possiblePath[i]].gameObject.GetComponent<Image>().raycastTarget = true;
            buttonNodes[buttonNodes[gm.activeNode].gameObject.GetComponent<NodeButton>().possiblePath[i]].gameObject.GetComponent<Image>().sprite = highlightedSprite;
        }

        buttonNodes[gm.activeNode].gameObject.GetComponent<Image>().sprite = activeSprite;
        buttonNodes[gm.activeNode].gameObject.GetComponent<Button>().interactable = false;
    }
}
