using UnityEngine;

public class ButtonParticleEffect : MonoBehaviour
{
    public ParticleSystem clickEffect; // Assign your particle prefab in the Inspector
    [SerializeField] Transform particleParent;


    public void SpawnParticleEffect()
    {
        // Convert the button's position to world space
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world space
        Vector3 worldPosition;
            // Screen Space Overlay: Mouse position is already in screen space
            worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0f));

        // Instantiate the particle effect
        Destroy(
            Instantiate(clickEffect, worldPosition, Quaternion.identity, particleParent).gameObject,
            0.5f);
    }
}
