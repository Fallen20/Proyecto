using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_Enemies_Middle : MonoBehaviour
{
    public GameObject enemigo_Prefab;
    public GameObject spaceToSpawn;
    public Transform spawnPoint;
    public static int created=0;

    private void Start() {
        Debug.Log("yeeeeeeeeeeeeeet" +created);

        createEnemy();
    }
    void Update()
    {
         if(created<9){
             created++;
            Debug.Log("yeeeeeeeeeeeeeet" +created);
            Invoke("createEnemy",5f);
        }        
        
    }

    public void createEnemy(){ //con esto saca literalmente muchos. Literal Lag
        
        float espacioExtra=Random.Range(0, 15);
        Vector3 targetCreationPoint = new Vector3(
                       spawnPoint.position.x+espacioExtra,//el espacio extra es para que no se generen en el mismo sitio todos
                       0,
                       0);

         spaceToSpawn=Instantiate(spaceToSpawn, targetCreationPoint, Quaternion.identity);
    }

    IEnumerator createEnemy2() {
        Debug.Log("yeeeeeeeeeeeeeet" +created);
        created++;
        if(created<10){
            Debug.Log("aui");
            float espacioExtra=Random.Range(0, 15);

            Instantiate(enemigo_Prefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds((Random.Range(0,15)));//waitForSeconds es que espera X segundos para hacer un return
            StartCoroutine(createEnemy2());
        }
        else{yield return null;}
        
    }
}
