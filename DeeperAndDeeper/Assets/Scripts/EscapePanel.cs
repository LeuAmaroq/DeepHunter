using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePanel : MonoBehaviour
{
    public GameObject escapeWindow;

    private bool escapeOpen;

    private void Start()
    {
        escapeOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escapeOpen = !escapeOpen;
            escapeWindow.gameObject.SetActive(escapeOpen);
        }
    }
}
