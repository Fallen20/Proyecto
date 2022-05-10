using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_Chapter3 : MonoBehaviour
{
    //personaje
    private BoxCollider2D collider;
	private Animator animator;
    private SpriteRenderer spritePersonaje;

    private int damage=1;
    private GameObject objetoTrigger;

    void Start(){
        //pillar lo del propio objeto
        collider=GetComponent<BoxCollider2D>();
		animator=GetComponent<Animator>();
		spritePersonaje=GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
       
        float horitontalMove=Input.GetAxisRaw("Horizontal");
    	float verticalMove=Input.GetAxisRaw("Vertical");
    	
    	variablesGeneral.moveDelta=new Vector3(horitontalMove, verticalMove,0);
		RaycastHit2D hit;

		//reset animaciones
    	// animator.SetBool("topMove",false);
    	// animator.SetBool("BotMove",false);
    	animator.SetBool("horizMove",false);
        animator.SetBool("attack1", false);
        animator.SetBool("attack2", false);

    	if(variablesGeneral.canMove){//apreta D
			if(variablesGeneral.moveDelta.x<0){
				animator.SetBool("horizMove",true);
				transform.localScale=Vector3.one;
				spritePersonaje.flipX = false;
			}
			else if(variablesGeneral.moveDelta.x>0){//apreta A
				animator.SetBool("horizMove",true);
				spritePersonaje.flipX = true;//flip
				//transform.localScale=new Vector3(-1,1,1);//si usas esto con la cam dentro, glichea. Mejor usar el flip del sprite
			}

			hit=Physics2D.BoxCast(
									transform.position,
									collider.size,
									0,new Vector2(variablesGeneral.moveDelta.x,0),
									Mathf.Abs(variablesGeneral.moveDelta.x*variablesGeneral.velocidad*Time.deltaTime),
									LayerMask.GetMask("Actor","blockWall")//con que layers interactua
								);
			if(hit.collider==null){//no hemos chocado
				//mover
				transform.Translate(variablesGeneral.moveDelta.x*variablesGeneral.velocidad*Time.deltaTime,0,0);
			}
			
		
			if(variablesGeneral.moveDelta.y<0){//apreta w
				// animator.SetBool("BotMove",true);
				// transform.localScale=Vector3.one;
			}
			else if(variablesGeneral.moveDelta.y>0){//apreta s
	    		// animator.SetBool("topMove",true);
	    	}

			hit=Physics2D.BoxCast(
									transform.position,
									collider.size,
									0,new Vector2(0,variablesGeneral.moveDelta.y),
									Mathf.Abs(variablesGeneral.moveDelta.y*variablesGeneral.velocidad*Time.deltaTime),
									LayerMask.GetMask("Actor","blockWall")//busca objetos con estas layers
								);

			if(hit.collider==null){//no hemos chocado
				//mover
				transform.Translate(0,variablesGeneral.moveDelta.y*variablesGeneral.velocidad*Time.deltaTime,0);
			}

            if(Input.GetKey(KeyCode.Z)){//ataque 1
                animator.SetBool("attack1", true);
            }
            if(Input.GetKey(KeyCode.X)){//ataque 2
                animator.SetBool("attack2", true);
            }

            if(animator.GetCurrentAnimatorStateInfo(0).IsName("ganmaAttack1") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime>1){
                damage=2;
            }

            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime>1){
                
            }
		}
    }


//----------------
    void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log(coll.gameObject.name);
        objetoTrigger=coll.gameObject;
    }

	void OnTriggerExit2D(Collider2D coll) {objetoTrigger=null;}

}
