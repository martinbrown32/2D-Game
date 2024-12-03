using UnityEngine;
//this will let the camera know that a new room has been entered and that ot should them switch to focusing on the new room
public class Enterance : MonoBehaviour
{
    [SerializeField] private Transform previousArea;
    [SerializeField] private Transform nextArea;
    [SerializeField] private CameraControll cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this lets it know that if a player hits it then the collision is activated and the camera moves
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            cam.MoveToNewRoom(nextArea);
            else
            cam.MoveToNewRoom(previousArea);
        }
    }
}
