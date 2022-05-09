using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;


public class playerScript1_Chapter2 : MonoBehaviour
{
    //personaje
    private BoxCollider2D collider;
	private Animator animator;
	private SpriteRenderer spritePersonaje;
	public Sprite transparente;

	//animator externo
	public Canvas fadeCanvas;
	public Animator fadeAnimation;

	//canvas, texto e imagenes
	private Canvas canvasGanma;
	private Text textoGanma;
	private Image imagenGanma;

	private Image canvasColorGanma;
	public Sprite canvasNaranja;
	public Sprite canvasAzul;

	private Canvas canvasOtros;
	private Text textoOtros;
	private Text quienHablaOtros;
	private Image imagenOtros;

	private Canvas gameObjectBotonesMision;
	private Canvas gameObjectBotonesMision_Ganma;
	public Text textoBotonAceptar;
	public Text textoBotonDeny;

	private Canvas botonesMisionGhoul;
	public Button botonKiyu;
	public Button botonPumpkin;
	public Button botonWhiskers;


	public Canvas canvasExtra;
	public Image imagenCanvasExtra;
	public Sprite[] imagenesExtra;
	
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

	private Transform finalAwamiKomaMission;

	public GameObject komaAwami_Mission_Object;
	public Animator awamiHidden;
	public Animator komaHidden;

	public GameObject[] gameObjectRacoonMission;

	public Animator rennieObjeto;	

	//variables a usar
    private GameObject objetoTrigger;
	Random random=new System.Random();


    void Start()
    {
		sortingLayerPositive();
		Invoke("sortingLayerNegative", 1f);

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
		gameObjectBotonesMision_Ganma=GameObject.FindWithTag("gameObjectBotonesMision_Ganma").GetComponent<Canvas>();
		botonesMisionGhoul=GameObject.FindWithTag("botonesMisionGhoul").GetComponent<Canvas>();

		//teleportDayss

		//al cargar la sala lo hacen aqui
		teleportDaysGreenLeft_Day2=GameObject.FindWithTag("teleportGreenLeft_Day2").GetComponent<Transform>();
		teleportDaysGreenRight_Day2=GameObject.FindWithTag("teleportGreenRight_Day2").GetComponent<Transform>();

		teleportDaysGreenLeft_Day3=GameObject.FindWithTag("teleportGreenLeft_Day3").GetComponent<Transform>();
		teleportDaysGreenRight_Day3=GameObject.FindWithTag("teleportGreenRight_Day3").GetComponent<Transform>();
		teleportDaysBlueTop_Day3=GameObject.FindWithTag("teleportBlueRight_Day3").GetComponent<Transform>();//top
		teleportDaysBlueBottom_Day3=GameObject.FindWithTag("teleportBlueLeft_Day3").GetComponent<Transform>();//bottom
		teleportDaysYellowBottom_Day3=GameObject.FindWithTag("teleportYellowLeft_Day3").GetComponent<Transform>();//bottom
		teleportDaysYellowTop_Day3=GameObject.FindWithTag("teleportYellowRight_Day3").GetComponent<Transform>();//top


		//dias
		secondDay=GameObject.FindWithTag("secondDay").GetComponent<Transform>();
		thirdDay=GameObject.FindWithTag("thirdDay").GetComponent<Transform>();
	 	forthDay=GameObject.FindWithTag("forthDay").GetComponent<Transform>();
		fifthDay=GameObject.FindWithTag("fifthDay").GetComponent<Transform>();

		finalAwamiKomaMission=GameObject.FindWithTag("finalAwamiKomaMission").GetComponent<Transform>();
		

		// ocultar canvas inecesarios
		canvasGanma.GetComponent<Canvas>().enabled=false;
		canvasExtra.GetComponent<Canvas>().enabled=false;
		gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;
		gameObjectBotonesMision_Ganma.GetComponent<Canvas>().enabled=false;
		botonesMisionGhoul.GetComponent<Canvas>().enabled=false;

		canvasOtros.GetComponent<Canvas>().enabled=true;
		imagenOtros.sprite=expresionesWisp[0];
		quienHablaOtros.text="Wisp";
		textoOtros.text=variable_Text.wisp_FirstDay1;

        
    }

    void FixedUpdate()
    {
    	animator.SetBool("day3",variablesGeneral.sleepDay3);
		animator.SetBool("day4",variablesGeneral.sleepDay4);
		animator.SetBool("day5",variablesGeneral.sleepDay5);

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

			if(gameObjectRacoonMission[variablesGeneral.num_random].GetComponent<BoxCollider2D>().enabled==true && variablesGeneral.correctBonePicked){
				gameObjectRacoonMission[variablesGeneral.num_random].GetComponent<BoxCollider2D>().enabled=variablesGeneral.correctBonePicked;
			}


		}
    }

//---------------
	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log(coll.gameObject.name);

		objetoTrigger=coll.gameObject;

		if(objetoTrigger.name=="teleportVerde_izq_Dia2" || objetoTrigger.name=="teleportVerde_der_Dia2"
		|| objetoTrigger.name=="teleportVerde_izq_Dia3" || objetoTrigger.name=="teleportVerde_der_Dia3"
		|| objetoTrigger.name=="teleportAzul_top_Dia3" || objetoTrigger.name=="teleportAzul_bottom_Dia3"
		|| objetoTrigger.name=="teleportNaranja_top_Dia3" || objetoTrigger.name=="teleportNaranja_bottom_Dia3"){
			//add more
			teleportRooms();
		}

		if(objetoTrigger.name=="rennie_interactable_Day4" && !variablesGeneral.rennieAppeared){
			rennieApperance();
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		objetoTrigger=null;
	}
//---------------


	//cosas con canvas y botones

	//ocultar
	public void hideCanvas_Ganma(){
		if(!variablesGeneral.startDone){initialConversation();}
		else if(variablesGeneral.awamiKomaMission_WIP==0 && !variablesGeneral.awamiKomaMission_Done){
			if(objetoTrigger.name=="wisp_interactable"){
				canvasGanma.GetComponent<Canvas>().enabled=false;
				gameObjectBotonesMision_Ganma.GetComponent<Canvas>().enabled=false;
				botonesMisionGhoul.GetComponent<Canvas>().enabled=false;
				variablesGeneral.canMove=true;
			}
			else{acceptAwami_KomaMission();}
			//si has aceptado la mision, apretar saca el siguiente dialogo
			
		}
		else if (!variablesGeneral.akaneMission_Done && objetoTrigger!=null){
			if(objetoTrigger.name=="akane_interactable_Day3"){				
				if(variablesGeneral.contar2<6){Mission_Akane();}
				else if(variablesGeneral.contar2==6){
					//fade
					trueFade();

					//para que este por encima del canvas
					Invoke("sortingLayerPositive",0.8f);

					//sacar el post mission
					Invoke("PostAkaneMission",2.8f);
					//3 es demasiado, 2.5 es muy poco
					
					//desfade
					Invoke("falseFade",2f);

					//para que puedas clickar
					Invoke("sortingLayerNegative", 3.2f);
				}
				else{PostAkaneMission();}
			}
			else{
				canvasGanma.GetComponent<Canvas>().enabled=false;
				gameObjectBotonesMision_Ganma.GetComponent<Canvas>().enabled=false;
				variablesGeneral.canMove=true;
				variablesGeneral.contar=0;
				variablesGeneral.contar2=0;
				variablesGeneral.contador2=0;
				variablesGeneral.contarRennie=0;
			}
		}
		else if(variablesGeneral.contarRennie!=0 && variablesGeneral.contarRennie<2){
			if(!variablesGeneral.rennieAppeared){rennieApperance();}
		}
		else if(!variablesGeneral.talkedToPumpkin && variablesGeneral.contarPumpkin!=0){conversacionPumpkin();}
		else if(!variablesGeneral.ghoulMission_WIP && variablesGeneral.contarGhoul!=0 && variablesGeneral.contarGhoul<=2){preMission_Ghoul();}
		else if(objetoTrigger.name=="end_interactable"){goSleep();}
		else if(variablesGeneral.contarGhoul==4 || variablesGeneral.contarGhoul==5){acceptGhoulMission();}
		
		else{
			canvasGanma.GetComponent<Canvas>().enabled=false;
			gameObjectBotonesMision_Ganma.GetComponent<Canvas>().enabled=false;
			botonesMisionGhoul.GetComponent<Canvas>().enabled=false;
			variablesGeneral.canMove=true;
			variablesGeneral.contarRennie=0;
			variablesGeneral.contarHemi=0;
			variablesGeneral.contarWhiskers=0;
			variablesGeneral.contarRacoon=0;
		}
		
	}

	//cuando vas a cerrar el canvas de los otros...
	public void hideCanvas_Otros(){
		
		if(variablesGeneral.contar3==2){variablesGeneral.contar3=0;}

		if(!variablesGeneral.startDone){initialConversation();}
		else{		
			if(variablesGeneral.contador2==1){Mission_Koma_Awami();}
			else if(variablesGeneral.contar<4 && variablesGeneral.contar!=0){//si has aceptado la mision, apretar saca el siguiente dialogo
				acceptAwami_KomaMission();
			}
			else if(variablesGeneral.awamiKomaMission_WIP==1 || variablesGeneral.awamiKomaMission_WIP==2 && !variablesGeneral.awamiKomaMission_Done){
				if(objetoTrigger.name=="awamiHid" || objetoTrigger.name=="komaiHid"){
					//quitar canvas
					canvasOtros.GetComponent<Canvas>().enabled=false;

					//fade
					trueFade();
					

					if(objetoTrigger.gameObject.name=="awamiHid"){
						//quitar el personaje
						
						awamiHidden.SetBool("hidden", false);
					}
					if(objetoTrigger.gameObject.name=="komaiHid"){
						//quitar el personaje
						komaHidden.SetBool("hidden", false);
					}
					
					//desfade
					Invoke("falseFade",2f);

					//si tienes los dos, teletransportas
					Invoke("finalTP_AwamiKoma_Mission",1.5f);
					
					//te puedes mover tras x segundos
					Invoke("canMoveAgain",4f);
				}
				else{closeCanvasOtros();}
				
			}
			else if(objetoTrigger!=null){
				if(objetoTrigger.name=="akane_interactable_Day3" && !variablesGeneral.akaneMission_Done){
					if(variablesGeneral.contar2<6){Mission_Akane();}
					else{PostAkaneMission();}
				}
				else if(objetoTrigger.name=="koma_interactable_Day3"){
					if(variablesGeneral.contar3==1){KomaConversation();}
					else{closeCanvasOtros();}
				}
				else if(objetoTrigger.name=="racoon_interactable_Day3"){
					if(variablesGeneral.contar4==1){Racoon_Initial_Conversation();}
					else if(variablesGeneral.contar4>4 && !variablesGeneral.racoonMission_WIP){acceptRacoonMission();}
					else{closeCanvasOtros();}
				}
				else if(objetoTrigger.name=="rennie_interactable_Day4"){conversacionRennie();}
				else if(objetoTrigger.name=="whiskers_interactable_Day4" && !variablesGeneral.ghoulMission_WIP && variablesGeneral.contarWhiskers!=0){conversacionWhiskers();}//sin mision funciona
				else if(objetoTrigger.name=="hemi_interactable_Day4" && !variablesGeneral.ghoulMission_WIP){conversacionHemi();}
				else if(objetoTrigger.name=="pumpkin_interactable_Day4" && !variablesGeneral.talkedToPumpkin && (variablesGeneral.contarPumpkin!=0 && variablesGeneral.contarPumpkin<2)){conversacionPumpkin();}
				else if(objetoTrigger.name=="racoon_interactable_Day4" && variablesGeneral.contarRacoon!=0){conversacionRacoon_Day4();}
				else if(objetoTrigger.name=="santos_interactable_Day4" && (variablesGeneral.contarSantos!=0 && variablesGeneral.contarSantos<=1) && !variablesGeneral.santosMission_Done){preMission_Santos();}
				else if(objetoTrigger.name=="santos_interactable_Day4" && variablesGeneral.santosMission_WIP && !variablesGeneral.santosMission_Done){
					variablesGeneral.santosMission_Done=true;
					//fade
					trueFade();
					sortingLayerPositive();

					//desfade
					Invoke("falseFade", 0.9f);

					//bajar capa
					Invoke("sortingLayerNegative", 2f);
					
					//sacas el fin de la mision
					Invoke("endMissionSantos", 1.7f);
				}
				else if(objetoTrigger.name=="kiyu_interactable_Day4" && !variablesGeneral.kiyuMission_Done
						&& (
							(!variablesGeneral.ghoulMission_Done && !variablesGeneral.ghoulMission_WIP)  ||
							(variablesGeneral.ghoulMission_Done && variablesGeneral.ghoulMission_WIP)
						)
							){
					
					if(variablesGeneral.contarKiyu<2){preMission_Kiyu();}
					else if(variablesGeneral.contarKiyu==3){//has apretado a aceptar
						//fade
						trueFade();
						sortingLayerPositive();

						//desfade
						Invoke("falseFade", 0.9f);

						//bajar capa
						Invoke("sortingLayerNegative", 2f);
						
						//sacas el fin de la mision
						variablesGeneral.contarKiyu++;

						Invoke("postMissionKiyu", 1.7f);
						
					}
					else if(variablesGeneral.contarKiyu>=4){postMissionKiyu();}
					else{closeCanvasOtros();}
				}
				else if(objetoTrigger.name=="ghoul_interactable_Day4" && !variablesGeneral.ghoulMission_WIP && !variablesGeneral.ghoulMission_Done ){
					if(variablesGeneral.contarGhoul<3 && variablesGeneral.contarGhoul!=0){preMission_Ghoul();}
					else if(variablesGeneral.contarGhoul==4 || variablesGeneral.contarGhoul==5){acceptGhoulMission();}
					else{closeCanvasOtros();}
					
				}

				else{closeCanvasOtros();}
				
			}
						
			else{
				closeCanvasOtros();
			}
		}
		
	}

	void closeCanvasOtros(){
		
		canvasOtros.GetComponent<Canvas>().enabled=false;
		gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;
		gameObjectBotonesMision_Ganma.GetComponent<Canvas>().enabled=false;
		variablesGeneral.canMove=true;

		//reset vars
		variablesGeneral.contar=0;
		variablesGeneral.contar2=0;
		variablesGeneral.contador2=0;
		variablesGeneral.contarGhoul=0;
		variablesGeneral.contarKiyu=0;
		variablesGeneral.contarSantos=0;

		if(variablesGeneral.racoonMission_WIP){variablesGeneral.contar4=2;}
		
		
	}

//---------------
	void trueFade(){fadeAnimation.SetBool("fade", true);}
	void falseFade(){fadeAnimation.SetBool("fade", false);}

	void canMoveAgain(){variablesGeneral.canMove=true;}

	void sortingLayerNegative(){fadeCanvas.sortingOrder=-1;}
	void sortingLayerPositive(){fadeCanvas.sortingOrder=12;}

	void hideCanvasExtra(){canvasExtra.GetComponent<Canvas>().enabled=false;}

//---------

//pre aceptar misiones/cambiar dia

	void rennieApperance(){
		//no te mueves
		variablesGeneral.canMove=false;

		//switch para sacar los 2
		switch(variablesGeneral.contarRennie){
			case 0://primer dialogo
					canvasGanma.GetComponent<Canvas>().enabled=true;
					canvasOtros.GetComponent<Canvas>().enabled=false;

					imagenGanma.sprite=expresionesGanma[11];
					textoGanma.text=variable_Text.ganma_ForthDay_Rennie_1;
					variablesGeneral.contarRennie++;
				break;

			case 1://segundo
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[12];
				textoGanma.text=variable_Text.ganma_ForthDay_Rennie_2;
				variablesGeneral.rennieAppeared=true;
				rennieObjeto.SetBool("found",true);
				variablesGeneral.contarRennie++;
				
				break;
		}
	}

	void conversacionRennie (){
		switch(variablesGeneral.contarRennie){
			case 0:
				canvasOtros.GetComponent<Canvas>().enabled=true;
				canvasGanma.GetComponent<Canvas>().enabled=false;

				quienHablaOtros.text="Rennie";
				imagenOtros.sprite=expresionesRennie[0];
				textoOtros.text=variable_Text.rennie_ForthDay_1;
				variablesGeneral.contarRennie++;
				
				break;
				
			case 1:
				canvasOtros.GetComponent<Canvas>().enabled=false;
				canvasGanma.GetComponent<Canvas>().enabled=true;

				imagenGanma.sprite=expresionesGanma[13];
				textoGanma.text=variable_Text.ganma_ForthDay_Rennie_3;
				canvasColorGanma.sprite=canvasAzul;
				variablesGeneral.contarRennie++;
				break;

		}
	}
	
	void conversacionWhiskers(){
		switch(variablesGeneral.contarWhiskers){
			case 0:
				canvasOtros.GetComponent<Canvas>().enabled=true;
				canvasGanma.GetComponent<Canvas>().enabled=false;

				quienHablaOtros.text="Whiskers";
				imagenOtros.sprite=expresionesWhiskers[0];
				textoOtros.text=variable_Text.whiskers_ForthDay_1;
				variablesGeneral.contarWhiskers++;
				break;
				
			case 1:
				canvasOtros.GetComponent<Canvas>().enabled=false;
				canvasGanma.GetComponent<Canvas>().enabled=true;

				imagenGanma.sprite=expresionesGanma[14];
				textoGanma.text=variable_Text.ganma_ForthDay_Whiskers;
				variablesGeneral.contarWhiskers++;
				break;

		}
	}

	void conversacionHemi(){
		switch(variablesGeneral.contarHemi){
			case 0:
				canvasOtros.GetComponent<Canvas>().enabled=true;
				canvasGanma.GetComponent<Canvas>().enabled=false;

				quienHablaOtros.text="Hemi";
				imagenOtros.sprite=expresionesHemi[0];
				textoOtros.text=variable_Text.hemi_ForthDay_1;
				variablesGeneral.contarHemi++;
				
				break;

			case 1:
				canvasOtros.GetComponent<Canvas>().enabled=true;
				canvasGanma.GetComponent<Canvas>().enabled=false;

				quienHablaOtros.text="Hemi";
				imagenOtros.sprite=expresionesHemi[1];
				textoOtros.text=variable_Text.hemi_ForthDay_2;
				variablesGeneral.contarHemi++;
				
				break;
				
			case 2:
				canvasOtros.GetComponent<Canvas>().enabled=false;
				canvasGanma.GetComponent<Canvas>().enabled=true;

				imagenGanma.sprite=expresionesGanma[4];
				textoGanma.text=variable_Text.ganma_ForthDay_Hemi;
				canvasColorGanma.sprite=canvasAzul;
				break;

		}
	}

	void conversacionPumpkin (){
		switch(variablesGeneral.contarPumpkin){
			case 0:
				canvasOtros.GetComponent<Canvas>().enabled=true;
				canvasGanma.GetComponent<Canvas>().enabled=false;

				quienHablaOtros.text="Pumpkin";
				imagenOtros.sprite=expresionesPumpkin[0];
				textoOtros.text=variable_Text.pumpkin_ForthDay_1;
				variablesGeneral.contarPumpkin++;
				
				break;

			case 1:
				
				canvasOtros.GetComponent<Canvas>().enabled=false;
				canvasGanma.GetComponent<Canvas>().enabled=true;

				imagenGanma.sprite=expresionesGanma[9];
				textoGanma.text=variable_Text.ganma_ForthDay_Pumpkin;
				variablesGeneral.contarPumpkin++;
				
				break;
				
			case 2:
				canvasOtros.GetComponent<Canvas>().enabled=true;
				canvasGanma.GetComponent<Canvas>().enabled=false;

				quienHablaOtros.text="Pumpkin";
				imagenOtros.sprite=expresionesPumpkin[1];
				textoOtros.text=variable_Text.pumpkin_ForthDay_2;
				variablesGeneral.talkedToPumpkin=true;
				variablesGeneral.contarPumpkin++;
				break;

		}
	}

	void conversacionRacoon_Day4 (){
		switch(variablesGeneral.contarRacoon){
			case 0:
				canvasOtros.GetComponent<Canvas>().enabled=true;
				canvasGanma.GetComponent<Canvas>().enabled=false;

				quienHablaOtros.text="Racoon";
				imagenOtros.sprite=expresionesRacoon[1];
				textoOtros.text=variable_Text.racoon_ForthDay;
				variablesGeneral.contarRacoon++;
				break;
				
			case 1:
				canvasOtros.GetComponent<Canvas>().enabled=false;
				canvasGanma.GetComponent<Canvas>().enabled=true;

				imagenGanma.sprite=expresionesGanma[10];
				textoGanma.text=variable_Text.ganma_ForthDay_Racoon;
				variablesGeneral.contarRacoon++;
				break;

		}
	}
	
	public void goSleep_Question(){
		
		//cambias cosas
		imagenOtros.sprite=expresionesWisp[7];
		quienHablaOtros.text="Wisp";
		textoOtros.text=variable_Text.passDay_normal;
		
		canvasOtros.GetComponent<Canvas>().enabled=true;//sacas el canvas
		gameObjectBotonesMision.GetComponent<Canvas>().enabled=true;
	}
	public void goSleep_Question_NoWisp(){
		
		//cambias cosas
		quienHablaOtros.text="";
		imagenOtros.sprite=transparente;
		textoOtros.text=variable_Text.passDay_noWisp;
		
		canvasOtros.GetComponent<Canvas>().enabled=true;//sacas el canvas
		gameObjectBotonesMision.GetComponent<Canvas>().enabled=true;
	}
	public void goSleep_Question_FinalDay(){
		
		canvasOtros.sortingOrder=-1;
		//cambias cosas
		quienHablaOtros.text="";
		textoOtros.text=variable_Text.passDay_noWisp;

		canvasOtros.GetComponent<Canvas>().enabled=true;//sacas el canvas
		gameObjectBotonesMision_Ganma.GetComponent<Canvas>().enabled=true;
	}

	public void thingsToDo_Question(){
		imagenGanma.sprite=expresionesGanma[27];
		textoGanma.text=variable_Text.passDay_MissionWIP;
		
		canvasGanma.GetComponent<Canvas>().enabled=true;//sacas el canvas
		canvasColorGanma.sprite=canvasAzul;
		gameObjectBotonesMision_Ganma.GetComponent<Canvas>().enabled=true;
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

	public void Mission_Akane(){
		switch(variablesGeneral.contar2){
			case 0:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[19];
				textoGanma.text=variable_Text.ganma_ThirdDay_PreAkaneMission_1;
				variablesGeneral.contar2++;
				break;

			case 1:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Akane";
				imagenOtros.sprite=expresionesAkane[4];
				textoOtros.text=variable_Text.akane_ThirdDay_PreMission_1;
				variablesGeneral.contar2++;
				break;

			case 2:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[20];
				textoGanma.text=variable_Text.ganma_ThirdDay_PreAkaneMission_2;
				variablesGeneral.contar2++;
				break;

			case 3:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Akane";
				imagenOtros.sprite=expresionesAkane[5];
				textoOtros.text=variable_Text.akane_ThirdDay_PreMission_2;
				variablesGeneral.contar2++;
				break;

			case 4:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Akane";
				imagenOtros.sprite=expresionesAkane[6];
				textoOtros.text=variable_Text.akane_ThirdDay_PreMission_3;
				variablesGeneral.contar2++;
				break;

			case 5:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[21];
				textoGanma.text=variable_Text.ganma_ThirdDay_PreAkaneMission_3;
				variablesGeneral.contar2++;

				break;
		}
	}

	public void KomaConversation(){
		switch(variablesGeneral.contar3){
			case 0:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				imagenOtros.sprite=expresionesKoma[6];
				quienHablaOtros.text="Koma";
				textoOtros.text=variable_Text.koma_ThirdDay_1;
				variablesGeneral.contar3+=1;
				break;

			case 1:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				imagenOtros.sprite=expresionesKoma[7];
				quienHablaOtros.text="Koma";
				textoOtros.text=variable_Text.koma_ThirdDay_2;
				variablesGeneral.contar3+=1;
				break;
		}
	}

	public void Racoon_Initial_Conversation(){
		switch(variablesGeneral.contar4){
			case 0:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				imagenOtros.sprite=expresionesRacoon[2];
				quienHablaOtros.text="Racoon";
				textoOtros.text=variable_Text.racoon_ThirdDay_1;
				variablesGeneral.contar4+=1;
				break;

			case 1:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				imagenOtros.sprite=expresionesRacoon[3];
				quienHablaOtros.text="Racoon";
				textoOtros.text=variable_Text.racoon_ThirdDay_2;
				variablesGeneral.contar4+=1;
				variablesGeneral.talkedToRacoon=true;
				variablesGeneral.contar4++;
				break;
		}
	}

	public void preMission_Santos(){
		switch(variablesGeneral.contarSantos){
			case 0:
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Santos";
				imagenOtros.sprite=expresionesSantos[1];
				textoOtros.text=variable_Text.santos_ForthDay_PreMission_1;
				variablesGeneral.contarSantos++;
				break;

			case 1:
				gameObjectBotonesMision.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Santos";
				imagenOtros.sprite=expresionesSantos[2];
				textoOtros.text=variable_Text.santos_ForthDay_PreMission_2;
				variablesGeneral.contarSantos++;
				break;
		}
	}

	public void preMission_Kiyu(){
		switch(variablesGeneral.contarKiyu){
			case 0:
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Kiyu";
				imagenOtros.sprite=expresionesKiyu[6];
				textoOtros.text=variable_Text.kiyu_ForthDay_PreMission_1;
				variablesGeneral.contarKiyu++;
				break;

			case 1:
				gameObjectBotonesMision.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Kiyu";
				imagenOtros.sprite=expresionesKiyu[7];
				textoOtros.text=variable_Text.kiyu_ForthDay_PreMission_2;
				variablesGeneral.contarKiyu++;
				break;
		}
	}

	public void preMission_Ghoul(){
		switch (variablesGeneral.contarGhoul){
			case 0:
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Ghoul";
				imagenOtros.sprite=expresionesGhoul[4];
				textoOtros.text=variable_Text.ghoul_ForthDay_PreMission_1;
				variablesGeneral.contarGhoul++;
				break;

			case 1:
				canvasOtros.GetComponent<Canvas>().enabled=false;
				canvasGanma.GetComponent<Canvas>().enabled=true;


				imagenGanma.sprite=expresionesGanma[7];
				textoGanma.text=variable_Text.ganma_ForthDay_PreMission_Ghoul_1;
				variablesGeneral.contarGhoul++;
				break;

			case 2:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;
				gameObjectBotonesMision.GetComponent<Canvas>().enabled=true;
				textoBotonAceptar.text="I can try to help...";
				textoBotonDeny.text="I'm sorry";

				quienHablaOtros.text="Ghoul";
				imagenOtros.sprite=expresionesGhoul[5];
				textoOtros.text=variable_Text.ghoul_ForthDay_PreMission_2;
				variablesGeneral.contarGhoul++;
				break;
		}
	}
	

	//esto es del boton de aceptar
	public void decideFate(){//aceptas misiones
		if(variablesGeneral.spriteTocado=="wisp_interactable"){goSleep();}
		if(variablesGeneral.spriteTocado=="awami_koma_interactable"){acceptAwami_KomaMission();}
		if(variablesGeneral.spriteTocado=="racoon_interactable_Day3"){
			variablesGeneral.contar4+=1;
			acceptRacoonMission();
		}
		if(variablesGeneral.spriteTocado=="santos_interactable_Day4"){acceptSantosMission();}
		if(variablesGeneral.spriteTocado=="kiyu_interactable_Day4"){acceptKiyuMission();}
		if(variablesGeneral.spriteTocado=="ghoul_interactable_Day4"){
			variablesGeneral.contarGhoul++;
			acceptGhoulMission();
		}
		if(variablesGeneral.spriteTocado=="end_interactable"){goSleep_Finale();}
		else{
			variablesGeneral.contador2=0;
			variablesGeneral.contar=0;
			if(variablesGeneral.racoonMission_WIP){variablesGeneral.contar4=2;}
			
		}
	}

	//aceptas
	public void goSleep(){//hacer la accion
		//fade
		trueFade();
		//tras un segundo
		Invoke("falseFade",1f);

		Invoke("teleportDays",1.5f);
	
		//ocultas
		gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;
		canvasOtros.GetComponent<Canvas>().enabled=false;

		gameObjectBotonesMision_Ganma.GetComponent<Canvas>().enabled=false;
		canvasGanma.GetComponent<Canvas>().enabled=false;

		variablesGeneral.canMove=true;
	}

	public void goSleep_Finale(){//hacer la accion
		gameObjectBotonesMision_Ganma.GetComponent<Canvas>().enabled=false;
		canvasGanma.GetComponent<Canvas>().enabled=true;
		canvasOtros.GetComponent<Canvas>().enabled=false;

		imagenGanma.sprite=expresionesGanma[26];
		textoGanma.text=variable_Text.passDay_lastDay;
	}

	void acceptAwami_KomaMission(){
		variablesGeneral.awamiKomaMission_WIPBool=true;
		gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;

		switch(variablesGeneral.contar){
				case 0:
					canvasGanma.GetComponent<Canvas>().enabled=true;
					canvasOtros.GetComponent<Canvas>().enabled=false;

					imagenGanma.sprite=expresionesGanma[24];
					textoGanma.text=variable_Text.ganmaMissionResponse_1_Ok;
					variablesGeneral.contar+=1;
					break;

				case 1:
					canvasGanma.GetComponent<Canvas>().enabled=false;
					canvasOtros.GetComponent<Canvas>().enabled=true;

					quienHablaOtros.text="Awami";
					imagenOtros.sprite=expresionesAwami[5];
					textoOtros.text=variable_Text.awami_SecondDay_PreMission_2;
					variablesGeneral.contar+=1;
					
					break;

				case 2:
					canvasGanma.GetComponent<Canvas>().enabled=false;
					canvasOtros.GetComponent<Canvas>().enabled=true;

					quienHablaOtros.text="Koma";
					imagenOtros.sprite=expresionesKoma[5];
					textoOtros.text=variable_Text.koma_SecondDay_PreMission_2;
					variablesGeneral.contar+=1;
					break;
				
				case 3:
					//fade
					trueFade();
					//quita los canvas
					canvasGanma.GetComponent<Canvas>().enabled=false;
					canvasOtros.GetComponent<Canvas>().enabled=false;

					//pon los personajes en el otro sitio
					komaHidden.SetBool("hidden", true);
					awamiHidden.SetBool("hidden", true);

					//oculta el original
					komaAwami_Mission_Object.SetActive(false);

					//desfade
					Invoke("falseFade", 1f);

					//te puedes mover
					variablesGeneral.canMove=true;
					variablesGeneral.contar+=1;
					break;
			}		
	}

	void acceptRacoonMission(){
		gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;

		switch(variablesGeneral.contar4){
			case 4:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				imagenOtros.sprite=expresionesRacoon[6];
				quienHablaOtros.text="Racoon";
				textoOtros.text=variable_Text.racoon_ThirdDay_PreMission_2;
				variablesGeneral.contar4+=1;

				
				break;

			case 5:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[22];
				textoGanma.text=variable_Text.ganma_ThirdDay_PreRacoonMission;
				canvasColorGanma.sprite=canvasAzul;
				elementsRacoonMission();			
				break;
		}

	}

	void elementsRacoonMission(){
		variablesGeneral.num_random=random.Next(1,gameObjectRacoonMission.Length);
		//numero random como tamaño max el numero de elementos en la array

		for(int contador=0;contador<gameObjectRacoonMission.Length;contador++){
			gameObjectRacoonMission[contador].GetComponent<BoxCollider2D>().enabled=false;
		}
		
		//solo activas ese
		gameObjectRacoonMission[variablesGeneral.num_random].GetComponent<BoxCollider2D>().enabled=true;

		variablesGeneral.racoonMission_WIP=true;

	}

	void acceptSantosMission(){
		gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;

		canvasOtros.GetComponent<Canvas>().enabled=true;

		quienHablaOtros.text="Santos";
		imagenOtros.sprite=expresionesSantos[3];
		textoOtros.text=variable_Text.santos_ForthDay_PreMission_3;
		variablesGeneral.santosMission_WIP=true;
	}

	void acceptKiyuMission(){
		gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;

		canvasOtros.GetComponent<Canvas>().enabled=true;

		quienHablaOtros.text="Kiyu";
		imagenOtros.sprite=expresionesKiyu[2];
		textoOtros.text=variable_Text.kiyu_ForthDay_Mission_3;
		variablesGeneral.contarKiyu++;
	}

	void acceptGhoulMission(){
		switch (variablesGeneral.contarGhoul) 
		{
			case 4:
				canvasOtros.GetComponent<Canvas>().enabled=false;
				canvasGanma.GetComponent<Canvas>().enabled=true;
				gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[8];
				textoGanma.text=variable_Text.ganma_ForthDay_PreMission_Ghoul_2;
				variablesGeneral.contarGhoul++;
				break;

			case 5:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;
				textoBotonAceptar.text="I can try to help...";
				textoBotonDeny.text="I'm sorry";

				quienHablaOtros.text="Ghoul";
				imagenOtros.sprite=expresionesGhoul[6];
				textoOtros.text=variable_Text.ghoul_ForthDay_PreMission_3;
				variablesGeneral.ghoulMission_WIP=true;
				break;
		}
	}
	

//final extra de las misiones (aparece algo, haces tp...)
	void finalTP_AwamiKoma_Mission(){
		if(variablesGeneral.awamiKomaMission_WIP==2){
			transform.position=new Vector3(finalAwamiKomaMission.position.x,finalAwamiKomaMission.position.y,0);//teleport
			komaAwami_Mission_Object.SetActive(true);
			variablesGeneral.awamiKomaMission_Done=true;
			variablesGeneral.awamiKomaMission_WIP+=1;
		}
		else{return;}
	}
	
	void PostAkaneMission(){
		switch(variablesGeneral.contar2){
			case 6:
				fadeCanvas.sortingOrder=-1;
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Akane";
				imagenOtros.sprite=expresionesAkane[1];
				textoOtros.text=variable_Text.akane_ThirdDay_PostMission_1;
				variablesGeneral.contar2++;
				break;

			case 7:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[15];
				textoGanma.text=variable_Text.ganma_ThirdDay_PostAkaneMission_1;
				variablesGeneral.contar2++;
				break;

			case 8:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Akane";
				imagenOtros.sprite=expresionesAkane[2];
				textoOtros.text=variable_Text.akane_ThirdDay_PostMission_2;
				variablesGeneral.contar2++;
				break;

			case 9:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[16];
				textoGanma.text=variable_Text.ganma_ThirdDay_PostAkaneMission_2;
				variablesGeneral.contar2++;
				break;

			case 10:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[17];
				textoGanma.text=variable_Text.ganma_ThirdDay_PostAkaneMission_3;
				canvasColorGanma.sprite=canvasAzul;
				variablesGeneral.contar2++;
				break;

			case 11:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[18];
				textoGanma.text=variable_Text.ganma_ThirdDay_PostAkaneMission_4;
				canvasColorGanma.sprite=canvasAzul;
				variablesGeneral.akaneMission_Done=true;
				break;
		}
	}

	void endMissionSantos(){
		canvasOtros.GetComponent<Canvas>().enabled=true;

		quienHablaOtros.text="Santos";
		imagenOtros.sprite=expresionesSantos[0];
		textoOtros.text=variable_Text.santos_ForthDay_PostMission_4;
	}

	void postMissionKiyu(){
		switch(variablesGeneral.contarKiyu){
			case 4:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Kiyu";
				imagenOtros.sprite=expresionesKiyu[4];
				textoOtros.text=variable_Text.kiyu_ForthDay_PostMission_4;
				variablesGeneral.contarKiyu++;
				break;

			case 5:
				canvasOtros.GetComponent<Canvas>().enabled=false;
				canvasGanma.GetComponent<Canvas>().enabled=true;

				imagenGanma.sprite=expresionesGanma[6];
				textoGanma.text=variable_Text.ganma_ForthDay_PostMission_Kiyu;
				variablesGeneral.kiyuMission_Done=true;
				variablesGeneral.contarKiyu++;
				break;
		}		
	}

	void finishGhoulMission(){//esto saca solo los botones de las plumas cogidas, el que aprete a una u otra es en otro

		//oculta las que no ha cogido
		if(!variablesGeneral.pumpkinFeatherPicked){botonPumpkin.gameObject.SetActive(false);}
		else{botonPumpkin.gameObject.SetActive(true);}

		if(!variablesGeneral.kiyuFeatherPicked){botonKiyu.gameObject.SetActive(false);}
		else{botonKiyu.gameObject.SetActive(true);}

		if(!variablesGeneral.whiskersFeatherPicked){botonWhiskers.gameObject.SetActive(false);}
		else{botonWhiskers.gameObject.SetActive(true);}

		//sacas el texto
		imagenGanma.sprite=expresionesGanma[29];
		textoGanma.text=variable_Text.giveFeater;
		canvasColorGanma.sprite=canvasAzul;

		//sacas los botones y el canvas

		botonesMisionGhoul.GetComponent<Canvas>().enabled=true;
		canvasGanma.GetComponent<Canvas>().enabled=true;

	}

//--------------------
	public void PumpkinsFeatherPick(){
		botonesMisionGhoul.GetComponent<Canvas>().enabled=false;
		canvasGanma.GetComponent<Canvas>().enabled=false;
		canvasOtros.GetComponent<Canvas>().enabled=true;

		quienHablaOtros.text="Ghoul";
		imagenOtros.sprite=expresionesGhoul[1];
		textoOtros.text=variable_Text.ghoul_ForthDay_Mission_Pumpkin;
		variablesGeneral.ghoulMission_Done=true;
	}

	public void KiyuFeatherPick(){
		botonesMisionGhoul.GetComponent<Canvas>().enabled=false;
		canvasGanma.GetComponent<Canvas>().enabled=false;
		canvasOtros.GetComponent<Canvas>().enabled=true;

		quienHablaOtros.text="Ghoul";
		imagenOtros.sprite=expresionesGhoul[0];
		textoOtros.text=variable_Text.ghoul_ForthDay_Mission_Kiyu;
		variablesGeneral.ghoulMission_Done=true;
	}

	public void WhiskersFeatherPick(){
		botonesMisionGhoul.GetComponent<Canvas>().enabled=false;
		canvasGanma.GetComponent<Canvas>().enabled=false;
		canvasOtros.GetComponent<Canvas>().enabled=true;

		quienHablaOtros.text="Ghoul";
		imagenOtros.sprite=expresionesGhoul[2];
		textoOtros.text=variable_Text.ghoul_ForthDay_Mission_Whiskers;
		variablesGeneral.ghoulMission_Done=true;
	}
//----------------
	public void interactable(){
		variablesGeneral.canMove=false;

		//pillas el nombre de lo que tocas
		variablesGeneral.spriteTocado=objetoTrigger.name;

		//entonces decides las cosas
		if(variablesGeneral.spriteTocado=="bordes"){
			borderInteraction();
		}
		else{
			decideText();
		}
		
	}
	void borderInteraction(){
		//sacas el canvas
		canvasExtra.GetComponent<Canvas>().enabled=true;

		//random si sacas una u otra
		variablesGeneral.num_random=random.Next(0,50);

		//pones la imagen
		if(variablesGeneral.num_random==14 && 
			(!variablesGeneral.jumpscareShown
			&& !variablesGeneral.sleepDay4 && !variablesGeneral.sleepDay5)){
				//no ha salido antes
				//no es el dia 4 ni 5
			//musica ominosa con susto idk
			imagenCanvasExtra.sprite=imagenesExtra[1];
			variablesGeneral.jumpscareShown=true;//para que solo pueda salir una vez
		}
		else{
			//musica ominosa o algo
			imagenCanvasExtra.sprite=imagenesExtra[0];
		}

		

		//al cabo de unos segundos desaparece
		Invoke("hideCanvasExtra",2f);

		//te puedes mover
		Invoke("canMoveAgain",2.5f);
		
	}

	void decideText(){//esto SOLO saca texto

		canvasColorGanma.sprite=canvasNaranja;
		textoBotonAceptar.text="Accept";
		textoBotonDeny.text="Deny";
		imagenOtros.sprite=transparente;

		 if(variablesGeneral.spriteTocado=="wisp_interactable"){
		 	
		 	if(variablesGeneral.sleepDay4){goSleep_Question_NoWisp();}
		 	else if(variablesGeneral.sleepDay4 && variablesGeneral.ghoulMission_WIP){thingsToDo_Question();}
		 	else if(variablesGeneral.sleepDay3 && variablesGeneral.racoonMission_WIP){thingsToDo_Question();}
		 	else if(variablesGeneral.awamiKomaMission_WIPBool && !variablesGeneral.awamiKomaMission_Done){thingsToDo_Question();}
		 	else{goSleep_Question();}
		 }
		 if(variablesGeneral.spriteTocado=="bed_interactable"){endChapter();}

		//dia 1
		 if(variablesGeneral.spriteTocado=="kiyu_interactable_Day1"){
			 quienHablaOtros.text="Kiyu";
			 imagenOtros.sprite=expresionesKiyu[1];
			 textoOtros.text=variable_Text.kiyu_FirstDay;
			 canvasOtros.GetComponent<Canvas>().enabled=true;
		 }
		 if(variablesGeneral.spriteTocado=="akane_interactable_Day1"){
			 quienHablaOtros.text="Akane";
			 imagenOtros.sprite=expresionesAkane[7];
			 textoOtros.text=variable_Text.akane_FirstDay;
			 canvasOtros.GetComponent<Canvas>().enabled=true;
		 }
		 if(variablesGeneral.spriteTocado=="koma_interactable_Day1"){
			 quienHablaOtros.text="Koma";
			 imagenOtros.sprite=expresionesKoma[0];
			 textoOtros.text=variable_Text.koma_FirstDay;
			 canvasOtros.GetComponent<Canvas>().enabled=true;
		 }
		 if(variablesGeneral.spriteTocado=="awami_interactable_Day1"){
			 quienHablaOtros.text="Awami";
			 imagenOtros.sprite=expresionesAwami[0];
			 textoOtros.text=variable_Text.awami_FirstDay;
			 canvasOtros.GetComponent<Canvas>().enabled=true;
		 }

//------------------
		 //dia2
		 if(variablesGeneral.spriteTocado=="awami_koma_interactable"){
			 if(variablesGeneral.awamiKomaMission_Done){
				 variablesGeneral.contar=0;
				 //numero random
					
					int num_random=random.Next(0,6);

				 if(num_random%2==0){
					 quienHablaOtros.text="Awami";
					 imagenOtros.sprite=expresionesAwami[3];
			 		 textoOtros.text=variable_Text.awami_SecondDay_PostMission_Interaction;
			 		 canvasOtros.GetComponent<Canvas>().enabled=true;
				 }
				 else{
					  quienHablaOtros.text="Koma";
					 imagenOtros.sprite=expresionesKoma[3];
			 		 textoOtros.text=variable_Text.koma_SecondDay_PostMission_Interaction;
			 		 canvasOtros.GetComponent<Canvas>().enabled=true;
				 }
				 
			 }
			 else{Mission_Koma_Awami();}
			  
		 }
		 if(variablesGeneral.spriteTocado=="kiyu_Akane_interactable"){
			 quienHablaOtros.text="Kiyu";
			 imagenOtros.sprite=expresionesKiyu[8];
			 textoOtros.text=variable_Text.kiyu_SecondDay;
			 canvasOtros.GetComponent<Canvas>().enabled=true;
		 }

		 if(variablesGeneral.spriteTocado=="awamiHid"){
			 if(variablesGeneral.awamiKomaMission_WIP>=0 && !variablesGeneral.awamiKomaMission_Done){
				 quienHablaOtros.text="Awami";
			 	imagenOtros.sprite=expresionesAwami[2];
			 	textoOtros.text=variable_Text.awami_SecondDay_Mission;
			 	canvasOtros.GetComponent<Canvas>().enabled=true;
			 	variablesGeneral.awamiKomaMission_WIP+=1;
			 }
			 else{variablesGeneral.canMove=true;}
		 }
		 if(variablesGeneral.spriteTocado=="komaiHid"){
			 
			 if(variablesGeneral.awamiKomaMission_WIP>=0 && !variablesGeneral.awamiKomaMission_Done){
				 quienHablaOtros.text="Koma";
			 	imagenOtros.sprite=expresionesKoma[2];
			 	textoOtros.text=variable_Text.koma_SecondDay_Mission;
			 	canvasOtros.GetComponent<Canvas>().enabled=true;
			 	variablesGeneral.awamiKomaMission_WIP+=1;
			 }
			  else{variablesGeneral.canMove=true;}
		 }

//------------------
		//dia3

		 if(variablesGeneral.spriteTocado=="kiyu_interactable_Day3"){
			imagenGanma.sprite=expresionesGanma[25];
			textoGanma.text=variable_Text.kiyu_ThirdDay;
			canvasGanma.GetComponent<Canvas>().enabled=true;
			canvasColorGanma.sprite=canvasAzul;
		 }

		 if(variablesGeneral.spriteTocado=="santos_interactable_Day3"){
			quienHablaOtros.text="Santos";
			imagenOtros.sprite=expresionesSantos[4];
			textoOtros.text=variable_Text.santos_ThirdDay;
			canvasOtros.GetComponent<Canvas>().enabled=true;
		 }
		 if(variablesGeneral.spriteTocado=="koma_interactable_Day3"){KomaConversation();}

		 if(variablesGeneral.spriteTocado=="akane_interactable_Day3"){
			 if(variablesGeneral.akaneMission_Done){
				quienHablaOtros.text="Akane";
				imagenOtros.sprite=expresionesAkane[3];
				textoOtros.text=variable_Text.akane_ThirdDay_PostMission_Interaction;
				canvasOtros.GetComponent<Canvas>().enabled=true;
			 }
			 else{Mission_Akane();}
			 
		  }

		 if(variablesGeneral.spriteTocado=="awami_interactable_Day3"){
			quienHablaOtros.text="Awami";
			imagenOtros.sprite=expresionesAwami[6];
			textoOtros.text=variable_Text.awami_ThirdDay;
			canvasOtros.GetComponent<Canvas>().enabled=true;
		 }

		 if(variablesGeneral.spriteTocado=="racoon_interactable_Day3"){
		 	
		 	if(!variablesGeneral.talkedToRacoon){Racoon_Initial_Conversation();}
			else if(variablesGeneral.contar4==3 && !variablesGeneral.racoonMission_WIP){//hablas de nuevo tras interactuar por primera vez
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;
				gameObjectBotonesMision.GetComponent<Canvas>().enabled=true;

				imagenOtros.sprite=expresionesRacoon[5];
				quienHablaOtros.text="Racoon";
				textoOtros.text=variable_Text.racoon_ThirdDay_PreMission_1;
			}

			else if(variablesGeneral.racoonMission_WIP && !variablesGeneral.racoonMission_Done){//has iniciado la mision y hablas con ella
				quienHablaOtros.text="Racoon";
				canvasOtros.GetComponent<Canvas>().enabled=true;

				if(variablesGeneral.correctBonePicked && !variablesGeneral.racoonMission_Done){
					//has pillado el correcto
					imagenOtros.sprite=expresionesRacoon[3];
					textoOtros.text=variable_Text.racoon_ThirdDay_PostMission;
					variablesGeneral.racoonMission_Done=true;
				}
				else{
					//simplemente vuelves a hablar
					imagenOtros.sprite=expresionesRacoon[6];
					textoOtros.text=variable_Text.racoon_ThirdDay_PreMission_2;
				}
			}
			else if(variablesGeneral.racoonMission_Done){
				quienHablaOtros.text="Racoon";
				imagenOtros.sprite=expresionesRacoon[4];
				textoOtros.text=variable_Text.racoon_ThirdDay_PostMission_Interaction;
				canvasOtros.GetComponent<Canvas>().enabled=true;
			}
		 	
		 }

		 if(variablesGeneral.spriteTocado=="hueso_mission"){

			 if(variablesGeneral.racoonMission_WIP && !variablesGeneral.correctBonePicked){
				 //estas con la mision y no has pillado el hueso antes (sino lo puedes pillar multiples veces)
				imagenGanma.sprite=expresionesGanma[23];
				textoGanma.text=variable_Text.ganma_ThirdDay_RacoonMission_1;
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasColorGanma.sprite=canvasNaranja;
				variablesGeneral.correctBonePicked=true;


			 }
			 else{variablesGeneral.canMove=true;}
			
		 }
//------------------
		//dia4

		if(variablesGeneral.spriteTocado=="awamiAkaneKoma_interactable"){
			variablesGeneral.num_random=random.Next(1,4);//random del 1 al 3

			if(variablesGeneral.num_random==1){
				quienHablaOtros.text="Awami";
				imagenOtros.sprite=expresionesAwami[1];
				textoOtros.text=variable_Text.awami_ForthDay;
				canvasOtros.GetComponent<Canvas>().enabled=true;
			}
			else if(variablesGeneral.num_random==2){
				quienHablaOtros.text="Akane";
				imagenOtros.sprite=expresionesAkane[0];
				textoOtros.text=variable_Text.akane_ForthDay;
				canvasOtros.GetComponent<Canvas>().enabled=true;
			}
			else if(variablesGeneral.num_random==3){
				quienHablaOtros.text="Koma";
				imagenOtros.sprite=expresionesKoma[1];
				textoOtros.text=variable_Text.koma_ForthDay;
				canvasOtros.GetComponent<Canvas>().enabled=true;
			}
		}

		if(variablesGeneral.spriteTocado=="pure_interactable_Day4"){
			quienHablaOtros.text="Pure";
			imagenOtros.sprite=expresionesPure[0];
			textoOtros.text=variable_Text.pure_ForthDay;
			canvasOtros.GetComponent<Canvas>().enabled=true;
		}
		if(variablesGeneral.spriteTocado=="bounce_interactable_Day4"){
			if(variablesGeneral.ghoulMission_WIP && !variablesGeneral.ghoulMission_Done){
				quienHablaOtros.text="Bounce";
				imagenOtros.sprite=expresionesBounce[1];
				textoOtros.text=variable_Text.bounce_ForthDay_Mission_Ghoul;
				canvasOtros.GetComponent<Canvas>().enabled=true;
			}
			else{
				quienHablaOtros.text="Bounce";
				imagenOtros.sprite=expresionesBounce[0];
				textoOtros.text=variable_Text.bounce_ForthDay;
				canvasOtros.GetComponent<Canvas>().enabled=true;
			}
			
		}
		if(variablesGeneral.spriteTocado=="skyan_interactable_Day4"){
			quienHablaOtros.text="Skyan";
			imagenOtros.sprite=expresionesSkyan[0];
			textoOtros.text=variable_Text.skyan_ForthDay_Interaction;
			canvasOtros.GetComponent<Canvas>().enabled=true;
		}

		if(variablesGeneral.spriteTocado=="rennie_interactable_Day4"){conversacionRennie();}
		if(objetoTrigger.name=="whiskers_interactable_Day4"){
			if(variablesGeneral.ghoulMission_WIP && !variablesGeneral.whiskersFeatherPicked){//to test
			//mision, no pillaste pluma
				quienHablaOtros.text="Whiskers";
				imagenOtros.sprite=expresionesWhiskers[1];
				textoOtros.text=variable_Text.whiskers_ForthDay_Mission_Ghoul;
				canvasOtros.GetComponent<Canvas>().enabled=true;
				variablesGeneral.whiskersFeatherPicked=true;
			}

			else if(variablesGeneral.ghoulMission_WIP && !variablesGeneral.ghoulMission_Done && variablesGeneral.whiskersFeatherPicked){//to test
			//mision, pillaste pluma y sigues en la mision
				imagenGanma.sprite=expresionesGanma[5];
				textoGanma.text=variable_Text.ganma_ForthDay_Mission_Ghoul_GetFeather;
				canvasGanma.GetComponent<Canvas>().enabled=true;
			}
			else{conversacionWhiskers();}//no mision, hablas normal
			
		}
		if(variablesGeneral.spriteTocado=="hemi_interactable_Day4"){
			if(variablesGeneral.ghoulMission_WIP && !variablesGeneral.ghoulMission_Done){//to test
			//mision sin acabar
				imagenGanma.sprite=expresionesGanma[28];
				textoGanma.text=variable_Text.hemi_ForthDay_Mission_Ghoul;
				canvasGanma.GetComponent<Canvas>().enabled=true;
			}
			else{conversacionHemi();}//no mision, hablas normal
			 
		}

		if(objetoTrigger.name=="pumpkin_interactable_Day4"){

			
			if(variablesGeneral.ghoulMission_WIP && !variablesGeneral.pumpkinFeatherPicked && !variablesGeneral.ghoulMission_Done){
			//mision, no pillaste pluma
				quienHablaOtros.text="Pumpkin";
				imagenOtros.sprite=expresionesPumpkin[3];
				textoOtros.text=variable_Text.pumpkin_ForthDay_Mission_Ghoul;
				canvasOtros.GetComponent<Canvas>().enabled=true;
				variablesGeneral.pumpkinFeatherPicked=true;
			}
			else if(variablesGeneral.ghoulMission_WIP && !variablesGeneral.ghoulMission_Done && variablesGeneral.pumpkinFeatherPicked){
				//mision, pillaste pluma y sigues en la mision
				imagenGanma.sprite=expresionesGanma[5];
				textoGanma.text=variable_Text.ganma_ForthDay_Mission_Ghoul_GetFeather;
				canvasGanma.GetComponent<Canvas>().enabled=true;
			}
			else if(variablesGeneral.talkedToPumpkin){//ya has hablado una vez
				quienHablaOtros.text="Pumpkin";
				imagenOtros.sprite=expresionesPumpkin[2];
				textoOtros.text=variable_Text.pumpkin_ForthDay_Interaction;
				canvasOtros.GetComponent<Canvas>().enabled=true;
			}
			else{conversacionPumpkin();}//hablas por primera vez	
		}

		if(objetoTrigger.name=="racoon_interactable_Day4"){
			if(variablesGeneral.ghoulMission_WIP && !variablesGeneral.ghoulMission_Done){
				quienHablaOtros.text="Racoon";
				imagenOtros.sprite=expresionesRacoon[1];
				textoOtros.text=variable_Text.racoon_ForthDay_Mission_Ghoul;
				canvasOtros.GetComponent<Canvas>().enabled=true;
			}
			else{conversacionRacoon_Day4();}
		}

		if(objetoTrigger.name=="santos_interactable_Day4"){
			if(variablesGeneral.santosMission_Done){endMissionSantos();}
			else{preMission_Santos();}
		}

		if(objetoTrigger.name=="kiyu_interactable_Day4"){
			
			if(variablesGeneral.ghoulMission_WIP && !variablesGeneral.kiyuFeatherPicked && !variablesGeneral.ghoulMission_Done){
				quienHablaOtros.text="Kiyu";
				imagenOtros.sprite=expresionesKiyu[3];
				textoOtros.text=variable_Text.kiyu_ForthDay_Mission_Ghoul;
				canvasOtros.GetComponent<Canvas>().enabled=true;
				variablesGeneral.kiyuFeatherPicked=true;
			}
			else if(variablesGeneral.ghoulMission_WIP && variablesGeneral.kiyuFeatherPicked && !variablesGeneral.ghoulMission_Done){
				imagenGanma.sprite=expresionesGanma[5];
				textoGanma.text=variable_Text.ganma_ForthDay_Mission_Ghoul_GetFeather;
				canvasGanma.GetComponent<Canvas>().enabled=true;
			}
			else if(variablesGeneral.kiyuMission_Done){
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Kiyu";
				imagenOtros.sprite=expresionesKiyu[5];
				textoOtros.text=variable_Text.kiyu_ForthDay_PostMission_PostInteract;
			}//ya has hecho la mision
			else{preMission_Kiyu();}
		}

		if(objetoTrigger.name=="ghoul_interactable_Day4"){
			if(!variablesGeneral.ghoulMission_WIP && !variablesGeneral.ghoulMission_Done){preMission_Ghoul();}
			else if(
				(variablesGeneral.pumpkinFeatherPicked || variablesGeneral.kiyuFeatherPicked || variablesGeneral.whiskersFeatherPicked)
				&& !variablesGeneral.ghoulMission_Done){
				finishGhoulMission();
			}
			else if(variablesGeneral.ghoulMission_WIP && !variablesGeneral.ghoulMission_Done){
				quienHablaOtros.text="Ghoul";
				imagenOtros.sprite=expresionesGhoul[7];
				textoOtros.text=variable_Text.ghoul_ForthDay_InMission;
				canvasOtros.GetComponent<Canvas>().enabled=true;
			}
			else{//fin mision
				quienHablaOtros.text="Ghoul";
				imagenOtros.sprite=expresionesGhoul[3];
				textoOtros.text=variable_Text.ghoul_ForthDay_PostMission;
				canvasOtros.GetComponent<Canvas>().enabled=true;
			}

		}
//------------------
		//dia5
		if(variablesGeneral.spriteTocado=="kiyu_interactable_Day5"){//to test
			quienHablaOtros.text="Kiyu";
			imagenOtros.sprite=expresionesKiyu[0];
			textoOtros.text=variable_Text.kiyu_FifthDay;
			canvasOtros.GetComponent<Canvas>().enabled=true;
		 }

		 if(variablesGeneral.spriteTocado=="end_interactable"){goSleep_Question_FinalDay();}
		

	}


	void endChapter(){//todo
		ChangeScene.LoadScene("transition_part2_to_3");
	}
//------------
	void initialConversation(){
		switch(variablesGeneral.contador){
			case 0:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

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


			//como puedes no hacer las misiones las tenemos que pasar a true para que no estorben en los siguientes dias
			variablesGeneral.awamiKomaMission_Done=true;
			variablesGeneral.awamiKomaMission_WIPBool=true;
		}
		else if(variablesGeneral.sleepDay2 && variablesGeneral.sleepDay3
		&& !variablesGeneral.sleepDay4 && !variablesGeneral.sleepDay5){
			transform.position=new Vector3(forthDay.position.x,forthDay.position.y,0);//teleportDays
			variablesGeneral.sleepDay4=true;
			//del tercero al cuarto

			//como puedes no hacer las misiones las tenemos que pasar a true para que no estorben en los siguientes dias
			variablesGeneral.akaneMission_Done=true;
			variablesGeneral.talkedToRacoon=true;
			variablesGeneral.racoonMission_WIP=true;
			variablesGeneral.racoonMission_Done=true;
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
			endChapter();

		}
	}

	void teleportRooms(){
		if(objetoTrigger.name=="teleportVerde_izq_Dia2"){//estas con trigger en la izq, teleportas a la derecha
			transform.position=new Vector3(teleportDaysGreenRight_Day2.position.x,teleportDaysGreenRight_Day2.position.y,0);
		}
		if(objetoTrigger.name=="teleportVerde_der_Dia2"){//estas con trigger en la der, teleportas a la izq
			transform.position=new Vector3(teleportDaysGreenLeft_Day2.position.x,teleportDaysGreenLeft_Day2.position.y,0);
		}



		if(objetoTrigger.name=="teleportVerde_izq_Dia3"){//estas con trigger en la izq, teleportas a la der
			transform.position=new Vector3(teleportDaysGreenRight_Day3.position.x,teleportDaysGreenRight_Day3.position.y,0);
		}
		if(objetoTrigger.name=="teleportVerde_der_Dia3"){//estas con trigger en la der, teleportas a la izq
			transform.position=new Vector3(teleportDaysGreenLeft_Day3.position.x,teleportDaysGreenLeft_Day3.position.y,0);
		}



		if(objetoTrigger.name=="teleportAzul_top_Dia3"){//estas con trigger de arriba, teleportas abajo
			transform.position=new Vector3(teleportDaysBlueBottom_Day3.position.x,teleportDaysBlueBottom_Day3.position.y,0);
		}
		if(objetoTrigger.name=="teleportAzul_bottom_Dia3"){//estas con trigger de abajo, teleportas arriba
			transform.position=new Vector3(teleportDaysBlueTop_Day3.position.x,teleportDaysBlueTop_Day3.position.y,0);
		}



		if(objetoTrigger.name=="teleportNaranja_top_Dia3"){//estas con trigger de arriba, teleportas abajo
			transform.position=new Vector3(teleportDaysYellowBottom_Day3.position.x,teleportDaysYellowBottom_Day3.position.y,0);
		}
		if(objetoTrigger.name=="teleportNaranja_bottom_Dia3"){//estas con trigger de abajo, teleportas arriba
			transform.position=new Vector3(teleportDaysYellowTop_Day3.position.x,teleportDaysYellowTop_Day3.position.y,0);
		}


	}

}