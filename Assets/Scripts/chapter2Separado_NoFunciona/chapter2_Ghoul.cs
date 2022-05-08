using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapter2_Ghoul : MonoBehaviour
{
	/*public static void preMission_Ghoul(){
		switch (variablesGeneral.contarGhoul){
			case 0:
				playerScript1_Chapter2.canvasOtros.GetComponent<Canvas>().enabled=true;

				playerScript1_Chapter2.quienHablaOtros.text="Ghoul";
				playerScript1_Chapter2.imagenOtros.sprite=playerScript1_Chapter2.expresionesGhoul[4];
				playerScript1_Chapter2.textoOtros.text=variable_Text.ghoul_ForthDay_PreMission_1;
				variablesGeneral.contarGhoul++;
				break;

			case 1:
				playerScript1_Chapter2.canvasOtros.GetComponent<Canvas>().enabled=false;
				playerScript1_Chapter2.canvasGanma.GetComponent<Canvas>().enabled=true;


				playerScript1_Chapter2.imagenGanma.sprite=playerScript1_Chapter2.expresionesGanma[8];
				playerScript1_Chapter2.textoGanma.text=variable_Text.ganma_ForthDay_PreMission_Ghoul_1;
				variablesGeneral.contarGhoul++;
				break;

			case 2:
				playerScript1_Chapter2.canvasGanma.GetComponent<Canvas>().enabled=false;
				playerScript1_Chapter2.canvasOtros.GetComponent<Canvas>().enabled=true;
				playerScript1_Chapter2.gameObjectBotonesMision.GetComponent<Canvas>().enabled=true;
				playerScript1_Chapter2.textoBotonAceptar.text="I can try to help...";
				playerScript1_Chapter2.textoBotonDeny.text="I'm sorry";

				playerScript1_Chapter2.quienHablaOtros.text="Ghoul";
				playerScript1_Chapter2.imagenOtros.sprite=playerScript1_Chapter2.expresionesGhoul[5];
				playerScript1_Chapter2.textoOtros.text=variable_Text.ghoul_ForthDay_PreMission_2;
				variablesGeneral.contarGhoul++;
				break;
		}
	}

    
	public static void acceptGhoulMission(){
		switch (variablesGeneral.contarGhoul) 
		{
			case 4:
				playerScript1_Chapter2.canvasOtros.GetComponent<Canvas>().enabled=true;
				playerScript1_Chapter2.canvasGanma.GetComponent<Canvas>().enabled=false;
				playerScript1_Chapter2.gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;

				playerScript1_Chapter2.imagenGanma.sprite=playerScript1_Chapter2.expresionesGanma[9];
				playerScript1_Chapter2.textoGanma.text=variable_Text.ganma_ForthDay_PreMission_Ghoul_2;
				variablesGeneral.contarGhoul++;
				break;

			case 5:
				playerScript1_Chapter2.canvasGanma.GetComponent<Canvas>().enabled=false;
				playerScript1_Chapter2.canvasOtros.GetComponent<Canvas>().enabled=true;
				playerScript1_Chapter2.textoBotonAceptar.text="I can try to help...";
				playerScript1_Chapter2.textoBotonDeny.text="I'm sorry";

				playerScript1_Chapter2.quienHablaOtros.text="Ghoul";
				playerScript1_Chapter2.imagenOtros.sprite=playerScript1_Chapter2.expresionesGhoul[6];
				playerScript1_Chapter2.textoOtros.text=variable_Text.ghoul_ForthDay_PreMission_3;
				variablesGeneral.ghoulMission_WIP=true;
				break;
		}
	}

	public static void finishGhoulMission(){//esto saca solo los botones de las plumas cogidas, el que aprete a una u otra es en otro

		//oculta las que no ha cogido
		if(!variablesGeneral.pumpkinFeatherPicked){playerScript1_Chapter2.botonPumpkin.gameObject.SetActive(false);}
		else{playerScript1_Chapter2.botonPumpkin.gameObject.SetActive(true);}

		if(!variablesGeneral.kiyuFeatherPicked){playerScript1_Chapter2.botonKiyu.gameObject.SetActive(false);}
		else{playerScript1_Chapter2.botonKiyu.gameObject.SetActive(true);}

		if(!variablesGeneral.whiskersFeatherPicked){playerScript1_Chapter2.botonWhiskers.gameObject.SetActive(false);}
		else{playerScript1_Chapter2.botonWhiskers.gameObject.SetActive(true);}

		//sacas el texto
		playerScript1_Chapter2.imagenGanma.sprite=playerScript1_Chapter2.expresionesGanma[0];//change //por hacer
		playerScript1_Chapter2.textoGanma.text=variable_Text.giveFeater;
		playerScript1_Chapter2.canvasColorGanma.sprite=playerScript1_Chapter2.canvasAzul;

		//sacas los botones y el canvas

		playerScript1_Chapter2.botonesMisionGhoul.GetComponent<Canvas>().enabled=true;
		playerScript1_Chapter2.canvasGanma.GetComponent<Canvas>().enabled=true;

	}*/
	
}
