using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool hitDetected = false;
    [SerializeField] int damage = 5;

    void Update()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.7f);
        
        foreach (Collider2D c in hit){
            Enemy enemy = c.GetComponent<Enemy>();
            if(enemy != null){
                enemy.TakeDamage(damage);
                hitDetected = true;
                break;
            }
        }
        if(hitDetected == true){
            Destroy(gameObject);
        }
    }
}
