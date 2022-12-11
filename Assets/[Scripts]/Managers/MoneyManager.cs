using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int moneyAmouth;
    public int storageMoney;
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
    private void Update()
    {
        GameInUIManager.instance.moneyText.text = moneyAmouth.ToString();
    }
    public void Addmoney(int addmoney)
    {
        moneyAmouth += addmoney;
    }
    public void StorageMoney(int _storeageMoney)
    {
        storageMoney += _storeageMoney;
    }
}
