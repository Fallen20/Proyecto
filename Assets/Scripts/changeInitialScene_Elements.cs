using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeInitialScene_Elements : MonoBehaviour
{
    

    //canvas de la escena
    private Canvas canvasInicio;
    private Canvas canvasChapt;
    private Canvas canvasExtra;

    public Sprite[] imagenes;//a lo que cambia
    public Image imagenFondo;

    public static string chapterSelected;

    // Start is called before the first frame update
    void Start(){

        //pillar los canvas
		canvasInicio=GameObject.FindWithTag("canvasInicio").GetComponent<Canvas>();
		canvasChapt=GameObject.FindWithTag("canvasChapt").GetComponent<Canvas>();
		canvasExtra=GameObject.FindWithTag("canvasExtra").GetComponent<Canvas>();

        //mostrar el de inicio
        canvasInicio.GetComponent<Canvas>().enabled = true;

        //ocultar los demas
        canvasChapt.GetComponent<Canvas>().enabled = false;
		canvasExtra.GetComponent<Canvas>().enabled = false;

    }

    //------------------
    public void changeToChaptCanvas(){
        
        canvasChapt.GetComponent<Canvas>().enabled = true;

        canvasInicio.GetComponent<Canvas>().enabled = false;
        canvasExtra.GetComponent<Canvas>().enabled = false;
    }

    public void changeToextraCanvas(){
        canvasExtra.GetComponent<Canvas>().enabled = true;

        canvasInicio.GetComponent<Canvas>().enabled = false;
        canvasChapt.GetComponent<Canvas>().enabled = false;
    }


    //-----------------------
    public void changeImageChapter0(){
        Debug.Log("chapter0");
        chapterSelected="chapter 0";
        imagenFondo.GetComponent<Image>().sprite = imagenes[0];
    }

    public void changeImageChapter1(){
        Debug.Log("chapter1");
        chapterSelected="chapter 1";
        imagenFondo.GetComponent<Image>().sprite = imagenes[1];
    }

    public void changeImageChapter2(){
        Debug.Log("chapter2");
        chapterSelected="chapter 2";
        imagenFondo.GetComponent<Image>().sprite = imagenes[2];
    }

    public void changeImageChapter3(){
        chapterSelected="chapter 3";
        imagenFondo.GetComponent<Image>().sprite = imagenes[3];
    }
}
