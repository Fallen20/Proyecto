using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition_Chpt2_3 : MonoBehaviour
{
     public AudioClip thunder;

    public void playThunderSound(){
        AudioSource.PlayClipAtPoint (thunder, new Vector3(370,200,0));    }

}
