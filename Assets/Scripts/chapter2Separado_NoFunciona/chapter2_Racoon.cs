using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapter2_Racoon : MonoBehaviour
{
  /* public static void Racoon_Initial_Conversation(){
		switch(variablesGeneral.contar4){
			case 0:
				playerScript1_Chapter2.canvasGanma.GetComponent<Canvas>().enabled=false;
				playerScript1_Chapter2.canvasOtros.GetComponent<Canvas>().enabled=true;

				playerScript1_Chapter2.imagenOtros.sprite=playerScript1_Chapter2.expresionesRacoon[2];
				playerScript1_Chapter2.quienHablaOtros.text="Racoon";
				playerScript1_Chapter2.textoOtros.text=variable_Text.racoon_ThirdDay_1;
				variablesGeneral.contar4+=1;
				break;

			case 1:
				playerScript1_Chapter2.canvasGanma.GetComponent<Canvas>().enabled=false;
				playerScript1_Chapter2.canvasOtros.GetComponent<Canvas>().enabled=true;

				playerScript1_Chapter2.imagenOtros.sprite=playerScript1_Chapter2.expresionesRacoon[3];
				playerScript1_Chapter2.quienHablaOtros.text="Racoon";
				playerScript1_Chapter2.textoOtros.text=variable_Text.racoon_ThirdDay_2;
				variablesGeneral.contar4+=1;
				variablesGeneral.talkedToRacoon=true;
				variablesGeneral.contar4++;
				break;
		}
	}

   public static void acceptRacoonMission(){
		playerScript1_Chapter2.gameObjectBotonesMision.GetComponent<Canvas>().enabled=false;

		switch(variablesGeneral.contar4){
			case 4:
				playerScript1_Chapter2.canvasGanma.GetComponent<Canvas>().enabled=false;
				playerScript1_Chapter2.canvasOtros.GetComponent<Canvas>().enabled=true;

				playerScript1_Chapter2.imagenOtros.sprite=playerScript1_Chapter2.expresionesRacoon[6];
				playerScript1_Chapter2.quienHablaOtros.text="Racoon";
				playerScript1_Chapter2.textoOtros.text=variable_Text.racoon_ThirdDay_PreMission_2;
				variablesGeneral.contar4+=1;

				
				break;

			case 5:
				playerScript1_Chapter2.canvasGanma.GetComponent<Canvas>().enabled=true;
				playerScript1_Chapter2.canvasOtros.GetComponent<Canvas>().enabled=false;

				playerScript1_Chapter2.imagenGanma.sprite=playerScript1_Chapter2.expresionesGanma[23];
				playerScript1_Chapter2.textoGanma.text=variable_Text.ganma_ThirdDay_PreRacoonMission;
				playerScript1_Chapter2.canvasColorGanma.sprite=playerScript1_Chapter2.canvasAzul;
				elementsRacoonMission();			
				break;
		}

	}

	

   public static void elementsRacoonMission(){
		variablesGeneral.num_random=playerScript1_Chapter2.random.Next(1,playerScript1_Chapter2.gameObjectRacoonMission.Length);
		//numero random como tamaño max el numero de elementos en la array

		for(int contador=0;contador<playerScript1_Chapter2.gameObjectRacoonMission.Length;contador++){
			playerScript1_Chapter2.gameObjectRacoonMission[contador].GetComponent<BoxCollider2D>().enabled=false;
		}
		
		//solo activas ese
		playerScript1_Chapter2.gameObjectRacoonMission[variablesGeneral.num_random].GetComponent<BoxCollider2D>().enabled=true;

		variablesGeneral.racoonMission_WIP=true;

	}


	public static void conversacionRacoon_Day4 (){
		switch(variablesGeneral.contarRacoon){
			case 0:
				playerScript1_Chapter2.canvasOtros.GetComponent<Canvas>().enabled=true;
				playerScript1_Chapter2.canvasGanma.GetComponent<Canvas>().enabled=false;

				playerScript1_Chapter2.quienHablaOtros.text="Racoon";
				playerScript1_Chapter2.imagenOtros.sprite=playerScript1_Chapter2.expresionesRacoon[1];
				playerScript1_Chapter2.textoOtros.text=variable_Text.racoon_ForthDay;
				variablesGeneral.contarRacoon++;
				break;
				
			case 1:
				playerScript1_Chapter2.canvasOtros.GetComponent<Canvas>().enabled=false;
				playerScript1_Chapter2.canvasGanma.GetComponent<Canvas>().enabled=true;

				playerScript1_Chapter2.imagenGanma.sprite=playerScript1_Chapter2.expresionesGanma[11];
				playerScript1_Chapter2.textoGanma.text=variable_Text.ganma_ForthDay_Racoon;
				variablesGeneral.contarRacoon++;
				break;

		}
	}*/
}
