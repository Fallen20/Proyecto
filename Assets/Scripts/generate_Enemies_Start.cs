using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_Enemies_Start : MonoBehaviour
{
    public GameObject enemigo_Prefab;//platformPrefab
    public GameObject spaceToSpawn;//lastCreatedPlatfrom
    public Transform spawnPoint;//referencePoint

    public static int created=0;
    public int randomNum=1;
    public bool enter=false;
    


    private void Start() {
        createEnemy();
    }

    public void createEnemy(){ 
        
        Invoke("randomNumber",3f);//llamas a un random
        

        if(randomNum%2==0 && created<3){//condciones
            created++;
            float espacioExtra=Random.Range(0, 5);
            Vector3 targetCreationPoint = new Vector3(
                        spawnPoint.position.x+espacioExtra,//el espacio extra es para que no se generen en el mismo sitio todos
                        0,
                        0);

            spaceToSpawn=Instantiate(enemigo_Prefab, targetCreationPoint, Quaternion.identity);
                
            
            
        }

        Invoke("createEnemy",7f);//vuelves a llamar al metodo tras x segundos
        
    }

    private void randomNumber(){
        randomNum=variablesGeneral.random.Next(0,11);
    }
    private void canEnter(){enter=true;}



}
