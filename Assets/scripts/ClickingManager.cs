using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class ClickingManager : MonoBehaviour
{
    public int clicks = 0;
    public int feathers = 0;

    public int upgradeMultiplier = 0;
    public int numberBought = 1;

    public static ClickingManager instance;

    public AudioSource audioSource;

    void Awake(){
        audioSource = gameObject.GetComponent<AudioSource>();
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void manualClick() {
        this.Click(numberBought * (int)Math.Pow(2.0, upgradeMultiplier));
    }

    public void Click(int amount){
        clicks++;
        audioSource.Play();
        feathers += amount;
    }
}
