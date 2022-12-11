using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSAimAndShoot : MonoBehaviour,ISSAimAndShoot
{
    float fireRate;
    public float fireRateStart = 0.2f;
    public static bool canShoot = true;
    Transform firePos1, firePos2,ship;
    public SSAimAndShoot(Transform _firePos1, Transform _firePos2, Transform _ship)
    {
        firePos1 = _firePos1;
        firePos2 = _firePos2;
        ship = _ship;
        fireRate = fireRateStart;
    }
    public void Shoot()
    {
        if(canShoot)
        {
            GameInUIManager.instance.crossHair.SetActive(true);
            if(fireRate<0)
            {
                if (Input.GetMouseButton(0))
                {
                    GameObject bullet1 = Instantiate(Resources.Load("Bullet"), firePos1.position, ship.rotation) as GameObject;
                    GameObject bullet2 = Instantiate(Resources.Load("Bullet"), firePos2.position, ship.rotation) as GameObject;
                    bullet1.GetComponent<Rigidbody>().AddForce(firePos1.forward * 50000);
                    bullet2.GetComponent<Rigidbody>().AddForce(firePos2.forward * 50000);
                    fireRate = fireRateStart;
                }
            }
            else
            {
                fireRate -= Time.deltaTime;
            }
        }
        else
        {
            GameInUIManager.instance.crossHair.SetActive(false);
        }
    }


}
