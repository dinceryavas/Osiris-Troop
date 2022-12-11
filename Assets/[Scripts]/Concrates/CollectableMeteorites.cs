using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollectableMeteorites : MonoBehaviour
{
    public int collectMoneyCount;
    float timer = 2;
    public float speed;
    Transform magnet;
    Rigidbody rb;
    Bag bag;
    bool moveToMagnet,onetime;
    void Start()
    {
        onetime = false;
        rb = GetComponent<Rigidbody>();
        moveToMagnet = false;
    }
    void Update()
    {
        if (moveToMagnet&& !onetime)
        {
            rb.velocity = Vector3.zero;

            transform.DOMove(bag.bagMouth.position, 0.1f);
        }
        else
        {
            transform.Rotate(3, 2, 2);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Bag B = other.GetComponent<Bag>();
        if (B != null)
        {
            bag = B;
            magnet = B.transform.GetChild(0);
            moveToMagnet = true;
        }
        BagMouth BM = other.GetComponent<BagMouth>();
        if(BM!=null)
        {
            MoneyManager.instance.StorageMoney(collectMoneyCount);
            gameObject.SetActive(false);
            transform.hideFlags = HideFlags.HideInHierarchy;
        }
    }
}
