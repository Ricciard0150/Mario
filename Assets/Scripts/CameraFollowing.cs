using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;       // O player ou trailer
    public Vector3 offset;         // Dist�ncia da c�mera em rela��o ao alvo
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(target); // Opcional: se quiser que a c�mera "olhe" para o alvo
    }
}
