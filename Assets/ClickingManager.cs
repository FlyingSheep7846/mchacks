using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class ClickingManager : MonoBehaviour
{
    public int clicks = 0;
    public int feathers = 0;

    public int multiplier = 1;

    public static ClickingManager instance;

    public AudioSource audioSource;

    void Awake(){
        audioSource = gameObject.GetComponent<AudioSource>();
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void Click(int amount){
        clicks++;
<<<<<<< Updated upstream
        feathers += amount * multiplier;
=======
        audioSource.Play();
        feathers += amount;
>>>>>>> Stashed changes
    }
}
