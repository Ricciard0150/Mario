using UnityEngine;

public class RotatingFallingPlaatform : MonoBehaviour
{
    public Transform visual;
    public Rigidbody2D top;
    public float rotationSpeed = 30f;
    public float radius = 2f;

    private float angle = 0f;
    public Vector2 platformVelocity { get; private set; }
    private Vector2 lastPos;

    void Start()
    {
        lastPos = top.position;
    }

    void FixedUpdate()
    {
        angle += rotationSpeed * Time.fixedDeltaTime;

        if (visual != null)
            visual.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime);

        if (top != null)
        {
            float rad = angle * Mathf.Deg2Rad;
            Vector2 center = transform.position;
            Vector2 targetPos = center + new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;
            top.MovePosition(targetPos);

            platformVelocity = (top.position - lastPos) / Time.fixedDeltaTime;
            lastPos = top.position;
        }
    }
}
