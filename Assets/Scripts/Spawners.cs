using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{

    public string position;
    public GameObject[] enemies;
    
    

    // Start is called before the first frame update
    void Start()
    {
        if (position == "Top")
        {
            InvokeRepeating("SpawnTop", 1, Random.Range(3, 6));
        }

        else if (position == "Bottom")
        {
            InvokeRepeating("SpawnBottom", 1.5f, Random.Range(3, 6));
        }

        else if (position == "Right")
        {
            InvokeRepeating("SpawnRight", 2, Random.Range(3, 6));
        }

        else if (position == "Left")
        {
            InvokeRepeating("SpawnLeft", 2, Random.Range(3, 6));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnTop()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-4.5f, 4.5f), 6f);
        int enemyToSpawn = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyToSpawn], spawnPos, transform.localRotation);
    }

    private void SpawnBottom()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-4.5f, 4.5f), -6f);
        int enemyToSpawn = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyToSpawn], spawnPos, transform.localRotation);
    }

    private void SpawnLeft()
    {
        Vector2 spawnPos = new Vector2(-6f, Random.Range(-4.5f, 4.5f));
        int enemyToSpawn = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyToSpawn], spawnPos, transform.localRotation);
    }

    private void SpawnRight()
    {
        Vector2 spawnPos = new Vector2(6f, Random.Range(-4.5f, 4.5f));
        int enemyToSpawn = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyToSpawn], spawnPos, transform.localRotation);
    }
}
