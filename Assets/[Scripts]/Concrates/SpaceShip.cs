using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public GameObject[] wingUpgradeParts,gunUpgradeParts;
    public Transform sellCrystals;
    public static int health=10;
    public Transform firePosOne,firePosTwo;
    ISSInputs sSInputs;
    [HideInInspector] public ISSTakeDamage sSTakeDamage;
    ISSMovement sSMovement;
    ISSAimAndShoot sSAimAndShoot;

    SSMapClamp ssmapClamp;
    SSWarning sSWarning;

    Vector2 screenCenter;
    public static bool canMove;
    public static int weaponUpgradeCount,wingUpgradeCount;
    bool hitcont;
    void Start()
    {
        hitcont = false;
        canMove = false;
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
        StartCoroutine(Marketdelay());
    }
    IEnumerator Marketdelay()
    {
        yield return new WaitForEndOfFrame();
        GameInUIManager.instance.marketAccessPanel.SetActive(false);
    }

    void Update()
    {
        if(canMove)
        {
            sSMovement.Movement(sSInputs.horizontal, sSInputs.vertical, sSInputs.hover, sSInputs.roll, sSInputs.speedup,wingUpgradeCount);
            sSAimAndShoot.Shoot(weaponUpgradeCount);
        }
        ssmapClamp.MapClamp();
        sSWarning.Warning();
        if(health<=0)
        {
            Instantiate(Resources.Load("Explo"), transform.position, Quaternion.identity);
            GameInUIManager.instance.GameOverPanel.SetActive(true);
            GetComponent<SpaceShip>().enabled = false;
            gameObject.SetActive(false);
        }
        if(weaponUpgradeCount == 0)
        {
            gunUpgradeParts[0].SetActive(false);
            gunUpgradeParts[1].SetActive(false);
        }
        else if(weaponUpgradeCount == 1)
        {
            gunUpgradeParts[0].SetActive(true);
            gunUpgradeParts[1].SetActive(false);
        }
        else if(weaponUpgradeCount == 2)
        {
            gunUpgradeParts[0].SetActive(true);
            gunUpgradeParts[1].SetActive(true);
        }

        if (wingUpgradeCount == 0)
        {
            wingUpgradeParts[0].SetActive(false);
            wingUpgradeParts[1].SetActive(false);
        }
        else if (wingUpgradeCount == 1)
        {
            wingUpgradeParts[0].SetActive(true);
            wingUpgradeParts[1].SetActive(false);
        }
        else if (wingUpgradeCount == 2)
        {
            wingUpgradeParts[0].SetActive(true);
            wingUpgradeParts[1].SetActive(true);
        }
        if(GameInUIManager.instance.marketAccessPanel.activeSelf&&Input.GetKeyDown(KeyCode.F))
        {
            MarketManager.marketOpen = true;
            canMove = false;
            GameInUIManager.instance.marketAccessPanel.SetActive(false);
            ParticleManager.instance.HyperDriveParticle.GetComponent<ParticleSystem>().Stop();
            transform.DOLocalRotateQuaternion(Market.instance.shipplace.rotation, 3);
            transform.DOMove(Market.instance.shipplace.position, 3).OnComplete(() =>
            {
                GameInUIManager.instance.marketPanel.SetActive(true);
                GameInUIManager.instance.marketPanel.transform.DOScaleY(1, 0.5f);
            });
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
        if(collision.transform.tag == "Market")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        hitcont = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Market")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Market")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "MarketFull")
        {
            GameInUIManager.instance.marketAccessPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "MarketFull")
        {
            GameInUIManager.instance.marketAccessPanel.SetActive(false);
        }
    }
}
