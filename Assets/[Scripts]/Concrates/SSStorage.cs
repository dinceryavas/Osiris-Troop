using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSStorage : MonoBehaviour, ISSStorage
{
    int storageMoney;
    int maxStorage=30;
    int storageAmouth;

    public void Storage()
    {
        if(storageAmouth<=maxStorage)
        {
            storageAmouth++;
        }
        else
        {

        }
            
    }
    public void StorageMoney(int _storeageMoney)
    {
        storageMoney+=storageMoney;
    }
}
