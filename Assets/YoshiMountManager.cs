using Unity.VisualScripting;
using UnityEngine;

public class YoshiMountManager : MonoBehaviour
{

public float speed = 4f;
public Transform sitPoint;

private PlayerMovement2D mario;
public  bool hasRider = false;

Rigidbody2D rb;

void Start()
{
    rb = GetComponent<Rigidbody2D>();
}

void Update()
{
    if (!hasRider) return;

    float h = Input.GetAxisRaw("Horizontal");
    rb.linearVelocity = new Vector2(h * speed, rb.linearVelocity.y);

    // Descer do Yoshi
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
        mario.DismountYoshi();
        hasRider = false;
    }
}

private void OnTriggerEnter2D(Collider2D col)
{
    if (!hasRider && col.CompareTag("Player"))
    {
        mario = col.GetComponent<PlayerMovement2D>();
        mario.MountYoshi(sitPoint);
        hasRider = true;
    }
}
}