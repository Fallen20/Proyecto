using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptEndingBarrier : MonoBehaviour
{
    public variablas_LastChapter variablas_LastChapter;

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name=="ganma_Lvl3"){variablas_LastChapter.triggerEnding();}   
    }
}
