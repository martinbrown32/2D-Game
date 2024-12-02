using UnityEngine;

public class Enterance : MonoBehaviour
{
    [SerializeField] private Transform previousArea;
    [SerializeField] private Transform nextArea;
    [SerializeField] private CameraControll cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            cam.MoveToNewRoom(nextArea);
            else
            cam.MoveToNewRoom(previousArea);
        }
    }
}
