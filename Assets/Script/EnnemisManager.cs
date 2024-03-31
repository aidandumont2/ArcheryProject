using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisManager : MonoBehaviour
{
    public int lifePoint = 2;
    
    public GameObject pivot;

    public bool isFollowingPlayer = false;
    public GameObject player;

    public float speed = 3f;

    public float axeSpeed = 160f;

    public GameObject Arrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pivot.transform.Rotate(0f,0f, axeSpeed * Time.fixedDeltaTime,Space.Self);
        if (isFollowingPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position,speed*Time.fixedDeltaTime);
        }
    }

    public void OnEnnemisHit(int damage)
    {
        lifePoint -= damage;
        if (lifePoint <= 0)
        {
            gameObject.SetActive(false);
            var arrow = Instantiate(Arrow);
            arrow.transform.position = gameObject.transform.position;
            arrow.GetComponent<ArrowManager>().isMooving = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isFollowingPlayer = true;
            player = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isFollowingPlayer = false;
        }
    }
}
