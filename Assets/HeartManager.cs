using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public int heartCount;
    public Text heartText;

    void Update()
    {
        heartText.text = heartCount.ToString();
    }
}
