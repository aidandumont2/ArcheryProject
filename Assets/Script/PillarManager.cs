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
            boss.lifePoint -= 1;
            GetComponent<SpriteRenderer>().sprite = brokenPillar;
            isBroken = true;
        }
    }
}
