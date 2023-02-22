using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
	public static int CollectableQuantity = 0;
	public Text CollectableText;
    ParticleSystem collectablePart;
    AudioSource collectableAudio;
    // Start is called before the first frame update
    void Start()
    {
        CollectableQuantity = 0;
        CollectableText = GameObject.Find("CollectableQuantityText").GetComponent<Text>();
        collectablePart = GameObject.Find("CollectableParticle").GetComponent<ParticleSystem>();
        collectableAudio =GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col){
    	if (col.tag == "Player") 
    	{
            collectableAudio.Play();
            collectablePart.transform.position = transform.position;
            collectablePart.Play();
    		gameObject.SetActive(false);
    		CollectableQuantity ++;
    		CollectableText.text = CollectableQuantity.ToString();
    	}
    }
}
