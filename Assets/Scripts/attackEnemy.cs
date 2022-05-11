using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemy : MonoBehaviour
{
    private CircleCollider2D collider;
    private Animator animator;
    private GameObject objetoTrigger;
    private playerScript_Chapter3 player;
    Vector3 vector= new Vector3();


    void Start()
    {
        collider=GetComponent<CircleCollider2D>();
        animator=GetComponent<Animator>();
        
    }

    private void Update() {
        
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("attack_Enemigo") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime>0 &&
            objetoTrigger!=null){
                reducePlayerHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name=="ganma"){
            objetoTrigger=coll.gameObject;
            //ataca
            animator.SetBool("attack", true);

            Invoke("falseAnimation",1f);
        }
        else{objetoTrigger=null;}
        
    }
    private void OnTriggerExit2D(Collider2D other) {objetoTrigger=null;}

    private void falseAnimation(){
        animator.SetBool("attack", false);
    }

//------------
    void reducePlayerHealth(){
        //pillas el script
        player=objetoTrigger.GetComponent<playerScript_Chapter3>();
        //llamas al metodo
        player.taken_Damage(1);
    }
}
