using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, olw_speed, rn_speed, ro_speed, jumpForce;
    public bool walking;
    private bool jumping = false; // Indikace, zda hráè skáèe
    public Transform playerTrans;

    //AudioManager audioManager;

    private bool isJumping;
    private bool isGrounded;

    
    private bool falling = false;
    private float jumpTime = 0f;

    static public bool dialogue = false;

    void Start()
    {
        // Ujisti se, že Rigidbody je správnì nastaveno
        if (!playerRigid) playerRigid = GetComponent<Rigidbody>();
        playerRigid.freezeRotation = true; // Zabrání nekontrolovanému otáèení
    }

   /* private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }*/

    void FixedUpdate()
    {
        // Pohyb postavy pouze horizontálnì
        if (walking && !jumping)
        {
            Vector3 movement = transform.forward * w_speed;
            playerRigid.velocity = new Vector3(movement.x, playerRigid.velocity.y, movement.z);
        }
        else if (!jumping)
        {
            playerRigid.velocity = new Vector3(0, playerRigid.velocity.y, 0); // Zastav horizontální pohyb
        }
        else if (!dialogue)
        {

        }
    }

    void Update()
    {
        // Chùze
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
           // audioManager.PlaySFX(audioManager.walk);
            walking = true;
        }
        
        
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            walking = false;
            w_speed = olw_speed; // Reset na pùvodní rychlost
        }

        // Skok
        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            jumping = true;
            falling = false;
            jumpTime = Time.time;
            playerAnim.SetTrigger("jump");
            playerAnim.ResetTrigger("idle");
            isJumping = true;

            playerRigid.velocity = new Vector3(playerRigid.velocity.x, jumpForce, playerRigid.velocity.z);
        }


        if (jumping && !falling && Time.time - jumpTime >= 1f)
        {
            falling = true;
            playerAnim.SetTrigger("falling");
            playerAnim.ResetTrigger("jump");
        }
        
        // Otoèení




        if (Input.GetKey(KeyCode.A) && !Input.GetKeyUp(KeyCode.W))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
            playerAnim.SetTrigger("turn_left");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.SetTrigger("turn_to_idle");
            playerAnim.ResetTrigger("turn_left");
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
            playerAnim.SetTrigger("turn_right");
        }
        if (Input.GetKeyUp(KeyCode.D) && !Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetTrigger("turn_to_idle");
            playerAnim.ResetTrigger("turn_right");
        }

        // Bìh
        if (walking)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                w_speed += rn_speed; // Zrychlení
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("walk");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                w_speed = olw_speed; // Návrat k rychlosti chùze
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            }
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q))
        {
            playerAnim.SetTrigger("dance1");
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.SetTrigger("dance2");
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R))
        {
            playerAnim.SetTrigger("dance3");
        }
    }

    // Detekce pøistání
    void OnCollisionEnter(Collision collision)
    {
        // Zkontroluj, že objekt má Collider a není Trigger
       if (collision.collider != null && !collision.collider.isTrigger)
        {
            jumping = false;
            playerAnim.SetTrigger("land_idle"); // Návrat k animaci klidu
        }

        if (collision.gameObject.tag == "Push")
        {
            if (!jumping && Input.GetKey(KeyCode.W))
            {
                playerAnim.ResetTrigger("walk");
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("push");
                w_speed = w_speed / 2;
            }

        }

        if ( falling && collision.gameObject.CompareTag("Ground"))
        {
            jumping = false;
            falling = false;
            playerAnim.SetTrigger("falling_to_land");
            playerAnim.ResetTrigger("falling");
        }


    }
    void OnCollisionLeave(Collider collision)
    {
        if (collision.gameObject.tag == "Push")
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerAnim.ResetTrigger("push");
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            }
        }
    }

  
    void OnAnimatorTransition()
    {
        if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("fall_to_idle"))
        {
            playerAnim.SetTrigger("idle");
            playerAnim.ResetTrigger("falling");
        }
    }

}