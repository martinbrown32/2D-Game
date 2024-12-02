using UnityEngine;

public class HeartCollector : MonoBehaviour

{
public HeartManager hm;

void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Heart"))
         {
            Destroy(other.gameObject);
            hm.heartCount++;
         }
    }
}
