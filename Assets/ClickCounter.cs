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
        tmp.text = "Feathers: " + NumberFormat(manager.feathers);

    }

    private string NumberFormat(int number){
        if (number >= 1e12){
            return (number/ 1e12).ToString("0.##") + "T";
        } else if (number >= 1e9){
            return (number/ 1e9).ToString("0.##") + "B";
        } else if (number >= 1e6){
            return (number/ 1e6).ToString("0.##") + "M";
        } else if (number >= 1e3){
            return (number/ 1e3).ToString("0.##") + "K";
        } else {
            return number.ToString("0");
        }
    }
}
