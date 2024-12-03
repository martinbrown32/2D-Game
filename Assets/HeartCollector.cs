using UnityEngine;

public class HeartCollector : MonoBehaviour
//this lets the heart know that it has been entered
{
public HeartManager hm;

void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Heart"))
         {
            //this lets the game know that when the heart is touched then it is to be destroyed so that the 
            //player cant keep running though the heart again and again
            Destroy(other.gameObject);
            hm.heartCount++;
         }
    }
}
