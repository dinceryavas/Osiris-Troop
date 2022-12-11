using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    public int[] wingUpgradeCosts,weaponUpgradeCosts;
    public static bool marketOpen;
    public Button buywing, buyweapon;
    public GameObject wingUpgradePriceText, weaponUpgradePriceText;
    public GameObject notenoughmoney;
    void Start()
    {
        wingUpgradePriceText.GetComponent<Text>().text = wingUpgradeCosts[SpaceShip.wingUpgradeCount].ToString();
        weaponUpgradePriceText.GetComponent<Text>().text = weaponUpgradeCosts[SpaceShip.weaponUpgradeCount].ToString();
        transform.DOScaleY(1, 0.5f);

    }
    void Update()
    {
        if(SpaceShip.weaponUpgradeCount>=2)
        {
            buyweapon.interactable = false;
            weaponUpgradePriceText.GetComponent<Text>().text = "Full";
        }
        if(SpaceShip.wingUpgradeCount>=2)
        {
            buywing.interactable = false;
            wingUpgradePriceText.GetComponent<Text>().text = "Full";
        }
        if(SpaceShip.weaponUpgradeCount == 2&&SpaceShip.wingUpgradeCount == 2)
        {
            transform.DOScaleY(0, 0.5f).OnComplete(() =>
            {
                GameInUIManager.gamefinish = true;
                GameInUIManager.instance.FinishTextboxes[0].SetActive(true);
                gameObject.SetActive(false);
                GameInUIManager.instance.FinishTextBox.SetActive(true);
                GameInUIManager.instance.ProgressBarPro.gameObject.SetActive(false);
                GameInUIManager.instance.crossHair.gameObject.SetActive(false);
                GameInUIManager.instance.MoneyPanel.gameObject.SetActive(false);


            });

        }


    }
    public void UpgradeWings()
    {
        if (MoneyManager.instance.moneyAmouth >= wingUpgradeCosts[SpaceShip.wingUpgradeCount])
        {
            MoneyManager.instance.Addmoney(-wingUpgradeCosts[SpaceShip.wingUpgradeCount]);
            SpaceShip.wingUpgradeCount++;
            wingUpgradePriceText.GetComponent<Text>().text = wingUpgradeCosts[SpaceShip.wingUpgradeCount].ToString();
        }
        else
        {
            StartCoroutine(NotEn());
        }
    }
    IEnumerator NotEn()
    {
        notenoughmoney.SetActive(true);
        yield return new WaitForSeconds(1);
        notenoughmoney.SetActive(false);

    }
    public void UpgradeWeapons()
    {
        if(MoneyManager.instance.moneyAmouth >= weaponUpgradeCosts[SpaceShip.weaponUpgradeCount])
        {
            MoneyManager.instance.Addmoney(-weaponUpgradeCosts[SpaceShip.weaponUpgradeCount]);
            SpaceShip.weaponUpgradeCount++;
            weaponUpgradePriceText.GetComponent<Text>().text = weaponUpgradeCosts[SpaceShip.weaponUpgradeCount].ToString();
        }
        else
        {
            StartCoroutine(NotEn());
        }
    }
    public void ExitMarket()
    {
        transform.DOScaleY(0, 0.5f).OnComplete(() =>
        {
            SpaceShip.canMove = true;
            marketOpen = false;
            gameObject.SetActive(false);
        });
    }
}
