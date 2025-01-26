using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public int BuyMult = 1;

    BuyButton[] buttons;

    void Awake(){
        buttons = transform.GetComponentsInChildren<BuyButton>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ChangeQuantity(int amount){
        BuyMult = amount;
        foreach (BuyButton b in buttons){
            b.UpdateCost();
        }
    }
}
