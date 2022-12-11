using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public Transform bagMouth;
    [HideInInspector] public ISSStorage storage;
    private void Start()
    {
        storage = new SSStorage();
    }
}
