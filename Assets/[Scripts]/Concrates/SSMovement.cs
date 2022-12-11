using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSMovement : MonoBehaviour, ISSMovement

{
    Transform ship;
    float forwardspeed = 25,strafeSpeed = 7.5f,hoverSpeed = 5f;
    float activeForwardSpeeed, activeStrafeSpeeed, activeHoverSpeed;
    float forwardAcceleration = 2.5f, strafeAcceleration = 2f,hoverAcceleration = 2;
    float upgradespeed;
    float lookRateSpeed = 90;
    Vector2 lookInput, screenCenter, mouseDistance;
    bool contpitchdec;
    float rollInput;
    float rollSpeed = 90f,rollAcceleration = 3.5f;
    private void Start()
    {
        contpitchdec = false;
    }
    public SSMovement(Transform _ship,Vector2 _screenCenter)
    {
        ship = _ship;
        screenCenter.x = _screenCenter.x;
        screenCenter.y = _screenCenter.y;
    }
    public void Movement(float horizontal, float vertical, float hover, float roll, float speedup, int wingupgrade)
    {
        speedup = 1;
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;
        if (wingupgrade == 0)
        {
            upgradespeed = 1;
        }
        else if (wingupgrade == 1)
        {
            upgradespeed = 1.5f;
        }
        else if (wingupgrade == 2)
        {
            upgradespeed = 2;
        }

        if (Input.GetMouseButton(1))
        {
            mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
            mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

            mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            mouseDistance.x = 0;
            mouseDistance.y = 0;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ParticleManager.instance.HyperDriveParticle.GetComponent<ParticleSystem>().Play();
            if (SoundManager.instance.EngineSound.pitch <= 1.8f)
                SoundManager.instance.EngineSound.pitch += 0.01f;
            SSAimAndShoot.canShoot = false;
            speedup = 3;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ParticleManager.instance.HyperDriveParticle.GetComponent<ParticleSystem>().Stop();
            contpitchdec = true;
            SSAimAndShoot.canShoot = true;
            speedup = 1;
        }
        if(contpitchdec)
        {
            if (SoundManager.instance.EngineSound.pitch > 1f)
            {
                SoundManager.instance.EngineSound.pitch -= 0.01f;
            }
            else
            {
                contpitchdec = false;
            }
        }

        rollInput = Mathf.Lerp(rollInput, roll, rollAcceleration * Time.deltaTime);

        ship.transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        activeForwardSpeeed = Mathf.Lerp(activeForwardSpeeed, vertical * forwardspeed * speedup * upgradespeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeeed = Mathf.Lerp(activeStrafeSpeeed, horizontal * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, hover * hoverSpeed, hoverAcceleration * Time.deltaTime);

        ship.transform.position += ship.transform.forward * activeForwardSpeeed * Time.deltaTime;
        ship.transform.position += (ship.transform.right * activeStrafeSpeeed * Time.deltaTime) + (ship.transform.up * activeHoverSpeed * Time.deltaTime);

    }
}
