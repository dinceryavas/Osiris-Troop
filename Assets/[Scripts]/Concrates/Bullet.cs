using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private void Start()
    {
        transform.hideFlags = HideFlags.HideInHierarchy;
        StartCoroutine(delay());
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Meteorites m = other.GetComponent<Meteorites>();
        if(m!=null)
        {
            gameObject.SetActive(false);
            m.meteoritePower--;
            if(m.meteoritePower<=0)
            {
                Destroy(m.gameObject);
                //partcile
            }
        }
    }
}
