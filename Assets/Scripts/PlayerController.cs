using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

  Animator anim;
    private Rigidbody2D rb2d;

    public Text countText;
    public float speed;
    public float jumpForce;

    private int count;
    public Text winText;
    public Text lifeText;
   
    

    // Start is called before the first frame update
    void Start()
    {
    
         rb2d = GetComponent<Rigidbody2D>();

         count = 0;
         winText.text = "";
         SetCountText ();

        lifeText.text = "Lives: 3";

        anim = GetComponent<Animator>();
         
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.RightArrow))
          {
               anim.SetInteger("State", 1);
          }

     if (Input.GetKeyUp(KeyCode.UpArrow))
          {
               anim.SetInteger("State", 3);
          }

     if (Input.GetKeyDown(KeyCode.LeftArrow))
         {
               anim.SetInteger("State", 1);
          } 


    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

            if (Input.GetKey("escape"))
     Application.Quit();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow)){
                rb2d.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);

            count = count + 1;
            SetCountText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 8)
        {
            winText.text = "You win!";
        }
        if (count == 4)
        {
            transform.position = new Vector3(12.0F, transform.position.y, -3.4f);

       
    }
    }

}
   


 //Create an explosion on the coordinates of the hit. 
       // public void Hit(Vector3 hitCoordinates)
   // {
        
       // FindObjectOfType<LivesCounter>().RemoveLife();
   // } Instantiate(explosionPrefab, hitCoordinates, Quaternion.identity);