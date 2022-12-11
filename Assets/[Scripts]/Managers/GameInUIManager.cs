using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameInUIManager : MonoBehaviour
{
    public GameObject Finishpanel, FinishObj;
    public GameObject marketPanel, marketAccessPanel,TextBoxesPanel,GameOverPanel,MoneyPanel,FinishTextBox;
    public GameObject pausePanel;
    public GameObject[] TextBoxes;
    public GameObject[] FinishTextboxes;

    public ProgressBarPro ProgressBarPro;
    public GameObject warningPanel;
    public Text moneyText;
    public GameObject crossHair;
    bool cont;
    int textboxcount,finishtextboxcount;
    public static bool gamefinish;
    #region Singleton
    public static GameInUIManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
    private void Start()
    {
        cont = false;
        textboxcount = 0;
        finishtextboxcount = 0;
        TextBoxes[0].SetActive(true);
        SpaceShip.canMove = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&!pausePanel.activeSelf&&!MarketManager.marketOpen)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            SpaceShip.canMove = false;
        }
        else if(Input.GetKeyDown(KeyCode.Escape)&&pausePanel.activeSelf)
        {
            Resume();
        }
        if(Input.GetMouseButtonDown(0)&&textboxcount<=6)
        {

            textboxcount++;
            switch (textboxcount)
            {
                case 0:
                    TextBoxes[0].SetActive(true);
                    break;
                case 1:
                    TextBoxes[0].SetActive(false);
                    TextBoxes[1].SetActive(true);
                    break;
                case 2:
                    TextBoxes[1].SetActive(false);
                    TextBoxes[2].SetActive(true);
                    break;
                case 3:
                    TextBoxes[2].SetActive(false);
                    TextBoxes[3].SetActive(true);
                    break;
                case 4:
                    TextBoxes[3].SetActive(false);
                    TextBoxes[4].SetActive(true);
                    break;
                case 5:
                    TextBoxes[4].SetActive(false);
                    TextBoxes[5].SetActive(true);
                    break;
                case 6:
                    TextBoxes[5].SetActive(false);
                    TextBoxesPanel.SetActive(false);
                    SpaceShip.canMove = true;
                    break;
            }
            
        }
        if(Input.GetMouseButtonDown(0)&&finishtextboxcount<=4&&gamefinish&&!cont)
        {
            finishtextboxcount++;
            switch (finishtextboxcount)
            {
                case 1:
                    FinishTextboxes[0].SetActive(false);
                    FinishTextboxes[1].SetActive(true);
                    break;
                case 2:
                    FinishTextboxes[1].SetActive(false);
                    FinishTextboxes[2].SetActive(true);
                    break;
                case 3:
                    FinishTextBox.SetActive(false);
                    Finishpanel.SetActive(true);
                    StartCoroutine(finishopen());
                    IEnumerator finishopen()
                    {
                        yield return new WaitForSeconds(2);
                        FinishObj.SetActive(true);
                    }
                    break;
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        SpaceShip.canMove = true;
    }
    public void Exit()
    {
        Application.Quit();
    }

}
