using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    float horizontalMove;
    public float speed;

    public Rigidbody2D myBody;

    bool grounded = false;

    public GameObject roomOneText;
    public GameObject roomTwoText;

    public bool haveCoin1 = false;
    public bool haveCoin2 = false;
    public bool haveCoin3 = false;

    public bool haveAllCoins = false;

    public bool haveCoinOne = false;
    public bool haveCoinTwo = false;
    public bool haveCoinThree = false;

    public bool haveAllCoins2 = false;

    public float castDist = 0.2f;
    public float gravityScale = 5f;
    public float gravityFall = 40f;
    public float jumpLimit = 2f;

    bool walking = false;

    bool jump = false;

    //Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        //myBody = GetComponent<Rigidbody2D>();
        //myAnim = GetComponent<Animator>();
        roomOneText.SetActive(false);
        roomTwoText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(horizontalMove > 0.2f || horizontalMove < 0.2f)
        {
            //myAnim.SetBool("walking", true);
        } else
        {
           // myAnim.SetBool("walking", false);
        }

        if(haveCoin1 == true && haveCoin2 == true && haveCoin3 == true)
        {
            haveAllCoins = true;
        }

        if (haveCoinOne == true && haveCoinTwo == true && haveCoinThree == true)
        {
            haveAllCoins2 = true;
        }
    }

    void FixedUpdate()
    {
        float moveSpeed = horizontalMove * speed;

        if (jump)
        {
            myBody.AddForce(Vector2.up * jumpLimit, ForceMode2D.Impulse);
            jump = false;
        }

        if (myBody.velocity.y > 0)
        {
            myBody.gravityScale = gravityScale;
        } else if (myBody.velocity.y < 0)
        {
            myBody.gravityScale = gravityFall;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);

        if(hit.collider != null && hit.transform.name == "Ground")
        {
            grounded = true;
        }else
        {
            grounded = false;
        }

        myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, 0);

        if (haveAllCoins == true)
        {
            roomOneText.SetActive(true);
        }

        if (haveAllCoins2 == true)
        {
            roomTwoText.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Coin1")
        {
            haveCoin1 = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Coin2")
        {
            haveCoin2 = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Coin3")
        {
            haveCoin3 = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "Door")
        {
            SceneManager.LoadScene(1);
        }

        if (other.gameObject.name == "CoinOne")
        {
            haveCoinOne = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "CoinTwo")
        {
            haveCoinTwo = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "CoinThree")
        {
            haveCoinThree = true;
            Destroy(other.gameObject);
        }
    }

}
