using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneySystem : MonoBehaviour
{
    public GameObject[] itemObj;
    public int[] itemPrice;

    // Start is called before the first frame update

    public TextMeshProUGUI MoneyText;
    public GameObject Notext;
    public static int Money;

    private BattleManager _battleManager;
    public void Start()
    {
        Money = 0;
        _battleManager = FindObjectOfType<BattleManager>(); 
        StartCoroutine("addMoney");
    }

    private void Update()
    {
        MoneyText.text = " " + Money;
    }

    public void buy(int index)
    {
        int price = itemPrice[index];
        if (price > Money)
        {
            Notext.SetActive(true);
            Invoke("MoneyBuy", 0.5f);
            return;
        }
        Money -= price;
    }

    private void MoneyBuy()
    {
        Notext.SetActive(false);
    }



    public IEnumerator addMoney()
    {
        while(true)
        {
        
            yield return new WaitForSeconds(1f);
            Money += 1;
        }

    }

}
