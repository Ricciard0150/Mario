using UnityEngine;

public class PlayerPlatformAttachment : MonoBehaviour
{
    public Rigidbody2D rb;
    public RotatingFallingPlaatform platformScript;

    private bool onPlatform = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.transform == platformScript.top)
        {
            // s� se estiver vindo por cima
            foreach (var point in col.contacts)
            {
                if (point.normal.y > 0.5f)
                {
                    onPlatform = true;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.transform == platformScript.top)
            onPlatform = false;
    }

    void FixedUpdate()
    {
        if (onPlatform)
        {
            // adiciona a velocidade da plataforma
            rb.linearVelocity += platformScript.platformVelocity;
        }
    }
}
