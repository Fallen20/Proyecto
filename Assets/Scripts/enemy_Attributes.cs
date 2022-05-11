using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Attributes : MonoBehaviour
{
   public int health=15;

    void Update(){
        Debug.Log("Enemigo healt> "+health);
        if(health<=0){Destroy(gameObject);}
    }
   public void reduceHealth(int damage){
       Debug.Log("aaaaaaaaaaaaaaaaaa");
       health-=damage;
   }
}
