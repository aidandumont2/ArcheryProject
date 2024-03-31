using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public float speed = 10f;
    public bool isMooving = true;
    public int damage = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMooving)
        {
            transform.position += transform.up * speed * Time.fixedDeltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isMooving = false;
        GetComponent<BoxCollider2D>().isTrigger = true;                                                                    
        if(collision.collider.gameObject.tag == "Ennemis")
        {
            collision.gameObject.GetComponent<EnnemisManager>().OnEnnemisHit(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().PickArrow();
            gameObject.SetActive(false);
        }
    }
}
