using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour


{
    private Rigidbody2D rd2d;


    private int scoreValue;
    
    private int lifeValue;
    
    public float speed;

    public Text winText;

    public Text scoreText;

    public Text lifeText;

    private int Destroy;

    public Vector2 ResetPoint;

    Animator anim;
    
    public bool facingRight;

    
    public float horizontalValue;

    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    public AudioSource musicSource;



 


    // Start is called before the first frame update
    void Start()
    
    {

        anim = GetComponent<Animator>();
        rd2d = GetComponent<Rigidbody2D>();
        scoreValue = 0;
        setCountText ();
        lifeValue = 3;
        setlifeText ();
        winText.text = "";
        lifeText.text = "Lives: 3";
    }





    // Update is called once per frame
    void FixedUpdate()
    {
    {
        if (lifeValue == 0)
        {
            Destroy(GetComponent<PlayerScript>());
        }
    }
    
     if (scoreValue > 8)
        {
          musicSource.clip = musicClipOne;
          musicSource.Play();

        }
    {
        {


    }
        move();

       properFlip();
    
     if (Input.GetKeyDown(KeyCode.D))

        {

          anim.SetInteger("State", 2);

         }

     if (Input.GetKeyUp(KeyCode.D))
        {
          anim.SetInteger("State", 0);
         }

    
     if (Input.GetKeyDown(KeyCode.A))

        {

          anim.SetInteger("State", 2);

         }

     if (Input.GetKeyUp(KeyCode.A))
        {
          anim.SetInteger("State", 0);
         }





 

     if (Input.GetKeyDown(KeyCode.W))

        {

          anim.SetInteger("State", 1);

         }

     if (Input.GetKeyUp(KeyCode.W))
        {
          anim.SetInteger("State", 0);
         }

        {
    
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        }
    
 
     }
    
    
     void move()
    {
        horizontalValue = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    }

    }

  private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
      {
          scoreValue += 1;
          setCountText ();
          Destroy(collision.collider.gameObject);
       
        if (scoreValue == 4) 
     {
        transform.position = new Vector3(35.0f, -3.0f, 0.0f); 
        lifeValue = 3;
        setlifeText ();
     }
        
   if (scoreValue == 8)
        {
          musicSource.Stop();
          musicSource.clip = musicClipTwo;
          musicSource.Play();

        }



      } 

         if (collision.collider.tag == "Enemy")
        {
          lifeValue -= 1;
          setlifeText ();
            Destroy(collision.collider.gameObject);
        } 


        if (lifeValue == 0)
        {
            Destroy(collision.collider.gameObject);
        }
    }
        
        




    private void OnCollisionStay2D(Collision2D collision)
    {
              
        if (Input.GetKey("escape"))
        {
        Application.Quit();
        }

        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
                anim.SetInteger("State", 0);
            }

            
            
        }
   
    }
  
  
  
    private void setCountText ()
    {
        scoreText.text = "Score: " + scoreValue.ToString ();
        if (scoreValue >= 8)
        {
            winText.text = "You Win! Game By Christopher Mason.";
        }
    
    }
    
    
     private void setlifeText ()
    {
        lifeText.text = "Lives: " + lifeValue.ToString ();
        if (lifeValue <= 0)
        {
         winText.text = "You Lose!";
        }
 
    }


    void properFlip()
    {
        if((horizontalValue > 0 && facingRight) || (horizontalValue < 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

}

