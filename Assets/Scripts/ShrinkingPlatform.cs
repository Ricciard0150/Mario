using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
    public Vector3 originalScale = Vector3.one; // escala inicial
    public Vector3 targetScale = new Vector3(0.2f, 0.2f, 1f); // escala mínima (quando encolher)
    public float shrinkSpeed = 2f;    // quão rápido encolhe
    public float expandSpeed = 2f;    // quão rápido volta ao normal (opcional)
    public bool shrinkOnCollision = true;
    public bool expandAfterDelay = false;
    public float delayBeforeExpand = 1f;

    private bool shrinking = false;
    private bool expanding = false;
    private float expandTimer = 0f;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (shrinking)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, shrinkSpeed * Time.deltaTime);

            if (transform.localScale == targetScale)
            {
                shrinking = false;
                if (expandAfterDelay)
                {
                    expandTimer = delayBeforeExpand;
                }
            }
        }
        else if (expanding)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, originalScale, expandSpeed * Time.deltaTime);

            if (transform.localScale == originalScale)
            {
                expanding = false;
            }
        }

        if (expandAfterDelay && expandTimer > 0f)
        {
            expandTimer -= Time.deltaTime;
            if (expandTimer <= 0f)
            {
                expanding = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (shrinkOnCollision)
        {
            // Você pode checar tag ou collider do jogador aqui
            if (col.collider.CompareTag("Player"))
            {
                shrinking = true;
                expanding = false;
            }
        }
    }

    // Opcional: se quiser que ela volte ao normal quando o player sair
    void OnCollisionExit2D(Collision2D col)
    {
        if (shrinkOnCollision)
        {
            if (col.collider.CompareTag("Player") && !expandAfterDelay)
            {
                expanding = true;
                shrinking = false;
            }
        }
    }
}
