using UnityEngine;
using UnityEngine.SceneManagement; //for scene loading

public class StartGame : MonoBehaviour
{

    [SerializeField] Animator anim;

    public void StartAnim(){
        anim.SetTrigger("Start");
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(2); //load game scene
    }
}
