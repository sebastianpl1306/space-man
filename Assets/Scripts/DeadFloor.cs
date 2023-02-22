using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadFloor : MonoBehaviour
{
	public SceneChanger ChangeScene;

    private void OnTriggerEnter2D(Collider2D collision){
    	if(collision.gameObject.CompareTag("Player")){
    		ChangeScene.ChangeSceneTo("LoseScene");
    	}
    }

}
