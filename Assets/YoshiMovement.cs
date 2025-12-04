using UnityEngine;

public class YoshiMovement : MonoBehaviour
{
    public Transform mountPoint;
    private GameObject mario;
    private PlayerMovement2D marioMovement;
    public bool mounted = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !mounted)
        {
            mario = col.gameObject;
            marioMovement = mario.GetComponent<PlayerMovement2D>();

            // Desativa movimento do Mario
            marioMovement.enabled = false;

            // Gruda Mario no Yoshi
            mario.transform.SetParent(mountPoint);
            mario.transform.localPosition = Vector3.zero;


            Rigidbody2D rb = mario.GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 0;

            mounted = true;
        }
    }

    void Update()
    {
        if (mounted && Input.GetKeyDown(KeyCode.Space))
        {
            Dismount();
        }
    }

    void Dismount()
    {
        // solta o Mario
        mario.transform.SetParent(null);


        Rigidbody2D rb = mario.GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;


        marioMovement.enabled = true;


        mario.transform.position += Vector3.up * 0.5f;

        mounted = false;
    }
}