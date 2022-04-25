using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class scriptInitialStory : MonoBehaviour{
    public Image imagenFondo;
    public Canvas personajeBocadillo;
    public Canvas canvasAnimation;

    public Sprite imagen_Initial_1;
    public Sprite imagen_Initial_2;
    public Sprite imagen_Initial_3;
    public Sprite imagen_Initial_4;

    public Sprite imagen_Initial_5;
    public Sprite imagen_Initial_6;
    public Sprite imagen_Initial_7;

    public Animator animator;
    public Animator fadeAnimation;

    private bool changed=false;
    private bool changed2=false;

//----------------------
    void Start(){
        hideAnimationAndTalkingCanvas();

        //tras unos segundos cambia
        Invoke("changeImage",1f);
        Invoke("changeImage",2.5f);
    }

//-----------------------
    void changeImage(){
        if(!changed){
            imagenFondo.sprite=imagen_Initial_2;
            changed=true;
        }
        else{
            imagenFondo.sprite=imagen_Initial_3;
            showTalkingCanvas();

            changed=false;

            Invoke("hideAnimationAndTalkingCanvas",3.5f);//oculta el canvas de hablar y el de animacion
            Invoke("changeAnimation",3.5f);//empieza la animacion
        }
    }

    void changeAnimation(){
        imagenFondo.sprite=imagen_Initial_4;//cambia el fondo

        canvasAnimation.GetComponent<Canvas>().enabled = true;//muestra el canvas
        animator.SetBool("enterAnimation",true);//empieza la animacion

        //acaba la animacion
        Invoke("hideAnimationAndTalkingCanvas",2.5f);//oculta el canvas de animacion
        
        //cambia la imagen
        Invoke("changeImage2",2.5f);

    }


    void changeImage2(){

        if(!changed && !changed2){
            imagenFondo.sprite=imagen_Initial_5;
            changed2=true;
            Invoke("changeImage2",2f);
        }
        else if(!changed && changed2){
            imagenFondo.sprite=imagen_Initial_6;
            Invoke("changeImage2",2f);
            changed2=false;
            changed=true;
        }
        else{
             imagenFondo.sprite=imagen_Initial_7;
             //fade
             fadeAnimation.SetBool("fade", true);
             //loadScene
             Invoke("LoadFadeScene",2f);

        }

        
        
    }
//-------------------
    void hideAnimationAndTalkingCanvas(){
        personajeBocadillo.GetComponent<Canvas>().enabled = false;
        canvasAnimation.GetComponent<Canvas>().enabled = false;
    }

    void showTalkingCanvas(){
        personajeBocadillo.GetComponent<Canvas>().enabled = true;
    }

//-----------------
	public void LoadFadeScene(){
        SceneManager.LoadScene("SampleScene");
    }
}
