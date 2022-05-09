using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public static void LoadScene(string escena){
        SceneManager.LoadScene(escena);
    }

    public void LoadChapterScene(){
        if(changeInitialScene_Elements.chapterSelected=="chapter 0"){
            SceneManager.LoadScene("InitialScene_Story");
        }
        else if(changeInitialScene_Elements.chapterSelected=="chapter 1"){
            SceneManager.LoadScene("SampleScene");
        }
        else if(changeInitialScene_Elements.chapterSelected=="chapter 2"){//TODO
            SceneManager.LoadScene("chapter2");
        }
        else if(changeInitialScene_Elements.chapterSelected=="chapter 3"){//TODO
            SceneManager.LoadScene("chapter3");
        }
        
    }
}
