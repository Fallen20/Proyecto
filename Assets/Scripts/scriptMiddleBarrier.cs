using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMiddleBarrier : MonoBehaviour
{
    public variablas_LastChapter variablas_LastChapter;
    
    void Start(){
    }
    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name=="ganma_Lvl3"){
        	gameObject.SetActive(false);   
        	variablas_LastChapter.triggerInitial();
       	}
    }
}
