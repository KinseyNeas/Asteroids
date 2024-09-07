using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Vector2 mousePos;
    private float speedPlayer = 5f;
    public GameObject bullet;
    public Transform shootPos;
    private float speedBullet = 10f;
    private Vector2 respawnPos = new Vector2(0,-2);
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);
    }

    void OnMove(InputValue value){
        rb.velocity = value.Get<Vector2>() * speedPlayer;
    }

    void OnLook(InputValue value){
        mousePos = (Vector2)Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    void OnShoot(){
        GameObject projectile = Instantiate(bullet, shootPos.position, shootPos.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(shootPos.up * speedBullet, ForceMode2D.Impulse);
    }

    public void Respawn(){
        transform.position = respawnPos;
    }
}
