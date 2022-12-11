using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public GameObject LoadScenePanel;
    public GameObject MenuPanels;
    public GameObject OptionPanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void OpenOptionPanel()
    {
        OptionPanel.SetActive(true);
    }
    public void StartGame()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        MenuPanels.SetActive(false);
        LoadScenePanel.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Game");
    }
}
