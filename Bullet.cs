using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private  float speed = 500.0f;
    [SerializeField] private  float maxlifetime = 10.0f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Project(Vector2 direction)
    {
        rb.AddForce ( direction * this.speed );
        Destroy(this.gameObject, this.maxlifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
