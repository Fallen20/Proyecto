using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMiddleBarrier : MonoBehaviour
{
    public variablas_LastChapter variablas_LastChapter;
    
    void Start(){
        Debug.Log(variablas_LastChapter==null);
    }
    private void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log(coll.gameObject.name);
        if(coll.gameObject.name=="ganma"){variablas_LastChapter.triggerInitial();}   
    }
}
