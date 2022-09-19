using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    GameObject targetGameobject;
    Charactor targetCharactor;
    [SerializeField] float speed;

    Rigidbody2D rb;

    [SerializeField] int hp = 5;
    [SerializeField] int damage = 1;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject Targets){
        targetGameobject = Targets;
        target = Targets.transform;
    }

    private void FixedUpdate(){
        Vector3 directtion = (target.position - transform.position).normalized;
        rb.velocity = directtion * speed;
    }

    private void OnCollisionStay2D(Collision2D col){
        if(col.gameObject == targetGameobject){
            Attack();
        }
    }

    private void Attack(){
        if(targetCharactor == null){
            targetCharactor = targetGameobject.GetComponent<Charactor>();
        }

        targetCharactor.TakeDamage(damage);
    }

    public void TakeDamage(int damage){
        hp -= damage;

        if(hp < 1){
            Destroy(gameObject);
        }
    }
}
