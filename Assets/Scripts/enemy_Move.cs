using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy_Move : MonoBehaviour
{
    //esto solo persigue
    
    [HideInInspector] public BoxCollider2D collider;
    public SpriteRenderer sprite;
    public Animator animator;
    
    public float xPos, yPos;
    public Vector3 desiredPos;
    public float timer = .5f;//cooldown
    public float timerSpeed;
    public float timeToMove=0;

    private bool chasing=false;

    private Vector3 lastMove;

    public float velocidad_Chase=1.5f;
    public float velocidad_movRandom=0.5f;
    private Transform objetoTrigger;


    void Start(){
        collider=GetComponent<BoxCollider2D>();

        //pillas un rango para que se mueva
        xPos = Random.Range(-transform.position.x-4.5f, transform.position.x+4.5f);//x
        yPos=Random.Range(-transform.position.y-4.5f, transform.position.y+4.5f);//y

        variablesGeneral.num_random=variablesGeneral.random.Next(0,10);
        if(variablesGeneral.num_random%2==0){
            //se mueve la primera vez
            desiredPos = new Vector3(xPos, transform.position.y, transform.position.z);
        }
        else{
            //se mueve la primera vez
            desiredPos = new Vector3(transform.position.x, yPos, transform.position.z);
        }
        
    }
    void Update(){

        //resets
        animator.SetBool("horizMove",false);
        animator.SetBool("topMove",false);
        animator.SetBool("bottomMove",false);

        
        if(objetoTrigger!=null){//si estas en un rango
            chasing=true;
            MoveEnemy(transform.position);
        }
        else{
            if(chasing==false){//si no estás persiguiendo al personaje

                timer += Time.deltaTime * timerSpeed;//acumulas tiempo

                if (timer >= timeToMove){//si puedes moverte (cooldown)

                    transform.position = Vector2.Lerp(transform.position, desiredPos, Time.deltaTime * velocidad_movRandom);//te mueves a la posicion
 
                   if (Vector3.Distance(transform.position, desiredPos) <= 0.01f){//si estás cerca del sitio que quieres ir, vuelves a llamarlo para moverlo
                        
                        //pillas un rango para que se mueva
                        if(lastMove!=null){
                                xPos=Random.Range(-lastMove.x-4.5f, lastMove.x+4.5f);//x
                                yPos=Random.Range(-lastMove.y-4.5f, lastMove.y+4.5f);//y
                        }
                        else{
                            xPos=Random.Range(-transform.position.x-4.5f, transform.position.x+4.5f);//x
                            yPos=Random.Range(-transform.position.y-4.5f, transform.position.y+4.5f);//y
                        }
                        variablesGeneral.num_random=variablesGeneral.random.Next(0,10);//random para que se mueva abajo o arriba

                        if(variablesGeneral.num_random%2==0){
                            desiredPos = new Vector3(xPos, transform.position.y, transform.position.z);
                        }
                        else{
                            desiredPos = new Vector3(transform.position.x, yPos, transform.position.z);
                        }
                        changeAndFlipCharacter();
                    
                        timer = 0.0f;//reset timer cooldown
                    }
                }
            }
        }
            
    }
//------------------------

    public void MoveEnemy(Vector3 position){
        transform.position=Vector2.MoveTowards(transform.position, objetoTrigger.position, velocidad_Chase*Time.deltaTime);
    

         changeAndFlipCharacter();

        lastMove=objetoTrigger.position; 
    }

    public void changeAndFlipCharacter(){
        if(transform.position.x<0){sprite.flipX = true;}
        else{sprite.flipX = false;}
        animator.SetBool("horizMove",true);

        //preguntar porque no paro de liarme y ha llegado un punto donde nada tiene sentido :(
            //TODO
        // animator.SetBool("bottomMove",false);
        // animator.SetBool("topMove",false);
        // animator.SetBool("horizMove",false);

        // //movimiento fijo de lado, sin diagonal
        // if(transform.position.x!=0){
        //     if(transform.position.x<0){sprite.flipX = true;}
        //     else{sprite.flipX = false;}

        //     if(transform.position.x>transform.position.y){
        //         animator.SetBool("horizMove",true);
        //     }
        //     else{
        //          if(transform.position.y<0){
        //              animator.SetBool("bottomMove",true);
        //          }
        //          else{animator.SetBool("topMove",true);}
        //     }
            
            
        // }
        
        // if(transform.position.y<0){//top
        //     if(transform.position.y>transform.position.x){
        //         animator.SetBool("topMove",true);
        //     }
        //     else{
        //          if(transform.position.x<0){
        //              animator.SetBool("horizMove",true);
        //          }
        //     }
        //     sprite.flipX = true;
        // }
        // else if(transform.position.y>0){//bott
        //     if(transform.position.y>transform.position.x){
        //         animator.SetBool("bottomMove",true);
        //     }
        //     else{
        //          if(transform.position.x<0){
        //              animator.SetBool("horizMove",true);
        //          }
        //     }
            
        //     sprite.flipX = false;//flip
        // }

        // if(transform.position.y<0){//apreta w
        //     Debug.Log("entro <0");
        //     animator.SetBool("horizMove",false);
        //     animator.SetBool("topMove",false);

        //     animator.SetBool("bottomMove",true);

        //     Debug.Log("B "+animator.GetBool("bottomMove"));
        // }
        // else if(transform.position.y>0){//apreta s
        //     Debug.Log("entro >0");
        //     animator.SetBool("horizMove",false);
        //     animator.SetBool("bottomMove",false);

        //     animator.SetBool("topMove",true);
        //      Debug.Log("T "+animator.GetBool("topMove"));
        // }



     }
//----------
    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name=="ganma"){
            objetoTrigger=coll.transform;
            lastMove=new Vector3();
        }
        else{objetoTrigger=null;}
    }
    private void OnTriggerExit2D(Collider2D other) {
        chasing=false;
        lastMove=transform.position;
        objetoTrigger=null;
    }

}
