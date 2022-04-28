using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript_Chpt2 : MonoBehaviour
{
	public Transform lookAt;
	public float limitX=0.15f;
	public float limitY=0.15f;

void LateUpdate()
    {
        Vector3 delta=Vector3.zero;

//estamos en el rango de X
        float deltaX=lookAt.position.x-transform.position.x;

        if(deltaX<limitX || deltaX < -limitX){
        	if(transform.position.x<lookAt.position.x){
        		delta.x=deltaX-limitX;
        	}
        	else{delta.x=deltaX+limitX;}
        }

        //estamos en el rango de Y
        float deltaY=lookAt.position.y-transform.position.y;

        if(deltaY<limitY || deltaY < -limitY){
        	if(transform.position.y<lookAt.position.y){
        		delta.y=deltaY-limitY;
        	}
        	else{delta.y=deltaY+limitY;}
        }

        //mover la camara
        transform.position+=new Vector3(delta.x,deltaY,0);
    }

   
}
