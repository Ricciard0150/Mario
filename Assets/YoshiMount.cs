using UnityEngine;

public class YoshiMount : MonoBehaviour
{
    public Transform saddle;
    public GameObject yoshi;
    public YoshiMovement yoshimovement;



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerMovement2D pm = col.GetComponent<PlayerMovement2D>();

            if (pm != null)
            {
                pm.hasRider;
                col.transform.position = saddle.position;
                col.transform.SetParent(yoshi.transform);

                yoshi.GetComponent<YoshiMovement>().hasMario = true;
            }
        }
    }
}
