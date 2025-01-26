using System;
using UnityEngine;

public class AutoClickerManager : MonoBehaviour
{
    public int[] autoClickers = new int[6];
    public int[] upgradeMult = new int[6];

    private float[] clickerTimers = {0,0,0,0,0};
    private float[] clickerIntervals = {1f, 0.5f, 0.2f, 0.1f, 0.06f};

    [SerializeField] ClickingManager manager;

    void FixedUpdate(){
        for (int i = 0; i<5; i++){

            if (autoClickers[i+1] == 0) continue;
            
            clickerTimers[i] += Time.fixedDeltaTime;
            if (clickerTimers[i] >= clickerIntervals[i]){
                
                manager.Click(autoClickers[i+1] * (int)Math.Pow(2.0, upgradeMult[i+1]));
                clickerTimers[i] = 0;
                
            }
        }
    }

    public void BuyAutoClicker(int i, int quantity, string buyType){
        if(buyType == "upgrade"){
            upgradeMult[i] += quantity;
            
        } else {
            autoClickers[i] += quantity;
        }        
        // implement buy
    }


}
