using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	Rigidbody2D EnemyRb;
	float timeBeforeChange;
	SpriteRenderer EnemySpriteRend;
	public float delay = 0.5f;
	public float speed = 0.5f;
	public Animator EnemyAnimator;
	ParticleSystem DeadPar;
	AudioSource DeadAudio;
    // Start is called before the first frame update
    void Start()
    {
    	DeadPar = GameObject.Find("EnemyParticles").GetComponent<ParticleSystem>();
    	DeadAudio =GetComponentInParent<AudioSource>();
        EnemyRb = GetComponent<Rigidbody2D>();
        EnemySpriteRend = GetComponent<SpriteRenderer>();
        EnemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(speed > 0)
    	{
    		EnemySpriteRend.flipX = false;
    	}else if(speed < 0){
    		EnemySpriteRend.flipX = true;
    	}

    	EnemyRb.velocity = Vector2.right * speed;
    	if (timeBeforeChange < Time.time) 
    	{
    		speed *= -1;
    		timeBeforeChange = Time.time + delay;
    	}
    }

    private void OnCollisionEnter2D(Collision2D collision){
    	if(collision.gameObject.tag == "Player")
    	{
    		if(transform.position.y + .03f < collision.transform.position.y){
    			DeadAudio.Play();
    			DeadPar.transform.position = transform.position;
            	DeadPar.Play();
    			EnemyAnimator.SetBool("isDead", true);
    		}
    	}
    }

    private void  DisableEnemy(){
    	gameObject.SetActive(false);
    }
}
