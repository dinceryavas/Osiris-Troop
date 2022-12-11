using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPlace : MonoBehaviour
{
    bool cont;
    private void Start()
    {
        cont = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        SpaceShip s = other.GetComponent<SpaceShip>();
        if(s!=null&&cont)
        {
            cont = false;
            StartCoroutine(delay(s));
        }
    }
    IEnumerator delay(SpaceShip s)
    {
        int a;
        a = MoneyManager.instance.storageMoney;
        if (a > 40)
            a = 40;
        for (int i = 0; i < a; i++)
        {
            Transform c = s.sellCrystals.GetChild(0);
            yield return new WaitForSeconds(0.02f);
            c.gameObject.SetActive(true);
            c.SetParent(null);

            c.DOMove(transform.position, 1f).OnComplete(() => {
                c.gameObject.SetActive(false);
                c.SetParent(s.sellCrystals);
                c.position = s.sellCrystals.position;
            });
        }
        MoneyManager.instance.Addmoney(MoneyManager.instance.storageMoney);
        MoneyManager.instance.storageMoney = 0;

        cont = true;
    }
}
