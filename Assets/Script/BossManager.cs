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
    private void Start()
    {
        
    }

    public void OnBossHit()
    {
        lifePoint -= 1;
        if(lifePoint <= 0)
        {
            gameManager.Win();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            blockZone.gameObject.SetActive(true);
            camera.GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Lens.OrthographicSize = 6.5f;
            firstPattern.gameObject.SetActive(true);
        }
    }
}
