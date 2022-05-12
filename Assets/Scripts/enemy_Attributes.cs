using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Attributes : MonoBehaviour
{
   public int health=15;

    void Update(){
        if(health<=0){
            generate_Enemies_Middle.created-=1;
            Destroy(gameObject);
        }
    }
   public void reduceHealth(int damage){
       health-=damage;
   }
}
