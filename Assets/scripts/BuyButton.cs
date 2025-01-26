using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ShopManager manager;
    [SerializeField] AutoClickerManager autoManager;
    private Button button;

    private AudioSource audioSource;

    [SerializeField] int type;
    [SerializeField] string buyType;
    private TextMeshProUGUI costText;
    private TextMeshProUGUI ownedText;

    [SerializeField] GameObject tooltip;
    [SerializeField] float tooltipOffset;


    public int cost;
    public int costChange; 
    public int totalCost;

    void Awake(){
        manager = transform.root.GetComponentInChildren<ShopManager>();
        button = GetComponent<Button>();

        costText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        ownedText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        audioSource = gameObject.GetComponent<AudioSource>();

        costText.text = textAmount();
        if (buyType == "upgrade") {
            ownedText.text = autoManager.upgradeMult[type].ToString();
        }
        else {
            ownedText.text = autoManager.autoClickers[type].ToString();
        }
    }

    void Start(){
        
    }

    void Update(){
        button.interactable = ClickingManager.instance.feathers >= totalCost;
    }

    public void BuyAutoClicker(){
        ClickingManager.instance.feathers -= totalCost;
        autoManager.BuyAutoClicker(type, manager.BuyMult, buyType);
        if (buyType == "upgrade") {
            ownedText.text = autoManager.upgradeMult[type].ToString();
        }
        else {
            ownedText.text = autoManager.autoClickers[type].ToString();
        }

        if (type == 0) { // is "you"
            if (buyType == "upgrade") { // increase multiplier
                ClickingManager.instance.upgradeMultiplier += manager.BuyMult;
            }
            else { // increase number of 'you's
                ClickingManager.instance.numberBought += manager.BuyMult;
            }
        }
        
        costText.text = textAmount();
        cost += manager.BuyMult * costChange;

        audioSource.Play();

    }

    public void UpdateCost(){
        costText.text = textAmount();
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition - new Vector2(tooltipOffset,0);

        tooltip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.SetActive(false);
    }
}
