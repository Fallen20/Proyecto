using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptEndBarrier : MonoBehaviour
{
    public variablas_LastChapter variablas_LastChapter;
    
    
    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name=="ganma_Lvl3"){
        	gameObject.SetActive(false);   
        	variablas_LastChapter.triggerFinal();
        }   
    }
}
