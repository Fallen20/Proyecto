using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript1_Chapter2 : MonoBehaviour
{
    //personaje
    public BoxCollider2D collider;
	private Animator animator;
	private SpriteRenderer spritePersonaje;

    //variables a usar
    public float velocidad=2f;
	private Vector3 moveDelta;
	private bool canMove=true;//cambiar si eso

	public Transform secondDay;

    private GameObject objetoTrigger;


    void Start()
    {
        //pillar lo del propio objeto
        collider=GetComponent<BoxCollider2D>();
		animator=GetComponent<Animator>();
		spritePersonaje=GetComponent<SpriteRenderer>();
        
    }

    void FixedUpdate()
    {
        float horitontalMove=Input.GetAxisRaw("Horizontal");
    	float verticalMove=Input.GetAxisRaw("Vertical");
    	
    	moveDelta=new Vector3(horitontalMove, verticalMove,0);
		RaycastHit2D hit;

		//reset animaciones
    	animator.SetBool("topMove",false);
    	animator.SetBool("BotMove",false);
    	animator.SetBool("horizMove",false);


		//mirar si ha pillado todos

    	if(canMove){//apreta D
			if(moveDelta.x<0){
				animator.SetBool("horizMove",true);
				transform.localScale=Vector3.one;
				spritePersonaje.flipX = false;
			}
			else if(moveDelta.x>0){//apreta A
				animator.SetBool("horizMove",true);
				spritePersonaje.flipX = true;//flip
				//transform.localScale=new Vector3(-1,1,1);//si usas esto con la cam dentro, glichea. Mejor usar el flip del sprite
			}

			hit=Physics2D.BoxCast(
									transform.position,
									collider.size,
									0,new Vector2(moveDelta.x,0),
									Mathf.Abs(moveDelta.x*velocidad*Time.deltaTime),
									LayerMask.GetMask("Actor","blockWall")//con que layers interactua
								);
			if(hit.collider==null){//no hemos chocado
				//mover
				transform.Translate(moveDelta.x*velocidad*Time.deltaTime,0,0);


			}
			
		
			if(moveDelta.y<0){//apreta w
				animator.SetBool("BotMove",true);
				transform.localScale=Vector3.one;
			}
			else if(moveDelta.y>0){//apreta s
	    		animator.SetBool("topMove",true);
	    	}

			hit=Physics2D.BoxCast(
									transform.position,
									collider.size,
									0,new Vector2(0,moveDelta.y),
									Mathf.Abs(moveDelta.y*velocidad*Time.deltaTime),
									LayerMask.GetMask("Actor","blockWall")//busca objetos con estas layers
								);

			if(hit.collider==null){//no hemos chocado
				//mover
				transform.Translate(0,moveDelta.y*velocidad*Time.deltaTime,0);
			}

			if(objetoTrigger!=null){
				//transform.position=new Vector3(secondDay.position.x,secondDay.position.y,0);//teletransporte
			}
		}
    }


//---------------
	void OnTriggerEnter2D(Collider2D coll) {
		objetoTrigger=coll.gameObject;
		Debug.Log(coll.gameObject.name);
	}

	void OnTriggerExit2D(Collider2D coll) {
		objetoTrigger=null;
	}

}
