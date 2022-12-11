using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMarket : MonoBehaviour
{
    public Transform Target;
    public float turn_speed;
    [HideInInspector] public Transform arrowmarket;
    #region Singleton
    public static ArrowMarket instance = null;
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
        arrowmarket = transform;
    }
    void Update()
    {
        var p2 = Target.transform.position;
        var position = new Vector3(p2.x, p2.y+30, p2.z); // does not bend to target
        transform.LookAt(position);
    }

}
