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
    public Button buton;

    public Canvas canvasWin;

    public Canvas fadeCanvas;
    public Animator fadeAnimation;

    void Start(){
        //oculta el canvas de ganar
        canvasWin.GetComponent<Canvas>().enabled=false;

        buton.gameObject.SetActive(false);

        //sacar el primer canvas
        text.text="I should be able to escape if I follow this path...";
        showCanvas();
        fadeCanvas.sortingOrder=-10;
        canvasWin.sortingOrder=2;

        //al cabo de x segundos desaparece
        Invoke("hideCanvas",2f);

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
            middleReached=true;

            text.text="Enemies?! Did they discover me? I have no choice but to..";
            showCanvas();

             //al cabo de x segundos desaparece
            Invoke("hideCanvas",3f);

            
        }
        else{return;}
        
    }

    public void triggerFinal(){
        if(!endReached){
            endReached=true;

            text.text="A dead end?!";
            showCanvas();

            //al cabo de x segundos desaparece
            Invoke("secondCanvasEnd",2f);
        }
        else{return;}
        
    }

    public void triggerEnding(){

        //no te mueves
        variablesGeneral.canMove=false;

        //ahora sale el boton para cambiar
        buton.gameObject.SetActive(true);

        //el daño recibido no cuenta
        variablesGeneral.canBeDamaged=false;

        //fade
        fadeCanvas.sortingOrder=1;
        trueFade();

        text.text="I'm gonna survive. That's what my sister would have wanted";
        showCanvas();

    }


//-----------------------
    public void hideCanvas(){canvas.GetComponent<Canvas>().enabled=false;}
    public void showCanvas(){canvas.GetComponent<Canvas>().enabled=true;}

    void trueFade(){fadeAnimation.SetBool("fade", true);}
    void falseFade(){fadeAnimation.SetBool("fade", false);}

//------------------
    public void secondCanvasEnd(){
        text.text="I should go back and try another route...";

        //al cabo de x segundos desaparece
        Invoke("hideCanvas",3f);
    }

    public void buttonFunction(){
        Invoke("gameWin",1f);
    }

    public void gameWin(){canvasWin.GetComponent<Canvas>().enabled=true;}
}
