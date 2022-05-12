using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class variablesGeneral : MonoBehaviour
{
    public static Random random=new System.Random();
    public static int pillado1=0;
    public static int pillado2=0;
    public static int pillado3=0;
    public static int pillado4=0;

    public static float velocidad=2f;
	public static Vector3 moveDelta;
	public static bool canMove=true;
    public static string spriteTocado="";

    public static string pillado1Txt="Is this.. my sister's fur?";
    public static string pillado2Txt="More?";
    public static string pillado3Txt="She always told me to not go this far but...";
    public static string pillado4Txt="Wisp..?";
    public static string pilladoFinaleTxt="...";

    
    public static bool sleepDay2=false;
    public static bool sleepDay3=false;
    public static bool sleepDay4=false;
    public static bool sleepDay5=false;

    public static bool startDone=false;

    public static int awamiKomaMission_WIP=0;
    public static bool awamiKomaMission_WIPBool=false;
    public static bool awamiKomaMission_Done=false;

    public static bool akaneMission_Done=false;

    public static bool talkedToRacoon=false;
    public static bool racoonMission_WIP=false;
    public static bool racoonMission_Done=false;

    public static bool ghoulMission_WIP=false;
    public static bool ghoulMission_Done=false;

    public static bool pumpkinFeatherPicked=false;
    public static bool kiyuFeatherPicked=false;
    public static bool whiskersFeatherPicked=false;

    public static bool santosMission_WIP=false;
    public static bool santosMission_Done=false;

    public static bool kiyuMission_Done=false;


    public static bool jumpscareShown=false;
    public static bool rennieAppeared=false;
    public static bool talkedToPumpkin=false;
    
    
    public static int contador=0;
    public static int contador2=0;
    public static int num_random=0;
    public static int contar=0;
    public static int contar2=0;
    public static int contar3=0;
    public static int contar4=0;
    public static int contarRennie=0;
    public static int contarWhiskers=0;
    public static int contarHemi=0;
    public static int contarPumpkin=0;
    public static int contarRacoon=0;
    public static int contarSantos=0;
    public static int contarKiyu=0;
    public static int contarGhoul=0;
    public static bool correctBonePicked=false;


    public static bool canBeDamaged=true;
}
