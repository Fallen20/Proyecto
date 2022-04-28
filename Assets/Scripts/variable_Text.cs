using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variable_Text : MonoBehaviour
{

    public static string blank=" ";
    public static string tresPuntos="...";
    public static string passDay_normal="Do you want to rest?";
    public static string passDay_lastDay="..It's time";


    //-------------------
    //antes de poder moverse, la conversacion del principio tras la cinematica
    public static string wisp_FirstDay1="Ganma?!";
    public static string wisp_FirstDay2="What are you doing here?!";
    public static string ganma_FirstDay1="I-I tried to come save you!";
    public static string wisp_FirstDay3="I told you to run if something happened";
    public static string ganma_FirstDay2="I know but-!";
    public static string wisp_FirstDay4="Ganma, now we are both trapped here";
    public static string ganma_FirstDay3="...";
    public static string wisp_FirstDay5="All we can do now is wait";
    public static string ganma_FirstDay4="I'm sorry...";
    public static string wisp_FirstDay6="I know, sorry for yelling.";
    //cambiar expresiones sin texto
    public static string wisp_FirstDay7="Don't be scared. I'll protect you no matter what";
    
    //-----------------
    //interacciones primer dia
    public static string akane_FirstDay="Where are you from?";
    public static string koma_FirstDay="You are very big!";
    public static string awami_FirstDay="Play with us!";
    public static string kiyu_FirstDay="Don't be scared. We won't hurt you";


    //-----------------
    public static string kiyu_SecondDay="Did you sleep well? Akane is still sleep";

    //interacciones segundo dia
    public static string koma_SecondDay_PreMission_1="Big brother Ganma!";
    public static string awami_SecondDay_PreMission_1="Are you here to play with us?";
    public static string ganmaMissionResponse_1_Ok="I'm always up to! What are playing today?";
    public static string awami_SecondDay_PreMission_2="Hide and seek!";
    public static string koma_SecondDay_PreMission_2="Go with mom and we'll hide!";

    //misiones
    //--------
    public static string koma_SecondDay_Mission="You found me!";
    public static string awami_SecondDay_Mission="I'm a box!";

    //triggerea uno de estos a lo random tras acabar
    public static string koma_SecondDay_PostMission_Interaction="Let's play again tomorrow!";
    public static string awami_SecondDay_PostMission_Interaction="Next time you won't find me!";

    

    //-----------------
    //interacciones tercer dia
    public static string santos_ThirdDay="Oh no, were could the kids be?";

    public static string awami_ThirdDay="Santos will never find me!";

    public static string koma_ThirdDay_1="We can go there.. but mom doesn't allow me.";
    public static string koma_ThirdDay_2="Bring us something cool from there!";

    public static string kiyu_ThirdDay="I better don't wake her up";

    //al hablar por primera vez
    public static string racoon_ThirdDay_1="You're new right sweetheart? I'm Racoon";
    public static string racoon_ThirdDay_2="Welcome to my place. How can I help you?";

    //misiones

    //--------
    //AKANE
    public static string ganma_ThirdDay_PreAkaneMission_1="What's wrong Akane?";
    public static string akane_ThirdDay_PreMission_1="..I want to play but Santos is playing with sister";
    public static string ganma_ThirdDay_PreAkaneMission_2="I can play with you!";
    public static string akane_ThirdDay_PreMission_2="Really?!";
    public static string akane_ThirdDay_PreMission_3="Can you give me a piggyride?!";
    public static string ganma_ThirdDay_PreAkaneMission_3="Of course, I'm very strong!";

    //esto solo una vez al acabar
    public static string akane_ThirdDay_PostMission_1="Give me another big brother!";
    public static string ganma_ThirdDay_PostAkaneMission_1="Tomorrow okay? Now I'm busy";
    public static string akane_ThirdDay_PostMission_2="Awn.. It's a promise!";
    public static string ganma_ThirdDay_PostAkaneMission_2="I promise!";
    public static string ganma_ThirdDay_PostAkaneMission_3="I need to ask sister how to get stronger...";//esto lo piensa
    public static string ganma_ThirdDay_PostAkaneMission_4="He's to heavy for me!";//esto lo piensa

    public static string akane_ThirdDay_PostMission_Interaction="Thanks!";

    //--------
    //RACOON
    public static string racoon_ThirdDay_PreMission_1="Ganma dear, right in time. Can you help me?";
    public static string racoon_ThirdDay_PreMission_2="Thanks. I need something long. Do you know anything?";
    public static string ganma_ThirdDay_PreRacoonMission="I think a bone will do it...";//pensar

    public static string ganma_ThirdDay_RacoonMission_1="Perfect! I'll bring back to Racoon";

    //solo una vez
    public static string racoon_ThirdDay_PostMission="Oh, it's perfect. Thank you so much";

    public static string racoon_ThirdDay_PostMission_Interaction="Thanks for helping me dear";

    //-------------------
    //cuarto dia
    public static string awami_ForthDay="Try catch me if you can brother!";
    public static string akane_ForthDay="I will!";
    public static string koma_ForthDay="Watch out for me!";

    public static string hemi_ForthDay_1="...H...";
    public static string hemi_ForthDay_2="...hi";
    public static string ganma_ForthDay_Hemi="Did they salute me?";//piensa

    //solo una vez
    public static string pumpkin_ForthDay_1="..hi kid";
    public static string ganma_ForthDay_Pumpkin="H..hello";
    public static string pumpkin_ForthDay_2="You are called Ganma no? Nice to meet ya";

    //al volver interactuar
    public static string pumpkin_ForthDay_Interaction="Greetings";
    public static string skyan_ForthDay_Interaction="..h--hello";

    public static string whiskers_ForthDay_1="Howdy!";
    public static string ganma_ForthDay_Whiskers="Hi!";


    //interactuas con algo y sale este trigger
    public static string ganma_ForthDay_Rennie_1="There's something here..";
    public static string ganma_ForthDay_Rennie_2="Ah!";

    //al interactuar
    public static string rennie_ForthDay_1="Surprised?";
    public static string ganma_ForthDay_Rennie_3="Her smile doesn't give me good vibes...";


    public static string racoon_ForthDay="Out";
    public static string ganma_ForthDay_Racoon="Auch! She attacked me...";

    public static string pure_ForthDay="Hello little boy!";
    public static string bounce_ForthDay="How's it going?";


    //misiones

    //-------
    //KIYU
    public static string kiyu_ForthDay_PreMission_1="Your sister will come back before you expect";
    public static string kiyu_ForthDay_PreMission_2="You want to tell me your worries? Or you can sleep with me for a while";
    
    //aceptas
    public static string kiyu_ForthDay_Mission_3="Here, lay down for a bit.";

    //al inmediato de acabar
    public static string kiyu_ForthDay_PostMission_4="Better?";
    public static string ganma_ForthDay_PostMission_Kiyu="..a bit";

    //al volver a interactuar
    public static string kiyu_ForthDay_PostMission_PostInteract="Anytime you feel bad you can come here with me";

    //-------
    //SANTOS
    public static string santos_ForthDay_PreMission_1="Ganma my boy!";
    public static string santos_ForthDay_PreMission_2="Do you want to play or something?";
    public static string santos_ForthDay_PreMission_3="The kids made a new game! I'm sure you'll love it";

    //al volver a interactuar
    public static string santos_ForthDay_PostMission_4="Fun, wasn't it? We'll play as many times you want";
    
    //-------
    //GHOUL
    //esta mision se acepta automaticamente
    public static string ghoul_ForthDay_PreMission_1="Ganma, do you know have feathers?";
    public static string ganma_ForthDay_PreMission_Ghoul_1="N-no";
    public static string ghoul_ForthDay_PreMission_2="You don't? Awn.. I wanted more";
    public static string ganma_ForthDay_PreMission_Ghoul_2="I can try to get some";
    public static string ghoul_ForthDay_PreMission_3="Really? I will be so happy if you do";

    //la mayoria son opcionales
    //pides plumas
    public static string pumpkin_ForthDay_Mission_Ghoul="A feather? Serve yourself kid";
    public static string kiyu_ForthDay_Mission_Ghoul="Ghoul asked for feathers? You can grab one of mine without a problem";
    public static string whiskers_ForthDay_Mission_Ghoul="I have tons of feathers, pick what you like!";
    public static string hemi_ForthDay_Mission_Ghoul="Their eyes filled with fear when I asked him";//de hemi no puedes
    public static string racoon_ForthDay_Mission_Ghoul="The only thing I'm giving you is a scar";
    public static string bounce_ForthDay_Mission_Ghoul="Sorry, I love my body too much to give away a part";

    //sale siempre tras interactuar con alguien con pluma
    public static string ganma_ForthDay_Mission_Ghoul_GetFeather="Thanks!";


    //segun cual le des, reacciona de una manera. Pero solo le puedes dar una
    public static string ghoul_ForthDay_Mission_Pumpkin="Rough touch, but soft if you touch it slowly.";
    public static string ghoul_ForthDay_Mission_Kiyu="Is really soft. Smells very nice.";
    public static string ghoul_ForthDay_Mission_Whiskers="Seems it comes from a bouncy bird. I like the energy";

    //al volver a interactuar
    public static string ghoul_ForthDay_PostMission="Thanks a ton Ganma! Next time I'll bring something to you";


    //----------------------------
    //quinto dia
    public static string kiyu_FifthDay="My kids..! Where are my kids?!";
}
