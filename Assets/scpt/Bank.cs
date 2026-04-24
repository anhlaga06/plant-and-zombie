using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    private int money;
    // Start is called before the first frame update
    private TextMeshProUGUI getTextUI()
    {
        return transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    public void SetNumber(int number)
    {
        Debug.Log("bank: " + number);
        money = number;
        getTextUI().text = number.ToString();
    }

    public int GetMoney() {
        return money;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
