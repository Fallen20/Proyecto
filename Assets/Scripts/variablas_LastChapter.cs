using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class variablas_LastChapter : MonoBehaviour
{
    private bool middleReached=false;
    public static bool endReached=false;
    public GameObject barreraInicio;

    public Canvas canvas;
    public Text text;

    void Start(){
        showCanvas();
        text.text="texto placeholder";
    }
    private void Update() {
        eraseBarrier();
    }

    
    public void eraseBarrier(){
        if(endReached){barreraInicio.SetActive(false);}
        else{return;}
    }

    public void triggerInitial(){
        if(!middleReached){
            text.text="texto primer trigger";
            Debug.Log(text.text);
            middleReached=true;
        }
        else{return;}
        
    }

    public void triggerFinal(){
        if(!endReached){
            endReached=true;
            text.text="texto final trigger";
            Debug.Log(text.text);
        }
        else{return;}
        
    }

    public void triggerEnding(){

        //no te mueves
        variablesGeneral.canMove=false;

        //el daño recibido no cuenta
        variablesGeneral.canBeDamaged=false;

        text.text="texto ending :')";
        Debug.Log(text.text);
    }

    public void hideCanvas(){canvas.GetComponent<Canvas>().enabled=false;}
    public void showCanvas(){canvas.GetComponent<Canvas>().enabled=true;}

    
}
