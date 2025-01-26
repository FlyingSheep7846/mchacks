using UnityEngine;
using UnityEngine.SceneManagement; //for scene loading

public class StartGame : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene(2); //load game scene
    }
}
