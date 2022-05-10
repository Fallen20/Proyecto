using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private int health=3;

    public void DamegeTaken(int damage){
        health-=damage;
    }

    void FixedUpdate(){
        if(health<=0){Destroy(gameObject);}
    }
}
