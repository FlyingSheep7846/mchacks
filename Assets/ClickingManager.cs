using UnityEngine;

public class ClickingManager : MonoBehaviour
{
    public int clicks = 0;
    public int feathers = 0;

    public int multiplier = 1;

    public void Click(){
        clicks++;
        feathers += multiplier;
    }
}
