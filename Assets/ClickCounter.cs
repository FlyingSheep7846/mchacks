using TMPro;
using UnityEngine;

public class ClickCounter : MonoBehaviour
{
    [SerializeField] ClickingManager manager;
    private TextMeshProUGUI tmp;

    void Awake(){
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = $"{manager.feathers}";
    }
}
