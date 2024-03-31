using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public GameManager gameManager;

    public Controls controls;
    public Vector2 actualInput;

    public float speed = 6f;


    public GameObject Arrow;

    public Vector2 cursorPosition;
    public GameObject pivot;
    public GameObject spawnPoint;

    public TextMeshProUGUI txtNbArrows;

    public int nbOfArrows = 3;

    public int currentLife = 3;
  

    private float rot_z;
    // Start is called before the first frame update
    void Start()
    {
        controls = new Controls();
        controls.Enable();
        controls.Player.Move.started += context => actualInput = context.ReadValue<Vector2>();
        controls.Player.Move.canceled += context => actualInput = context.ReadValue<Vector2>();
        controls.Player.Move.performed += context => actualInput = context.ReadValue<Vector2>();
        controls.Player.Fire.started += context => FireArrows(true);
        controls.Player.Fire.canceled += context => FireArrows(false);
        controls.Player.Fire.performed += context => FireArrows(false);
        controls.Player.Dash.started += context => ActiveDash(true);
        controls.Player.Dash.canceled += context => ActiveDash(false);
        controls.Player.Dash.performed += context => ActiveDash(false);

        txtNbArrows.text = "X " + nbOfArrows;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        pivot.transform.rotation = Quaternion.Euler(0f,0f,rot_z - 90f) ;

        var position = transform.position;  
        position.x += actualInput.x * speed * Time.deltaTime;
        position.y += actualInput.y * speed * Time.deltaTime;
        this.GetComponent<Rigidbody2D>().MovePosition(position);
    }


    public void FireArrows(bool DoShoot)
    {
        if (DoShoot && nbOfArrows > 0 && gameManager.currentState == GameManager.GameState.Playing)
        {
            var arrow = Instantiate(Arrow);
            arrow.transform.position = spawnPoint.transform.position;
            arrow.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90f);
            nbOfArrows -= 1;
            txtNbArrows.text = "X " + nbOfArrows;
        }
    }

    public void PickArrow()
    {
        nbOfArrows += 1;
        txtNbArrows.text = "X " + nbOfArrows;
    }

    public void ActiveDash(bool DoDash)
    {
        if (DoDash)
        {
            transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 1f);
        }
        
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.gameObject.tag == "Weapon")
        {
            currentLife -= 1;
            if (currentLife <= 0)
            {
                gameManager.OnChangeState(GameManager.GameState.EndMenu);
            }
        }
    }

    public void PickLife()
    {
        if (currentLife <3)
        {
            currentLife += 1;
        }
    }
}
