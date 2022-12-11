using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInUIManager : MonoBehaviour
{
    public ProgressBarPro ProgressBarPro;
    public GameObject warningPanel;
    public Text moneyText;
    public GameObject crossHair;
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
}
