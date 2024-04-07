using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnnemisManager : MonoBehaviour
{
    public int maxLife;
    public int lifePoint;
    
    public GameObject pivot;

    public bool isFollowingPlayer = false;
    public GameObject player;

    public float speed = 3f;

    public float axeSpeed = 160f;

    public GameObject Arrow;
    public GameObject lifeDrop;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxLife;
        slider.value = lifePoint;
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
        slider.value = lifePoint;
        if (lifePoint <= 0)
        {
            gameObject.SetActive(false);
            var id = Random.Range(1,4);
            if (id == 1)
            {
                var arrow = Instantiate(Arrow);
                arrow.transform.position = gameObject.transform.position;
                arrow.GetComponent<ArrowManager>().isMooving = false;
            }
            else if(id == 2){
                var lifedrop = Instantiate(lifeDrop);
                lifedrop.transform.position = gameObject.transform.position;
            }
            

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
