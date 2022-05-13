using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Attributes : MonoBehaviour
{
    private int maxHealth=30;
    public int health;
    public TextMesh texto;
    public enemy_Move enemigo;

    private void Start() {
        health=maxHealth;
    }
    void Update(){
        texto.text=health+"/"+maxHealth;
    }
    public void reduceHealth(int damage){
       health-=damage;
       if(health<=0){eliminar();}
    }

   public void eliminar(){
       generate_Enemies_Start.created-=1;
       enemigo.eliminarObjeto();
       Destroy(gameObject);
   }
}
