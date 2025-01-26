using UnityEngine;

public class ClickingManager : MonoBehaviour
{
    public int clicks = 0;
    public int feathers = 0;

    public int multiplier = 1;

    public static ClickingManager instance;

    void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void Click(int amount){
        clicks++;
        feathers += amount * multiplier;
    }
}
