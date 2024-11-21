using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 8.0f;
    private Rigidbody2D rb2d;
    private Vector2 movementInput;
    //private float movementX;
    //private float movementY;
    private float accelerationTime = 0;
    private float shieldTime = 0;
    private string playerState = "normal";

    // Start is called before the first frame update
    void Start()
    {
        //initialize Rigidbody
        rb2d = GetComponent<Rigidbody2D>();  
    }

    //OnMove method
    private void OnMove(InputValue input)
    {
        //Get the movement input value
        movementInput = input.Get<Vector2>();
        //movementX = movementInput.x;
        //movementY = movementInput.y;
        rb2d.AddForce(movementInput);
    }

    private void FixedUpdate()
    {
        //apply movement input value to the velocity of the player every frame
        rb2d.velocity = movementInput * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
