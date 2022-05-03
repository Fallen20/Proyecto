using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript1_Chapter2 : MonoBehaviour
{
    //personaje
    private BoxCollider2D collider;
	private Animator animator;
	private SpriteRenderer spritePersonaje;

	//animator externo
	public Animator fadeAnimation;

	//canvas, texto e imagenes
	private Canvas canvasGanma;
	private Image canvasColorGanma;
	private Text textoGanma;
	private Image imagenGanma;

	private Canvas canvasOtros;
	private Text textoOtros;
	private Text quienHablaOtros;
	private Image imagenOtros;
	private Canvas gameObjectBotonesMision;
	
	int contar=0;

	//expresiones
	public Sprite[] expresionesGanma;
	public Sprite[] expresionesWisp;
	public Sprite[] expresionesKoma;
	public Sprite[] expresionesAwami;
	public Sprite[] expresionesAkane;
	public Sprite[] expresionesKiyu;
	public Sprite[] expresionesSantos;
	public Sprite[] expresionesRacoon;
	public Sprite[] expresionesHemi;
	public Sprite[] expresionesGhoul;
	public Sprite[] expresionesPumpkin;
	public Sprite[] expresionesSkyan;
	public Sprite[] expresionesRennie;
	public Sprite[] expresionesWhiskers;
	public Sprite[] expresionesPure;
	public Sprite[] expresionesBounce;

    //TELEPORTDaysS
	//dias
	private Transform secondDay;
	private Transform thirdDay;
	private Transform forthDay;
	private Transform fifthDay;

	//sitios
	private Transform teleportDaysGreenLeft_Day2;
	private Transform teleportDaysGreenRight_Day2;

	private Transform teleportDaysGreenLeft_Day3;
	private Transform teleportDaysGreenRight_Day3;
	private Transform teleportDaysBlueTop_Day3;
	private Transform teleportDaysBlueBottom_Day3;
	private Transform teleportDaysYellowBottom_Day3;
	private Transform teleportDaysYellowTop_Day3;


	//variables a usar
    private GameObject objetoTrigger;
	


    void Start()
    {
		variablesGeneral.canMove=false;
        //pillar lo del propio objeto
        collider=GetComponent<BoxCollider2D>();
		animator=GetComponent<Animator>();
		spritePersonaje=GetComponent<SpriteRenderer>();

		//PILLAR COSAS POR TAG (porque sino son infinitas var a asignar :( )
		//canvas, texto,imagen
		canvasGanma=GameObject.FindWithTag("canvasGanma").GetComponent<Canvas>();
		textoGanma=GameObject.FindWithTag("textoGanma").GetComponent<Text>();
		imagenGanma=GameObject.FindWithTag("imagenGanma").GetComponent<Image>();
		canvasColorGanma=GameObject.FindWithTag("canvasColorGanma").GetComponent<Image>();

		canvasOtros=GameObject.FindWithTag("canvasOtros").GetComponent<Canvas>();
		textoOtros=GameObject.FindWithTag("textoOtros").GetComponent<Text>();
		imagenOtros=GameObject.FindWithTag("imagenOtros").GetComponent<Image>();
		quienHablaOtros=GameObject.FindWithTag("quienHablaOtros").GetComponent<Text>();
		gameObjectBotonesMision=GameObject.FindWithTag("gameObjectBotonesMision").GetComponent<Canvas>();

		//teleportDayss

		//salas
		teleportDaysGreenLeft_Day2=GameObject.FindWithTag("teleportGreenLeft_Day2").GetComponent<Transform>();
		teleportDaysGreenRight_Day2=GameObject.FindWithTag("teleportGreenRight_Day2").GetComponent<Transform>();

		teleportDaysGreenLeft_Day3=GameObject.FindWithTag("teleportGreenLeft_Day3").GetComponent<Transform>();
		teleportDaysGreenRight_Day3=GameObject.FindWithTag("teleportGreenRight_Day3").GetComponent<Transform>();
		teleportDaysBlueTop_Day3=GameObject.FindWithTag("teleportBlueLeft_Day3").GetComponent<Transform>();//top
		teleportDaysBlueBottom_Day3=GameObject.FindWithTag("teleportBlueRight_Day3").GetComponent<Transform>();//bottom
		teleportDaysYellowBottom_Day3=GameObject.FindWithTag("teleportYellowLeft_Day3").GetComponent<Transform>();//bottom
		teleportDaysYellowTop_Day3=GameObject.FindWithTag("teleportYellowRight_Day3").GetComponent<Transform>();//top


		//dias
		secondDay=GameObject.FindWithTag("secondDay").GetComponent<Transform>();
		thirdDay=GameObject.FindWithTag("thirdDay").GetComponent<Transform>();
	 	forthDay=GameObject.FindWithTag("forthDay").GetComponent<Transform>();
		fifthDay=GameObject.FindWithTag("fifthDay").GetComponent<Transform>();

		// ocultar canvas inecesarios
		canvasGanma.GetComponent<Canvas>().enabled=false;
		gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;


		canvasOtros.GetComponent<Canvas>().enabled=true;
		imagenOtros.sprite=expresionesWisp[0];
		quienHablaOtros.text="Wisp";
		textoOtros.text=variable_Text.wisp_FirstDay1;

        
    }

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
				interactable();
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
//---------------


	//cosas con canvas y botones

	//ocultar
	public void hideCanvas_Ganma(){
		if(!variablesGeneral.startDone){initialConversation();}
		else if(contar<4 && contar!=0){//si has aceptado la mision, apretar saca el siguiente dialogo
			acceptAwami_KomaMission();
		}
		else{canvasGanma.GetComponent<Canvas>().enabled=false;}
		
	}

	public void hideCanvas_Otros(){
		
		if(!variablesGeneral.startDone){initialConversation();}
		else if(variablesGeneral.contador2==1){Mission_Koma_Awami();}
		else if(contar<4 && contar!=0){//si has aceptado la mision, apretar saca el siguiente dialogo
			acceptAwami_KomaMission();
		}
		else{
			canvasOtros.GetComponent<Canvas>().enabled=false;
			gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;
			variablesGeneral.canMove=true;
			contar=0;
			variablesGeneral.contador2=0;
		}
	}

	void trueFade(){
		fadeAnimation.SetBool("fade", true);
	}
	void falseFade(){
		fadeAnimation.SetBool("fade", false);
	}

//---------

//pre aceptar misiones/cambiar dia
	public void goSleep_Question(){
		
		//cambias cosas
		imagenOtros.sprite=expresionesWisp[7];
		quienHablaOtros.text="Wisp";
		textoOtros.text=variable_Text.passDay_normal;
		
		canvasOtros.GetComponent<Canvas>().enabled=true;//sacas el canvas
		gameObjectBotonesMision.GetComponent<Canvas>().enabled=true;
	}

	public void Mission_Koma_Awami(){//te preguntan
		switch(variablesGeneral.contador2){
			case 0:
				quienHablaOtros.text="Koma";
				imagenOtros.sprite=expresionesKoma[4];
				textoOtros.text=variable_Text.koma_SecondDay_PreMission_1;
				canvasOtros.GetComponent<Canvas>().enabled=true;
				variablesGeneral.contador2+=1;
				break;
			case 1:
				quienHablaOtros.text="Awami";
				imagenOtros.sprite=expresionesAwami[4];
				textoOtros.text=variable_Text.awami_SecondDay_PreMission_1;
				canvasOtros.GetComponent<Canvas>().enabled=true;
				gameObjectBotonesMision.GetComponent<Canvas>().enabled=true;
				variablesGeneral.contador2+=1;
				break;
		}
			
	}

	//esto es del boton de aceptar
	public void decideFate(){//aceptas misiones
		if(variablesGeneral.spriteTocado=="wisp_interactable"){goSleep();}
		if(variablesGeneral.spriteTocado=="awami_koma_interactable"){
			acceptAwami_KomaMission();
		}
		else{
			variablesGeneral.contador2=0;
			contar=0;
		}
	}

	//aceptas
	public void goSleep(){//hacer la accion
		//fade
		fadeAnimation.SetBool("fade", true);

		//tras un segundo
		Invoke("falseFade",1f);

		Invoke("teleportDays",1.5f);
	
		//ocultas
		gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;
		canvasOtros.GetComponent<Canvas>().enabled=false;
		variablesGeneral.canMove=true;
	}

	void acceptAwami_KomaMission(){
		gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;

		switch(contar){
				case 0:
					canvasGanma.GetComponent<Canvas>().enabled=true;
					canvasOtros.GetComponent<Canvas>().enabled=false;

					imagenGanma.sprite=expresionesGanma[25];
					textoGanma.text=variable_Text.ganmaMissionResponse_1_Ok;
					contar+=1;
					break;

				case 1:
					canvasGanma.GetComponent<Canvas>().enabled=false;
					canvasOtros.GetComponent<Canvas>().enabled=true;

					quienHablaOtros.text="Awami";
					imagenOtros.sprite=expresionesAwami[5];
					textoOtros.text=variable_Text.awami_SecondDay_PreMission_2;
					contar+=1;
					
					break;

				case 2:
					canvasGanma.GetComponent<Canvas>().enabled=false;
					canvasOtros.GetComponent<Canvas>().enabled=true;

					quienHablaOtros.text="Koma";
					imagenOtros.sprite=expresionesKoma[5];
					textoOtros.text=variable_Text.koma_SecondDay_PreMission_2;
					contar+=1;
					break;
				
				case 3:
					Debug.Log("acepto mision");
					//fade
					//quita los canvas
					//pon los personajes en el otro sitio
					//oculta el original
					//desfade
					break;
			}
		
		
			
		
	}

	


	

//----------------
	public void interactable(){
		variablesGeneral.canMove=false;

		//pillas el nombre de lo que tocas
		variablesGeneral.spriteTocado=objetoTrigger.name;

		//entonces decides las cosas
		decideText(variablesGeneral.spriteTocado);
	}

	void decideText(string spriteTocado){//esto SOLO saca texto
		 if(variablesGeneral.spriteTocado=="wisp_interactable"){
			 goSleep_Question();
		 }
		 if(variablesGeneral.spriteTocado=="bed_interactable"){endChapter();}

		 if(variablesGeneral.spriteTocado=="kiyu_interactable"){
			 quienHablaOtros.text="Kiyu";
			 imagenOtros.sprite=expresionesKiyu[1];
			 textoOtros.text=variable_Text.kiyu_FirstDay;
			 canvasOtros.GetComponent<Canvas>().enabled=true;
		 }
		 if(variablesGeneral.spriteTocado=="akane_interactable"){
			 quienHablaOtros.text="Akane";
			 imagenOtros.sprite=expresionesAkane[0];
			 textoOtros.text=variable_Text.akane_FirstDay;
			 canvasOtros.GetComponent<Canvas>().enabled=true;
		 }
		 if(variablesGeneral.spriteTocado=="koma_interactable"){
			 quienHablaOtros.text="Koma";
			 imagenOtros.sprite=expresionesKoma[0];
			 textoOtros.text=variable_Text.koma_FirstDay;
			 canvasOtros.GetComponent<Canvas>().enabled=true;
		 }
		 if(variablesGeneral.spriteTocado=="awami_interactable"){
			 quienHablaOtros.text="Awami";
			 imagenOtros.sprite=expresionesAwami[0];
			 textoOtros.text=variable_Text.awami_FirstDay;
			 canvasOtros.GetComponent<Canvas>().enabled=true;
		 }
		 if(variablesGeneral.spriteTocado=="awami_koma_interactable"){
			  Mission_Koma_Awami();
		 }
		 if(variablesGeneral.spriteTocado=="kiyu_Akane_interactable"){
			 quienHablaOtros.text="Kiyu";
			 imagenOtros.sprite=expresionesKiyu[7];
			 textoOtros.text=variable_Text.kiyu_SecondDay;
			 canvasOtros.GetComponent<Canvas>().enabled=true;
		 }

	}


	void endChapter(){
		Debug.Log("change scene+fade");
	}
//------------
	void initialConversation(){
		switch(variablesGeneral.contador){
			case 0:
				imagenOtros.sprite=expresionesWisp[1];
				quienHablaOtros.text="Wisp";
				textoOtros.text=variable_Text.wisp_FirstDay2;
				variablesGeneral.contador+=1;
				break;

			case 1:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[0];
				textoGanma.text=variable_Text.ganma_FirstDay1;
				variablesGeneral.contador+=1;
				break;
			
			case 2:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				imagenOtros.sprite=expresionesWisp[2];
				textoOtros.text=variable_Text.wisp_FirstDay3;
				variablesGeneral.contador+=1;
				break;
			
			case 3:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[1];
				textoGanma.text=variable_Text.ganma_FirstDay2;
				variablesGeneral.contador+=1;
				break;
			
			case 4:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				imagenOtros.sprite=expresionesWisp[3];
				textoOtros.text=variable_Text.wisp_FirstDay4;
				variablesGeneral.contador+=1;
				break;

			case 5:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[2];
				textoGanma.text=variable_Text.ganma_FirstDay3;
				variablesGeneral.contador+=1;
				break;


			case 6:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				imagenOtros.sprite=expresionesWisp[4];
				textoOtros.text=variable_Text.wisp_FirstDay5;
				variablesGeneral.contador+=1;
				break;

			case 7:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[3];
				textoGanma.text=variable_Text.ganma_FirstDay4;
				variablesGeneral.contador+=1;
				break;

			case 8:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				imagenOtros.sprite=expresionesWisp[5];
				textoOtros.text=variable_Text.wisp_FirstDay6;
				variablesGeneral.contador+=1;
				break;

			case 9:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				imagenOtros.sprite=expresionesWisp[6];
				textoOtros.text=variable_Text.wisp_FirstDay7;
				variablesGeneral.startDone=true;
				break;
		}
	}


	void teleportDays(){
		if(!variablesGeneral.sleepDay2 && !variablesGeneral.sleepDay3
		&& !variablesGeneral.sleepDay4 && !variablesGeneral.sleepDay5){
			
			transform.position=new Vector3(secondDay.position.x,secondDay.position.y,0);//teleportDays
			variablesGeneral.sleepDay2=true;
			//del primer al segundo dia
		}
		else if(variablesGeneral.sleepDay2 && !variablesGeneral.sleepDay3
		&& !variablesGeneral.sleepDay4 && !variablesGeneral.sleepDay5){
			transform.position=new Vector3(thirdDay.position.x,thirdDay.position.y,0);//teleportDays
			variablesGeneral.sleepDay3=true;
			//del segundo al tercero
		}
		else if(variablesGeneral.sleepDay2 && variablesGeneral.sleepDay3
		&& !variablesGeneral.sleepDay4 && !variablesGeneral.sleepDay5){
			transform.position=new Vector3(forthDay.position.x,forthDay.position.y,0);//teleportDays
			variablesGeneral.sleepDay4=true;
			//del tercero al cuarto
		}
		else if(variablesGeneral.sleepDay2 && variablesGeneral.sleepDay3
		&& variablesGeneral.sleepDay4 && !variablesGeneral.sleepDay5){
			transform.position=new Vector3(fifthDay.position.x,fifthDay.position.y,0);//teleportDays
			variablesGeneral.sleepDay5=true;
			//del cuarto al quinto
		}
		else if(variablesGeneral.sleepDay2 && variablesGeneral.sleepDay3
		&& variablesGeneral.sleepDay4 && variablesGeneral.sleepDay5){
			//del cquinto a la escena
		}
	}
}
