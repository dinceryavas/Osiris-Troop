using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource MeteoriteExpo;
    public AudioSource MeteoriteHit;
    public AudioSource BulletSpawn;
    public AudioSource EngineSound;

    #region Singleton
    public static SoundManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
}
