using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public static int health=10;
    public Transform firePosOne,firePosTwo;
    ISSInputs sSInputs;
    [HideInInspector] public ISSTakeDamage sSTakeDamage;
    ISSMovement sSMovement;
    ISSAimAndShoot sSAimAndShoot;

    SSMapClamp ssmapClamp;
    SSWarning sSWarning;

    Vector2 screenCenter;

    bool hitcont;
    void Start()
    {
        hitcont = false;
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
        sSAimAndShoot = new SSAimAndShoot(firePosOne,firePosTwo,transform);
        sSTakeDamage = new SSTakeDamage();
        sSInputs = new SSInput();
        sSWarning = new SSWarning(); 
        ssmapClamp = new SSMapClamp(transform);
        sSMovement = new SSMovement(transform,screenCenter);
        Cursor.lockState = CursorLockMode.Confined;
        health = 10;
    }

    void Update()
    {
        sSMovement.Movement(sSInputs.horizontal,sSInputs.vertical,sSInputs.hover,sSInputs.roll,sSInputs.speedup);
        sSAimAndShoot.Shoot();
        ssmapClamp.MapClamp();
        sSWarning.Warning();
        if(health<=0)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Meteorites M = collision.gameObject.GetComponent<Meteorites>();
        if (M!=null&&!hitcont)
        {
            hitcont = true;
            StartCoroutine(delay());
            sSTakeDamage.TakeDamage();
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        hitcont = false;
    }
}
