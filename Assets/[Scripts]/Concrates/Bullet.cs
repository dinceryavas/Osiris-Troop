using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private void Start()
    {
        SoundManager.instance.BulletSpawn.Play();
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
            SoundManager.instance.MeteoriteHit.Play();
            gameObject.SetActive(false);
            Instantiate(Resources.Load("HitExplo"), m.transform.position, Quaternion.Euler(transform.rotation.x,transform.rotation.y+90,transform.rotation.z+90)); 
            m.meteoritePower--;
            if(m.meteoritePower<=0)
            {
                for (int i = 0; i < 3; i++)
                {
                    int rn = Random.Range(0, m.spawnposes.Length);
                    SoundManager.instance.MeteoriteExpo.Play();
                    GameObject mini = Instantiate(Resources.Load("Collectables"), m.spawnposes[rn].position, Quaternion.identity) as GameObject;
                    GetComponent<Rigidbody>().AddForce(Random.Range(-.05f, .05f), Random.Range(-.05f, .05f), Random.Range(-.05f, .05f), ForceMode.Force);
                }
                m.transform.position = new Vector3(Random.Range(-1000, 1000), Random.Range(-1000, 1000), Random.Range(-1000, 1000));
                m.meteoritePower = Random.Range(3, 6);
                Instantiate(Resources.Load("Explo"), m.transform.position, Quaternion.identity);
            }
        }
    }
}
