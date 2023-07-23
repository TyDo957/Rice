using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletprefab; 
    [SerializeField] private float  thrustSpeed = 1.0f;  // tốc độ lực dẩy
    [SerializeField] private float  turnSpeed = 1.0f;   // tốc độ quay
    private float turnDirection;    // hướng rẽ
    private bool thursting;         // lực đẩy
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       this.Inputt();
       
    }
    private void FixedUpdate()
    {
       this.Canfocer();
    }
    private void Inputt()
    {
        thursting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);  // di chuyển mũi tên và đáp lưu :)
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))      
        {
            turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1.0f;
        }
        else
        {
            turnDirection = 0.0f;
        }
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            this.Shoot();
        }
         
    }
    private void Canfocer()
    {
        if (thursting)
        {
            rb.AddForce(this.transform.up * this.thrustSpeed); // addfocer lực đẩy vè phía trước
        }
        if (turnDirection != 0.0f)
        {
            rb.AddTorque(turnDirection * turnSpeed); // addtoque mô men xoắn , quay đối tượng
        }
    }
    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletprefab , this.transform.position , this.transform.rotation);
        bullet.Project(this.transform.up);
    }
    private void OnCollisionEnter2D(Collision2D beta)
    {
        if(beta.gameObject.tag == "Mouse")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
            this.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().PlayerDie();
        }
    }
}
