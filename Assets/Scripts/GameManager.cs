using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyBehavior Enemy;
    public int enemyCount = 0;
    void Start()
    {
        for(int i = 0; i < 6; ++i){
            SpawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount < 4){
            for(int i = 0; i < 2; ++i){
                SpawnEnemy();
            } 
        }
    }

    void SpawnEnemy(){
        ++enemyCount;
        float offset = Random.Range(0f,1f);
        Vector2 viewportSpawnPos = Vector2.zero;

        int edge = Random.Range(1,4);
        if(edge == 0) {viewportSpawnPos = new Vector2(offset, 0);
        } else if (edge == 1) { viewportSpawnPos = new Vector2(offset, 1);
        } else if (edge == 2) { viewportSpawnPos = new Vector2(1, offset);}

        Vector2 worldSpawnPos = Camera.main.ViewportToWorldPoint(viewportSpawnPos);
        EnemyBehavior enemy = Instantiate(Enemy, worldSpawnPos, Quaternion.identity);
        enemy.gameManager = this;
    }
}
