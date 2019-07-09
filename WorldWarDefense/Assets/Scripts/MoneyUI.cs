using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MoneyUI : MonoBehaviour{
    
    public Text moneyText;
    
    void Update(){
        moneyText.text = "R$ " + PlayerStats.Money.ToString();
    }
}
