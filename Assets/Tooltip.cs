using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_title;
    [SerializeField] private TextMeshProUGUI m_desc;

    // void Awake(){
    //     m_title = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    //     m_desc = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        
    // }


    public void UpdateText(string title, string desc){
        m_title.text = title;
        m_desc.text = desc;
    }
}
