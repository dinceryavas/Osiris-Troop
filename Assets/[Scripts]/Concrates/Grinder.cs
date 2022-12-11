using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

    }
    private void OnTriggerStay(Collider other)
    {
        Meteorites m = other.GetComponent<Meteorites>();
        if (m != null)
        {
            m.GetComponent<Rigidbody>().velocity = Vector3.zero;
            m.meteoritePower -= Time.deltaTime*3;
            if(m.meteoritePower < 0)
            {
                m.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Meteorites m = other.GetComponent<Meteorites>();
        if (m != null)
        {
            m.GetComponent<Rigidbody>().AddForce(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f), Random.Range(-.5f, .5f), ForceMode.Force);
        }
    }
}
