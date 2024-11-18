using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private float[] arrPosX={-2.2f,-1.1f,0f,1.1f,2.2f };
    
    [SerializeField]
    private float spawnInterval = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       StartEnemyRoutine();
    }

    void StartEnemyRoutine(){
        StartCoroutine("EnemyRoutine");
    }
    IEnumerator EnemyRoutine(){

        yield return new WaitForSeconds(3f);
        int spawnCount = 0;
        int enemyIndex = 0;
        float moveSpeed = 5f;
        
        while(true){
            foreach(float posX in arrPosX){
                SpawnEnemy(posX, enemyIndex ,moveSpeed);
            }

            spawnCount+=1;
            if(spawnCount %10==0){
                enemyIndex+=1;
                moveSpeed +=2;
            }
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }

   void SpawnEnemy(float posX, int index, float moveSpeed){
       Vector3 spawnPos = new Vector3(posX,transform.position.y,transform.position.z);
       
       if(Random.Range(0,5)==0){//0,1,2,3,4->0  20%
        index+=1;
       }
       if(index >=enemies.Length){
          index = enemies.Length -1;
       }

       
       GameObject enemyObject =Instantiate(enemies[index],spawnPos,Quaternion.identity);
       Enemy enemy = enemyObject.GetComponent<Enemy>();
       enemy.SetMoveSpeed(moveSpeed);
   }
}
