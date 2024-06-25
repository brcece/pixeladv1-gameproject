using UnityEngine;
using UnityEngine.UI;

public class playermovment : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce; // Z�plama kuvveti
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private int jumpCount; // Z�plama say�s�
    [SerializeField] private int maxJumps = 2; // Maksimum z�plama say�s�
    public Text Win;
    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Sol-sa� hareketi
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Z�plama
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            Jump();
        }

        // Animator ayarlar�
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
        anim.SetBool("fall", !grounded && body.velocity.y < 0); // D���� animasyonu tetikleyici
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce); // Z�plama kuvveti
        if (jumpCount == 0)
        {
            anim.SetTrigger("jump"); // �lk z�plama animasyonu tetikleyici
        }
        else if (jumpCount == 1)
        {
            anim.SetTrigger("doublejump"); // �ift z�plama animasyonu tetikleyici
        }
        jumpCount++;
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
            jumpCount = 0; // Z�plama say�s�n� s�f�rla
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (scorecounter.instance.currentScore >= 100)
    //    {
    //        if(collision.tag == "win")
    //        {

    //            Win.gameObject.SetActive(true);
    //        }
    //    }
        
        
        
    //}
}
