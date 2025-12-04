using UnityEngine;

public class YoshiTongue : MonoBehaviour
{
    public Transform tongue;
    public float maxLength = 2f;
    public float speed = 8f;
    public Transform mouth;

    private bool extending = false;
    private bool retracting = false;
    private float currentLength = 0f;

    private GameObject caughtObj;

    void Start()
    {
        tongue.localScale = new Vector3(0f, 0.2f, 1);
    }

    void Update()
    {
        // Clique do mouse
        if (Input.GetMouseButtonDown(0) && !extending && !retracting)
        {
            extending = true;
        }

        if (extending)
        {
            currentLength += speed * Time.deltaTime;
            currentLength = Mathf.Min(currentLength, maxLength);

            tongue.localScale = new Vector3(currentLength, 0.2f, 1);
            tongue.position = mouth.position + transform.right * (currentLength / 2f) * transform.localScale.x;

            if (currentLength >= maxLength)
            {
                extending = false;
                retracting = true;
            }
        }

        if (retracting)
        {
            currentLength -= speed * Time.deltaTime;
            currentLength = Mathf.Max(currentLength, 0);

            tongue.localScale = new Vector3(currentLength, 0.2f, 1);
            tongue.position = mouth.position + transform.right * (currentLength / 2f) * transform.localScale.x;

            if (currentLength <= 0.05f)
            {
                retracting = false;
                tongue.localScale = new Vector3(0, 0.2f, 1);

                if (caughtObj)
                {
                    Destroy(caughtObj);
                    caughtObj = null;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (extending && col.CompareTag("Collectible"))
        {
            caughtObj = col.gameObject;
            caughtObj.transform.SetParent(tongue);
            caughtObj.transform.localPosition = new Vector3(currentLength, 0, 0);
        }
    }
}