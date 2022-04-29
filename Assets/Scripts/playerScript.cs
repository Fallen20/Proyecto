using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class playerScript : MonoBehaviour
{
	//personaje
    public BoxCollider2D collider;
	private Animator animator;

	//animator externo
	public Animator fadeAnimation;

	//expresiones, canvas
	public Canvas canvas;
	public Text text;
	public Canvas instructionsCanvas;
	public Text instructions;

	public Image spriteExpressions;
	public Sprite expresion1;
	public Sprite expresion2;
	public Sprite expresion3;
	public Sprite expresion4;
	public Sprite expresion5;
	public Sprite expresionTrashBag;
	public Sprite expresionTrash;
	public Sprite expresionTrashCan;

	//elementos interactuables
	private SpriteRenderer tuft1;
	private SpriteRenderer tuft2;
	private SpriteRenderer tuft3;
	private SpriteRenderer tuft4;
	private SpriteRenderer tuftFinale;

	private GameObject objetoTrigger;

	private GameObject tuft1Trigger;
	private GameObject tuft2Trigger;
	private GameObject tuft3Trigger;
	private GameObject tuft4Trigger;

    void Start()
    {
		//pillar lo del propio objeto
        collider=GetComponent<BoxCollider2D>();
		animator=GetComponent<Animator>();

		//pillas los tufts por tag
        tuft1=GameObject.FindWithTag("tuft1").GetComponent<SpriteRenderer>();
		tuft2=GameObject.FindWithTag("tuft2").GetComponent<SpriteRenderer>();
		tuft3=GameObject.FindWithTag("tuft3").GetComponent<SpriteRenderer>();
		tuft4=GameObject.FindWithTag("tuft4").GetComponent<SpriteRenderer>();
		tuftFinale=GameObject.FindWithTag("tuftFinale").GetComponent<SpriteRenderer>();

		//pillas los triggers
		tuft1Trigger=GameObject.FindWithTag("tuft1_Interact").GetComponent<GameObject>();
		tuft2Trigger=GameObject.FindWithTag("tuft2_Interact").GetComponent<GameObject>();
		tuft3Trigger=GameObject.FindWithTag("tuft3_Interact").GetComponent<GameObject>();
		tuft4Trigger=GameObject.FindWithTag("tuft4_Interact").GetComponent<GameObject>();


		//ocultar canvas
        canvas.GetComponent<Canvas>().enabled = false;

		//ocultar tuft final
		tuftFinale.GetComponent<SpriteRenderer>().enabled = false;


		variablesGeneral.canMove=false;
		//sacar las instrucciones
			instructions.text="Move with WASD or arrows. Interact with objects with E";
			Invoke("changeInitialText", 4f);//tras 20 seg saca el metodo

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	float horitontalMove=Input.GetAxisRaw("Horizontal");
    	float verticalMove=Input.GetAxisRaw("Vertical");
    	
    	variablesGeneral.moveDelta=new Vector3(horitontalMove, verticalMove,0);
		RaycastHit2D hit;

		//reset animaciones
    	animator.SetBool("topMove",false);
    	animator.SetBool("BotMove",false);
    	animator.SetBool("horizMove",false);


		//mirar si ha pillado todos
		if(variablesGeneral.pillado1==1 && variablesGeneral.pillado2==1 && variablesGeneral.pillado3==1 && variablesGeneral.pillado4==1){
			tuftFinale.GetComponent<SpriteRenderer>().enabled = true;
		}
    	if(variablesGeneral.canMove){//apreta D
			if(variablesGeneral.moveDelta.x<0){
				animator.SetBool("horizMove",true);
				transform.localScale=Vector3.one;
			}
			else if(variablesGeneral.moveDelta.x>0){//apreta A
				animator.SetBool("horizMove",true);
				transform.localScale=new Vector3(-1,1,1);//flip
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
				animator.SetBool("BotMove",true);
				transform.localScale=Vector3.one;
			}
			else if(variablesGeneral.moveDelta.y>0){//apreta s
	    		animator.SetBool("topMove",true);
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
			

			//apretas a la E y estas en el trigger
			if(Input.GetKey(KeyCode.E) && objetoTrigger){
				interactable(objetoTrigger);
			}
			
	    	  	
    	}
    	 
    }




//---------------
	void OnTriggerEnter2D(Collider2D coll) {
		objetoTrigger=coll.gameObject;
	}

	void OnTriggerExit2D(Collider2D coll) {
		objetoTrigger=null;
	}

//--------------------------
	void interactable(GameObject coll){
		variablesGeneral.canMove=false;


		//pillas el nombre de lo que tocas
		variablesGeneral.spriteTocado=coll.name;

		//entonces decides las cosas
		decideText();

		//sacar canvas
		canvas.GetComponent<Canvas>().enabled = true;
	}
//----------------
   	public void hideCanvas(){
		//quitar tufts pillado
   		if(variablesGeneral.spriteTocado=="tuft1"){
			tuft1.gameObject.SetActive(false);
		}
		if(variablesGeneral.spriteTocado=="tuft2"){
			tuft2.gameObject.SetActive(false);
		}
		if(variablesGeneral.spriteTocado=="tuft3"){
			tuft3.gameObject.SetActive(false);
		}
		if(variablesGeneral.spriteTocado=="tuft4"){
			tuft4.gameObject.SetActive(false);
		}

		if(variablesGeneral.spriteTocado!="tuftFinale"){
			//quitar canvas y poder moverse
			canvas.GetComponent<Canvas>().enabled = false;
			variablesGeneral.canMove=true;
		}

		else if(variablesGeneral.spriteTocado=="tuftFinale"){
			tuftFinale.gameObject.SetActive(false);
			//fade
			fadeAnimation.SetBool("fade", true);
			//cambiar escena
			Invoke("LoadFadeScene",1f);
		}


		
   	}
//----------------------
	public void decideText(){

		//cambias texto y expresion acorde a las variables
		if(variablesGeneral.spriteTocado=="Interactable_TrashCan"){//contenedores
			text.text="Sometimes I find food inside. Not the time to do it now";
			spriteExpressions.sprite=expresionTrashCan;
			return;
		}

		if(variablesGeneral.spriteTocado=="Interactable_TrashBag"){//bolsas basura
			text.text="...ew";
			spriteExpressions.sprite=expresionTrashBag;
			return;
		}

		if(variablesGeneral.spriteTocado=="Interactable_Trash"){//cubos basura
			text.text="This things are very shiny";
			spriteExpressions.sprite=expresionTrash;
			return;
		}

		
		if(variablesGeneral.pillado1==0 && variablesGeneral.pillado2==0 && variablesGeneral.pillado3==0 && variablesGeneral.pillado4==0){
			text.text=variablesGeneral.pillado1Txt;

			variablesGeneral.pillado1=1;
			spriteExpressions.sprite=expresion1;//surprised

			return;
		}

		else if(variablesGeneral.pillado1==1 && variablesGeneral.pillado2==0 && variablesGeneral.pillado3==0 && variablesGeneral.pillado4==0){
			text.text=variablesGeneral.pillado2Txt;

			variablesGeneral.pillado2=1;
			spriteExpressions.sprite=expresion2;//worried
			return;
		}

		else if(variablesGeneral.pillado1==1 && variablesGeneral.pillado2==1 && variablesGeneral.pillado3==0 && variablesGeneral.pillado4==0){
			text.text=variablesGeneral.pillado3Txt;

			variablesGeneral.pillado3=1;
			spriteExpressions.sprite=expresion3;//fear
			return;
		}

		else if(variablesGeneral.pillado1==1 && variablesGeneral.pillado2==1 && variablesGeneral.pillado3==1 && variablesGeneral.pillado4==0){
			text.text=variablesGeneral.pillado4Txt;

			variablesGeneral.pillado4=1;
			spriteExpressions.sprite=expresion4;//dark expression 1
			return;
		}

		else if(variablesGeneral.pillado1==1 && variablesGeneral.pillado2==1 && variablesGeneral.pillado3==1 && variablesGeneral.pillado4==1){
			text.text=variablesGeneral.pilladoFinaleTxt;
			spriteExpressions.sprite=expresion5;//dark expression 2
			return;
		}

	}

//-----------------
	public void LoadFadeScene(){
        SceneManager.LoadScene("transition_part1_to_2");
    }
	//----------------
	public void changeInitialText(){
		//sacar el objetivo
		instructions.text="Objective: Explore the forest to find clues of Ganmas' sister";
		Invoke("hideInstructionsCanvas", 2f);//tras 20 seg saca el metodo
	}
	//-----------
	public void hideInstructionsCanvas(){
		//no dejar mover hasta dentro de un par de segundos y ocultar canvas
		instructionsCanvas.GetComponent<Canvas>().enabled = false;
		variablesGeneral.canMove=true;
	}
}
