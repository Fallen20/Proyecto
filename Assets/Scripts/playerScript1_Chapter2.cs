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
	
	
	private int contar=0;
	private int contar2=0;

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
	

	//variables a usar
    private GameObject objetoTrigger;
	


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

		//teleportDayss

		//al cargar la sala lo hacen aqui
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

		finalAwamiKomaMission=GameObject.FindWithTag("finalAwamiKomaMission").GetComponent<Transform>();
		

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
		Debug.Log(coll.gameObject.name);
		objetoTrigger=coll.gameObject;

		if(objetoTrigger.name=="teleportVerde_izq_Dia2" || objetoTrigger.name=="teleportVerde_der_Dia2"){
			//add more
			teleportRooms();
		}

	}

	void OnTriggerExit2D(Collider2D coll) {
		objetoTrigger=null;
	}
//---------------


	//cosas con canvas y botones

	//ocultar
	public void hideCanvas_Ganma(){
		Debug.Log("contar2"+contar2);
		Debug.Log("mission done"+variablesGeneral.awamiKomaMission_Done);

		if(!variablesGeneral.startDone){initialConversation();}
		else if(variablesGeneral.awamiKomaMission_WIP==0 && !variablesGeneral.awamiKomaMission_Done){
			//si has aceptado la mision, apretar saca el siguiente dialogo
			acceptAwami_KomaMission();
		}
		else if (!variablesGeneral.akaneMission_Done){
			if(objetoTrigger.name=="akane_interactable_Day3"){
				Debug.Log("here2222222");
				
				if(contar2<6){Mission_Akane();}
				else if(contar2==6){
					Invoke("sortingLayerPositive",1f);
					fadeCanvas.sortingOrder=1;
					//fade
					trueFade();

					//sacar el post mission
					Invoke("PostAkaneMission",3f);
					
					//desfade
					Invoke("falseFade",2f);

					Invoke("sortingLayerNegative", 3f);
				}
				else{PostAkaneMission();}
			}
			else{
				canvasGanma.GetComponent<Canvas>().enabled=false;
				variablesGeneral.canMove=true;
				contar=0;
				contar2=0;
				variablesGeneral.contador2=0;
			}
		}
		else{
			canvasGanma.GetComponent<Canvas>().enabled=false;
			variablesGeneral.canMove=true;
		}
		
	}

	public void hideCanvas_Otros(){
		
		if(!variablesGeneral.startDone){initialConversation();}
		else{		
			if(variablesGeneral.contador2==1){Mission_Koma_Awami();}
			else if(contar<4 && contar!=0){//si has aceptado la mision, apretar saca el siguiente dialogo
				acceptAwami_KomaMission();
			}
			else if(variablesGeneral.awamiKomaMission_WIP==1 || variablesGeneral.awamiKomaMission_WIP==2){
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
				else{
					canvasOtros.GetComponent<Canvas>().enabled=false;
					gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;
					variablesGeneral.canMove=true;
					contar=0;
					contar2=0;
					variablesGeneral.contador2=0;
				}
				
			}
			else if(!variablesGeneral.akaneMission_Done && objetoTrigger!=null){
				if(objetoTrigger.name=="akane_interactable_Day3"){
					Debug.Log("here");

					if(contar2<6){Mission_Akane();}
					else{PostAkaneMission();}
					
				}
				else{
					canvasOtros.GetComponent<Canvas>().enabled=false;
					gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;
					variablesGeneral.canMove=true;
					contar=0;
					contar2=0;
					variablesGeneral.contador2=0;
				}
				
			}
			else{
				canvasOtros.GetComponent<Canvas>().enabled=false;
				gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;
				variablesGeneral.canMove=true;
				contar=0;
				contar2=0;
				variablesGeneral.contador2=0;
			}
		}
		
	}

//---------------
	void trueFade(){
		fadeAnimation.SetBool("fade", true);
	}
	void falseFade(){
		fadeAnimation.SetBool("fade", false);
	}

	void canMoveAgain(){variablesGeneral.canMove=true;}

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

	public void Mission_Akane(){
		switch(contar2){
			case 0:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[0];///change
				textoGanma.text=variable_Text.ganma_ThirdDay_PreAkaneMission_1;
				contar2++;
				break;

			case 1:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Akane";
				imagenOtros.sprite=expresionesAkane[4];//change
				textoOtros.text=variable_Text.akane_ThirdDay_PreMission_1;
				contar2++;
				break;

			case 2:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[0];//change
				textoGanma.text=variable_Text.ganma_ThirdDay_PreAkaneMission_2;
				contar2++;
				break;

			case 3:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Akane";
				imagenOtros.sprite=expresionesAkane[4];//change
				textoOtros.text=variable_Text.akane_ThirdDay_PreMission_2;
				contar2++;
				break;

			case 4:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Akane";
				imagenOtros.sprite=expresionesAkane[4];//change
				textoOtros.text=variable_Text.akane_ThirdDay_PreMission_3;
				contar2++;
				break;

			case 5:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[4];//change
				textoGanma.text=variable_Text.ganma_ThirdDay_PreAkaneMission_3;
				contar2++;

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
					contar+=1;
					break;
			}
		
		
			
		
	}

	void PostAkaneMission(){
		switch(contar2){
			case 6:
				fadeCanvas.sortingOrder=-1;
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Akane";
				imagenOtros.sprite=expresionesAkane[4];//change
				textoOtros.text=variable_Text.akane_ThirdDay_PostMission_1;
				contar2++;
				break;

			case 7:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesAkane[4];//change
				textoGanma.text=variable_Text.ganma_ThirdDay_PostAkaneMission_1;
				contar2++;
				break;

			case 8:
				canvasGanma.GetComponent<Canvas>().enabled=false;
				canvasOtros.GetComponent<Canvas>().enabled=true;

				quienHablaOtros.text="Akane";
				imagenOtros.sprite=expresionesAkane[4];//change
				textoOtros.text=variable_Text.akane_ThirdDay_PostMission_2;
				contar2++;
				break;

			case 9:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[4];//change
				textoGanma.text=variable_Text.ganma_ThirdDay_PostAkaneMission_2;
				contar2++;
				break;

			case 10:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[4];//change
				textoGanma.text=variable_Text.ganma_ThirdDay_PostAkaneMission_3;
				canvasColorGanma.sprite=canvasAzul;
				contar2++;
				break;

			case 11:
				canvasGanma.GetComponent<Canvas>().enabled=true;
				canvasOtros.GetComponent<Canvas>().enabled=false;

				imagenGanma.sprite=expresionesGanma[4];//change
				textoGanma.text=variable_Text.ganma_ThirdDay_PostAkaneMission_4;
				canvasColorGanma.sprite=canvasAzul;
				variablesGeneral.akaneMission_Done=true;
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

//----------------
	public void interactable(){
		variablesGeneral.canMove=false;

		//pillas el nombre de lo que tocas
		variablesGeneral.spriteTocado=objetoTrigger.name;

		//entonces decides las cosas
		decideText(variablesGeneral.spriteTocado);
	}

	void decideText(string spriteTocado){//esto SOLO saca texto
		canvasColorGanma.sprite=canvasNaranja;

		 if(variablesGeneral.spriteTocado=="wisp_interactable"){
			 goSleep_Question();
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
			 imagenOtros.sprite=expresionesAkane[0];
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
				 contar=0;
				 //numero random
					Random random=new System.Random();
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
			 imagenOtros.sprite=expresionesKiyu[7];
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
			imagenGanma.sprite=expresionesGanma[27];
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
		 if(variablesGeneral.spriteTocado=="koma_interactable_Day3"){//change
			Debug.Log(":O");
		 }
		 if(variablesGeneral.spriteTocado=="akane_interactable_Day3"){Mission_Akane();}//change
		 if(variablesGeneral.spriteTocado=="awami_interactable_Day3"){
			quienHablaOtros.text="Awami";
			imagenOtros.sprite=expresionesAwami[6];
			textoOtros.text=variable_Text.awami_ThirdDay;
			canvasOtros.GetComponent<Canvas>().enabled=true;
		 }
		 if(variablesGeneral.spriteTocado=="racoon_interactable_Day3"){//change
		 	Debug.Log(">:(");
		 }

	}


	void endChapter(){
		Debug.Log("change scene+fade");
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

	void teleportRooms(){
		if(objetoTrigger.name=="teleportVerde_izq_Dia2"){//estas con trigger en la izq, teleportas a la derecha
			transform.position=new Vector3(teleportDaysGreenRight_Day2.position.x,teleportDaysGreenRight_Day2.position.y,0);
		}
		if(objetoTrigger.name=="teleportVerde_der_Dia2"){//estas con trigger en la der, teleportas a la izq
			transform.position=new Vector3(teleportDaysGreenLeft_Day2.position.x,teleportDaysGreenLeft_Day2.position.y,0);
		}
	}



	void sortingLayerNegative(){fadeCanvas.sortingOrder=-1;}
	void sortingLayerPositive(){fadeCanvas.sortingOrder=12;}

}
