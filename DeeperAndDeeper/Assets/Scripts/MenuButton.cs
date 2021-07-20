using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameObject creditWindow;
    public bool creditOpen;
    public GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void BtnChangeScene(string scene_name)
    {
        gm.ResetVariables();
        SceneManager.LoadScene(scene_name);
    }

    public void BtnShowCredits()
    {
        creditOpen = true;
        creditWindow.SetActive(creditOpen);
    }

    public void BtnHideCredits()
    {
        creditOpen = false;
        creditWindow.SetActive(creditOpen);
    }

    public void BtnQuit()
    {
        Application.Quit();
    }
}
