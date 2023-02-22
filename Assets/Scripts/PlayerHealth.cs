using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	int healt = 3;
	public Image[] hearts;
	bool hasCooldown = false;
	public SceneChanger ChangeScene;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
    	if(collision.gameObject.CompareTag("Enemy")){
    		if(GetComponent<PlayerMovement>().isGrounded){
    			SubstracHealth();
    		}
    	}
    }
    
    void SubstracHealth(){
    	if(!hasCooldown){
    		if(healt > 0){
    			healt--;
    			hasCooldown = true;

    			StartCoroutine(Cooldown());
    		}
    	}

    	if(healt <= 0){
    		ChangeScene.ChangeSceneTo("LoseScene");
    	}

    	EmptyHearts();
    }

    void EmptyHearts(){
    	for(int i = 0; i < hearts.Length; i++){
    		if(healt -1 < i){
    			hearts[i].gameObject.SetActive(false);
    		}
    	}
    }

    IEnumerator Cooldown(){
    	yield return new WaitForSeconds(0.5f);
    	hasCooldown = false;

    	StopCoroutine(Cooldown());
    }
}
