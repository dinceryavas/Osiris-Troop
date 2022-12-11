using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSTakeDamage : MonoBehaviour,ISSTakeDamage
{
    public void TakeDamage()
    {
        SpaceShip.health--;
        GameInUIManager.instance.ProgressBarPro.Value -= 0.1f;
    }
}
