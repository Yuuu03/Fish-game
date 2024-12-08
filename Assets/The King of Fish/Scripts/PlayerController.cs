using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //variables for player
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float scaleRate;
    private Rigidbody2D rb2d;
    private Vector2 movementInput;
    private float playerSize;
    private Vector2 maximumSize = new Vector2(7.0f, 7.0f);
        
    //variables for power ups
    private float accelerationTime = 0;
    private float shieldTime = 0;
    private bool hasShield = false;
    private string bubble;

    // Start is called before the first frame update
    void Start()
    {
        //initialize Rigidbody
        rb2d = GetComponent<Rigidbody2D>();  

    }

    void Update()
    {
        //constantly update player facing direction
        UpdateFacingDirection();
        //constantly check player size against the maximum size
        CheckPlayerSize();
        
        //reduce acceleration time when it is greater than 0
        if(accelerationTime > 0)
        {
            accelerationTime -= Time.deltaTime;
        }
        else
        {
            //set speed to normal when there is no acceleration effect
            movementSpeed = 5.0f;
        }
        //reduce shield time when it is greater than 0
        if (shieldTime > 0) 
        {
            shieldTime -= Time.deltaTime;
        }
        else
        {
            //set isShield to false
            hasShield = false;
        }
        
    }

    //OnMove method
    private void OnMove(InputValue input)
    {
        //Get the movement input value
        movementInput = input.Get<Vector2>();
        rb2d.AddForce(movementInput);
    }

    private void FixedUpdate()
    {
        //apply movement input value to the velocity of the player every frame
        rb2d.velocity = movementInput * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if player collides with enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            //if player size is larger or greater than enemy size
            if(transform.localScale.sqrMagnitude >= other.transform.localScale.sqrMagnitude)
            {
                //destroy the enemy
                other.gameObject.SetActive(false);
                //get scale rate by adding the 30% of the enemy scale
                scaleRate += (other.transform.localScale.sqrMagnitude) / 30f;
                //increase player scale
                transform.localScale = Vector3.one * scaleRate;
                //update player score
                GameManager.Instance.UpdateScore();
            }
            else
            {
                //check if player has shield
                if (hasShield)
                {
                    return;
                }
                else
                {
                    //update player life
                    GameManager.Instance.UpdatePlayerLife();
                }
                
            }         
        }
        else if (other.gameObject.CompareTag("Bubble"))
        {
            bubble = other.gameObject.GetComponent<Bubble>().bubbleType;
            Debug.Log($"The bubble type is collided with: { bubble}");
            //call bubble effect method
            BubbleEffect();
            //damage bubble
            other.gameObject.SetActive(false);
        }
    }

    private void BubbleEffect()
    {
        //If bubble type is equal to shield
        if(bubble == "shield")
        {
            //set shield time and change isShield to true
            shieldTime = 5f;
            hasShield = true;
            Debug.Log("Shield effect!");
        }
        else if(bubble == "acceleration")
        {
            //set player speed if bubble type is equal to accerlation
            movementSpeed *= 1.5f;
            Debug.Log($"Current movement speed: {movementSpeed}");
            accelerationTime = 5f;
            Debug.Log("Acceleration effect!");
        }
        else
        {
            //reduce player life if bubble type is bad
            GameManager.Instance.UpdatePlayerLife();
        }
    }

    private void UpdateFacingDirection()
    {
        //flip the sprite based on the player movement
        var scale = transform.localScale;
        if (!Mathf.Approximately(movementInput.x, 0)) scale.x = Mathf.Abs(scale.x) * Mathf.Sign(movementInput.x);
        transform.localScale = scale;
    }

    private void CheckPlayerSize()
    {
        playerSize = transform.localScale.sqrMagnitude;
        //check if the player size is equal or greater than the maximum size
        if (playerSize >= maximumSize.sqrMagnitude)
        {
            Debug.Log("The player size is equal to the maximum size!");
            //call game over method
            GameManager.Instance.GameOver();
        }
    }
}
