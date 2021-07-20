using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Node", menuName = "Node")]
public class Node : ScriptableObject
{
    public new string name;
    public string text;

    public string[] choices;
    public string[] resultTexts;
}
