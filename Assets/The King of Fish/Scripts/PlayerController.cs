using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 8.0f;
    [SerializeField] private float scaleRate;
    private Rigidbody2D rb2d;
    private Vector2 movementInput;
    private float playerSize;
    private Vector2 maximumSize = new Vector2(7.0f, 7.0f);
        
    private float accelerationTime = 0;
    private float shieldTime = 0;
    private string playerState = "normal";
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
                //update player life
                GameManager.Instance.UpdatePlayerLife();
            }         
        }
        else if (other.gameObject.CompareTag("Bubble"))
        {
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
            //set state and shield time
            playerState = "Shield";
            shieldTime = 5f;
            Debug.Log("Shield effect!");
        }
        else if(bubble == "acceleration")
        {
            //set state and player speed if bubble type is equal to accerlation
            playerState = "Acceleration";
            movementSpeed *= 1.5f;
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
