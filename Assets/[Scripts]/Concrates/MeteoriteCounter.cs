using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteCounter : MonoBehaviour
{
    public List<Transform> meteorites = new List<Transform>();

    #region Singleton
    public static MeteoriteCounter instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            meteorites.Add(transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
