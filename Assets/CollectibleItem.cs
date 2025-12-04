using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private void Start()
    {
        // só pra garantir que é trigger
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.isTrigger = true;
    }

    // Não precisa ter nada aqui.
    // A língua do Yoshi controla pegar e destruir.
}
