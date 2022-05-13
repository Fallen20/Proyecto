using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class resetChapter3 : MonoBehaviour
{

    public void restartGame(){
    	variablesGeneral.canMove=true;
    	SceneManager.LoadScene("chapter3");
    }

    public void returnStart(){
    	SceneManager.LoadScene("Initial_Scene");
    }
}
