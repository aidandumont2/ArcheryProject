using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarManager : MonoBehaviour
{
    public BossManager boss;
    public Sprite brokenPillar;
    public bool isBroken = false;

    
    
    public void OnPillarHit()
    {
        if (!isBroken)
        {
            boss.OnBossHit();
            GetComponent<SpriteRenderer>().sprite = brokenPillar;
            GetComponentInChildren<Cainos.PixelArtTopDown_Basic.SpriteColorAnimation>().gameObject.SetActive(false);
            isBroken = true;
        }
    }
}
