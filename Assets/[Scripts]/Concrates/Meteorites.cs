using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorites : MonoBehaviour
{
    public float meteoritePower;
    public int meteoriteMoneyCount;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Random.Range(-.005f, .005f), Random.Range(-.005f, .005f), Random.Range(-.005f, .005f), ForceMode.Force);
    }
    void Update()
    {
        if (transform.position.x > 2000 || transform.position.y > 2000 || transform.position.z > 2000 || transform.position.x < -2000 || transform.position.y < -2000 || transform.position.z < -2000)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        SpaceShip S = collision.transform.GetComponent<SpaceShip>();
        if(S!=null)
        {
            GetComponent<Rigidbody>().AddForce(Random.Range(-.01f, .01f), Random.Range(-.01f, .01f), Random.Range(-.01f, .01f), ForceMode.Force);
        }
    }
}
