using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int moneyAmouth;
    #region Singleton
    public static MoneyManager instance = null;
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
        GameInUIManager.instance.moneyText.text = moneyAmouth.ToString();
    }
    public void Addmoney(int addmoney)
    {
        moneyAmouth += addmoney;
        GameInUIManager.instance.moneyText.text = moneyAmouth.ToString();
    }
}
