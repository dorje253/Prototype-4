using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject[] enemyPrefabs;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    public GameObject bossPrefab;
    public GameObject[] miniEnemyPrefabs;
    public int bossRound;

    public GameObject[] powerupPrefabs;
    void Start()
    {
        int randomPowerup = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(),powerupPrefabs[randomPowerup].transform.rotation);
        SpwanEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0){
            waveNumber++;
            //Checks if the current wave number is divisible by bossRound
            if (waveNumber % bossRound == 0)
            {
                // Calls to spawn a boss
                SpawnBossWave(waveNumber);
            }
            else
            {
                // Callsto spawn a normal wave of enemies
                SpwanEnemyWave(waveNumber);
            }
            // //Updated to select a random powerup prefab for the Medium Challenge
            int randomPowerup = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(),powerupPrefabs[randomPowerup].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition(){
         float spawnPosX= Random.Range(-spawnRange, spawnRange);
         float spawnPosZ= Random.Range(-spawnRange, spawnRange);
         Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
         return randomPos;
    }


    void SpwanEnemyWave(int enemiesToSpawn){
        for (int i = 0; i<enemiesToSpawn; i++){
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);

             Instantiate(enemyPrefabs[randomEnemy], GenerateSpawnPosition(), enemyPrefabs[randomEnemy].transform.rotation);
        
        }
    }

    void SpawnBossWave(int currentRound)
    {
        // The number of mini-enemies the boss will spawn
        int miniEnemysToSpawn;
        //Checks if bossRound is not zero
        if (bossRound != 0)
        {
            // alculates the number of mini-enemies to spawn based on the current round and bossRound
            miniEnemysToSpawn = currentRound / bossRound;
        }
        else
        {
            miniEnemysToSpawn = 1;
        }
        // Creates the boss at a random spawn position with the prefab's default rotation
        var boss = Instantiate(bossPrefab, GenerateSpawnPosition(),bossPrefab.transform.rotation);
        // Sets the mini-enemies.
        boss.GetComponent<Enemy>().miniEnemySpawnCount = miniEnemysToSpawn;
    }


    // spwan the minimum enemy
    public void SpawnMiniEnemy(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            // chosing the random mini enemy
            int randomMini = Random.Range(0, miniEnemyPrefabs.Length);
            Instantiate(miniEnemyPrefabs[randomMini], GenerateSpawnPosition(),
            miniEnemyPrefabs[randomMini].transform.rotation);
        }
    }


}
