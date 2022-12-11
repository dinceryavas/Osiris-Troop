using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SSWarning : MonoBehaviour
{
    public static bool isWarning;
    float timer=5;
    bool canExp;
    public SSWarning()
    {
        canExp = true;
        isWarning = false;
    }
    public void Warning()
    {
        if (isWarning)
        {
            GameInUIManager.instance.warningPanel.SetActive(true);
            if (timer < 0)
            {
                if (canExp)
                {
                    Debug.Log("s");
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        else
        {
            GameInUIManager.instance.warningPanel.SetActive(false);
            timer = 5;
        }
    }
}
