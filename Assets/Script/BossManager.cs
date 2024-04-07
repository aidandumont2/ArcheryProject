using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public int lifePoint = 5;

    public GameManager gameManager;

    public GameObject camera;

    public GameObject blockZone;

    public GameObject firstPattern;
    public GameObject secondPattern;
    public GameObject thirdPattern;
    private void Start()
    {
        
    }

    public void OnBossHit()
    {
        lifePoint -= 1;
        if(lifePoint <= 0)
        {
            gameManager.Win();
        }else if (lifePoint == 3)
        {
            firstPattern.gameObject.SetActive(false);
            secondPattern.gameObject.SetActive(true);
        }else if (lifePoint == 2)
        {
            thirdPattern.gameObject.SetActive(true);
        }
        else if (lifePoint == 1)
        {
            firstPattern.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            
            blockZone.gameObject.SetActive(true);
            StartCoroutine(StartFight());
        }
    }

    IEnumerator StartFight()
    {
        yield return new WaitForSeconds(2);
        camera.GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Lens.OrthographicSize = 6.5f;
        firstPattern.gameObject.SetActive(true);
    }
}
