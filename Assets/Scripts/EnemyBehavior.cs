using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 direction;
    private Rigidbody2D rb;
    public GameManager gameManager;
    public float size = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = 0.5f * size * Vector3.one;
        direction = new Vector2(Random.value, Random.value);
        float spawnSpeed = Random.Range(3f - size, 4f - size);
        rb.AddForce(direction * spawnSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        switch(other.gameObject.tag)
        {
            case "Bullet":
                Destroy(other.gameObject);
                if (size > 1.5f) {
                    for (int i = 0; i < 2; i++) {
                        EnemyBehavior newEnemy = Instantiate(this, transform.position, Quaternion.identity);
                        newEnemy.size = size - 0.6f;
                        newEnemy.gameManager = gameManager;
                        newEnemy.GetComponent<SpriteRenderer>().color = new Color(195,165,240);
                    }
                    --gameManager.enemyCount;
                }
                Destroy(gameObject);
                break;
            case "Player":
                other.gameObject.GetComponent<PlayerBehavior>().Respawn();
                break;
        }
    }
}
