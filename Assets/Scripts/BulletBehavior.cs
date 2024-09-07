using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Camera camera;
    //private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPos();
    }

    void CheckPos(){

        Vector2 bulletPos = camera.WorldToScreenPoint(transform.position);
        if(bulletPos.x < 0 || bulletPos.x > camera.pixelWidth 
        || bulletPos.y < 0 || bulletPos.y > camera.pixelHeight){
            Destroy(gameObject);
        }
    }

    // void OnTriggerEnter2D(Collider2D other){

    // }

}
