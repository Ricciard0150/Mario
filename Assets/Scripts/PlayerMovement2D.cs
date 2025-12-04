using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed = 5f;
    public bool ridingYoshi = false;
    public Transform yoshiSitPoint;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (ridingYoshi) return; // Mario não pode mexer quando está montado

        float h = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(h * speed, rb.linearVelocity.y);
    }

    public void MountYoshi(Transform sitPoint)
    {
        ridingYoshi = true;
        yoshiSitPoint = sitPoint;

        rb.linearVelocity = Vector2.zero;
        rb.isKinematic = true; // Mario fica travado
        GetComponent<Collider2D>().enabled = false;
        transform.SetParent(sitPoint);
        transform.localPosition = Vector3.zero;
    }

    public void DismountYoshi()
    {
        ridingYoshi = false;

        rb.isKinematic = false;
        GetComponent<Collider2D>().enabled = true;
        transform.SetParent(null);
        transform.position += new Vector3(0.5f, 0.2f, 0); // sai do Yoshi
    }
}
