using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    Rigidbody2D rig;
    Vector3 Movement;

    private bool canDash = true;
    private bool isDashing;
    private float dashPow = 30f;
    private float dashTime = 0.2f;
    private float dashCooldown = 1f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] float speed = 3f;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Movement = new Vector3();
    }

    void Update()
    {
        if(isDashing){
            return;
        }

        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        Movement *= speed;

        rig.velocity = Movement;

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash){
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate(){
        if(isDashing){
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    private IEnumerator Dash(){
        canDash = false;
        isDashing = true;
        if(Input.GetAxisRaw("Horizontal") > 0.1f){
            rb.velocity = new Vector2(transform.localScale.x * dashPow, 0f);
        }
        else if(Input.GetAxisRaw("Horizontal") < -0.1f){
            rb.velocity = new Vector2(-(transform.localScale.x * dashPow), 0f);
        }
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }
}
