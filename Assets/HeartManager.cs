using UnityEngine;
using UnityEngine.UI;
//this lets the game know that when the heart is triggered then it should increase the number counter in the corner
public class HeartManager : MonoBehaviour
{
    public int heartCount;
    public Text heartText;

    void Update()
    {
        //this is specificly to the heart text in the corner
        heartText.text = heartCount.ToString();
    }
}
