using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody2D playerRb;
	public float speed = 0.5f;
	public float jumpSpeed = 200;
	public AudioSource jump;
	public Animator PlayerAnimator;
	public bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);

        if(Input.GetAxis("Horizontal") == 0){
        	PlayerAnimator.SetBool("isWalking",false);
        }else if(Input.GetAxis("Horizontal") < 0){
        	PlayerAnimator.SetBool("isWalking",true);
        	GetComponent<SpriteRenderer>().flipX = true;
        }else if(Input.GetAxis("Horizontal") > 0){
        	PlayerAnimator.SetBool("isWalking",true);
        	GetComponent<SpriteRenderer>().flipX = false;
        }

        if(isGrounded)
        {
        	if(Input.GetKeyDown(KeyCode.Space))
	        {
	        	playerRb.AddForce(Vector2.up * jumpSpeed);
	        	jump.Play();
	        	GetComponent<Animator>();
	        	PlayerAnimator.SetTrigger("Jump");
	        	isGrounded = false;
	        }
    	}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    	if(collision.gameObject.CompareTag("Ground"))
    	{
    		isGrounded = true;
    	}
    }
}	