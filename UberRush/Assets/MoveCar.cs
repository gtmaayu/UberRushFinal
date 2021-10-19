using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 10.0f;
    public GameHandler gameHandlerObj;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (GameObject.FindWithTag("GameHandler") != null){
               gameHandlerObj = GameObject.FindWithTag("GameHandler")
               .GetComponent<GameHandler>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Passenger")
        {
            other.gameObject.SetActive(false);
            gameHandlerObj.AddScore(1);
            other.gameObject.transform.position 
            = new Vector2(Random.Range(-6, 3), Random.Range(-4, 4));
            other.gameObject.SetActive(true);
        }
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class MoveCar : MonoBehaviour
//{
//    public float speed = 0;

//    private Rigidbody2D rb;

//    private float movementX;
//    private float movementY;

//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    private void OnMove(InputValue movementValue)
//    {
//        Vector2 movementVector = movementValue.Get<Vector2>();

//        movementX = movementVector.x;
//        movementY = movementVector.y;
//    }

//    private void FixedUpdate()
//    {
//        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

//        rb.AddForce(movement * speed);
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.CompareTag("Passenger"))
//        {
//            other.gameObject.SetActive(false);
//        }
//    }
//}

