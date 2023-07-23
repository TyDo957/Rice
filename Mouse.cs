using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float size = 1f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    [SerializeField] private  float speed = 50f;
    [SerializeField] private  float maxlifetime = 5f;

    [SerializeField] private  Sprite[] sprites;
    private SpriteRenderer spriteRender;
    private Rigidbody2D rb;

    private void Awake()
    {
        spriteRender= GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        this.CheckSprites();
   
    }
   private void CheckSprites()
    {
        spriteRender.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
        this.transform.localScale = Vector3.one * this.size;

        rb.mass = this.size;

    }
    public void SetTrajector(Vector2 direction)
    {
        rb.AddForce(direction * this.speed );
        Destroy(this.gameObject, this.maxlifetime);
    }
    private void OnCollisionEnter2D(Collision2D beta)
    {
        if ( beta.gameObject.tag == "Bullet")
        {
            if((this.size * 0.5f) <= this.minSize)
            {
                this.Create();
                
            }
            Destroy(this.gameObject);
        }
    }
    private void Create()
    {
         Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Mouse half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajector(Random.insideUnitCircle.normalized *  this.speed);
    }
   

    
     
}
