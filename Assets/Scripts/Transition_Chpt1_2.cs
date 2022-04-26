using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition_Chpt1_2 : MonoBehaviour{
    public Animator animator1;
    public Animator animator2;
    public Animator animator3;
    public Animator animator4;
    public Animator fadeAnimator;

    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3;
    public Canvas canvas4;
    public Canvas canvasFade;

    private bool primero=false;
    private bool segundo=false;
    private bool tercero=false;


    void Start(){
        //ocultar canvas
        canvas1.GetComponent<Canvas>().enabled = true;
        canvas2.GetComponent<Canvas>().enabled = false;
        canvas3.GetComponent<Canvas>().enabled = false;
        canvas4.GetComponent<Canvas>().enabled = false;
        canvasFade.GetComponent<Canvas>().enabled = false;

        animator1.SetBool("running", true);//empezar animacion
    }

    void Update(){

        
        if(animator1.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !primero){//acaba la animacion
            primero=true;
            Invoke("showAnimation2",1f);//tras un segundo pone la siguiente animacion
        }        

        if(animator2.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !segundo){//acaba la animacion
            segundo=true;

            Invoke("showFade",7f);
            Invoke("hideFade",8.7f);
            Invoke("showAnimation3",8.8f);//tras un segundo pone la siguiente animacion
        }
         if(animator3.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !tercero){//acaba la animacion
            tercero=true;

            Invoke("showAnimation4",13f);//tras un segundo pone la siguiente animacion
        }
    }

//-----------------------
    void showFade(){
        canvasFade.GetComponent<Canvas>().enabled = true;
        fadeAnimator.SetBool("fade", true);
    }

    void hideFade(){

        fadeAnimator.SetBool("fade", false);
    }

//-----------------------
    void showAnimation2(){
        //ocultar los canvas
        canvas1.GetComponent<Canvas>().enabled = false;
        canvas3.GetComponent<Canvas>().enabled = false;
        canvas4.GetComponent<Canvas>().enabled = false;

        //mostrar el de la animacion
        canvas2.GetComponent<Canvas>().enabled = true;

        animator2.SetBool("running", true);//empezar animacion
    }

    void showAnimation3(){
        //ocultar los canvas
        canvas1.GetComponent<Canvas>().enabled = false;
        canvas2.GetComponent<Canvas>().enabled = false;
        canvas4.GetComponent<Canvas>().enabled = false;
        
        //mostrar el de la animacion
        canvas3.GetComponent<Canvas>().enabled = true;

        animator3.SetBool("running", true);//empezar animacion
    }

    void showAnimation4(){
        //ocultar los canvas
        canvas1.GetComponent<Canvas>().enabled = false;
        canvas2.GetComponent<Canvas>().enabled = false;
        canvas3.GetComponent<Canvas>().enabled = false;
        
        //mostrar el de la animacion
        canvas4.GetComponent<Canvas>().enabled = true;

        animator4.SetBool("running", true);//empezar animacion

        Invoke("LoadFadeScene",2f);//pasar a la siguiente escena
    }

    public void LoadFadeScene(){
        SceneManager.LoadScene("chapter2");
    }
}
