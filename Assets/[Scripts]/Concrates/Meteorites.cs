using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorites : MonoBehaviour
{
    public Transform[] spawnposes;
    public float meteoritePower;
    public int meteoriteMoneyCount;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Random.Range(-.005f, .005f), Random.Range(-.005f, .005f), Random.Range(-.005f, .005f), ForceMode.Force);
        transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    }
    void Update()
    {
        transform.Rotate(new Vector3(Random.Range(0.25f, 0.5f), Random.Range(0.25f, 0.5f), Random.Range(0.25f, 0.5f)));
        if (transform.position.x > 2000 || transform.position.y > 2000 || transform.position.z > 2000 || transform.position.x < -2000 || transform.position.y < -2000 || transform.position.z < -2000)
        {
            transform.position = new Vector3(Random.Range(-1000, 1000), Random.Range(-1000, 1000), Random.Range(-1000, 1000));

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
