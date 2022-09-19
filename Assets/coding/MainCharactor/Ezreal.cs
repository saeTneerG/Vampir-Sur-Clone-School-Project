using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ezreal : MonoBehaviour
{
    [SerializeField] float timeAttack = 4f;
    float timer;

    [SerializeField] float bulletForce = 20f;
    public GameObject bullet;
    public Transform bulletTransform;
    private float timerBetweenFiring;
    
    private void Update(){
        timer -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Mouse0) && timer < 0f){
            ShootMythicShot();
        }
    }

    private void ShootMythicShot(){
        GameObject bullets = Instantiate(bullet, bulletTransform.position, bulletTransform.rotation);
        Rigidbody2D rb = bullets.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletTransform.up * bulletForce, ForceMode2D.Impulse);
        timer = timeAttack;
    }

}
