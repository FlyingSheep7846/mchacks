using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    private Animator animator;
    private float lastClickTime = 0f;
    public float clickTimeout = 0.1f; // Time to reset to idle

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("ClickTimeout", Time.time - lastClickTime);
        
    }

    public void OnButtonClick()
    {
        // Trigger the clicking animation
        animator.SetTrigger("IsClicking");
        lastClickTime = Time.time; // Update last click time
        animator.SetFloat("ClickTimeout", 0f); // Reset the timeout parameter
    }
}