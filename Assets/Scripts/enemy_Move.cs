using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Move : MonoBehaviour
{
    //esto solo persigue
    
    [HideInInspector] public BoxCollider2D collider;
    public float velocidad=1f;
    private Transform objetoTrigger;
    private SpriteRenderer sprite;

    void Start(){
        collider=GetComponent<BoxCollider2D>();
        sprite=GetComponent<SpriteRenderer>();
    }
    void Update(){

        if(objetoTrigger!=null){
            MoveEnemy(transform.position);
        }
    }

    public void MoveEnemy(Vector3 position){
        if(transform.position.x<0){sprite.flipX=true;}
        else{sprite.flipX=false;}
        transform.position=Vector2.MoveTowards(transform.position, objetoTrigger.position, velocidad*Time.deltaTime);
    }
//----------
    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name=="ganma"){
            objetoTrigger=coll.transform;
        }
        else{objetoTrigger=null;}
    }
    private void OnTriggerExit2D(Collider2D other) {
        objetoTrigger=null;
    }

}
