using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    private ShopManager manager;
    [SerializeField] AutoClickerManager autoManager;
    private Button button;

    [SerializeField] int type;

    private TextMeshProUGUI costText;
    private TextMeshProUGUI ownedText;


    public int cost;
    public int costChange; 
    public int totalCost;

    void Awake(){
        manager = transform.root.GetComponentInChildren<ShopManager>();
        button = GetComponent<Button>();

        costText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        ownedText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    void Start(){
        costText.text = "Cost: " + textAmount();
    }

    void Update(){

        button.interactable = ClickingManager.instance.feathers >= totalCost;
    }

    public void BuyAutoClicker(){
        autoManager.BuyAutoClicker(type, manager.BuyMult, buyType);
        ClickingManager.instance.feathers -= totalCost;
        costText.text = "Cost: " + textAmount();
        cost += manager.BuyMult * costChange;

        ownedText.text = autoManager.autoClickers[type].ToString();
    }

    public void UpdateCost(){
        costText.text = "Cost: " + textAmount();
    }

    public int CostAmount(){
        int n = manager.BuyMult;
        int number = cost * n + costChange * (n * (n-1) )/ 2; 

        totalCost = number;

        return number;
    }

    private string textAmount(){

        int number = CostAmount();

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
