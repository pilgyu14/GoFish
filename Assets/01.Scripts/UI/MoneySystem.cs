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
    public int Money;

    void Start()
    {
        Money = 0;
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



    IEnumerator addMoney()
    {
        yield return new WaitForSeconds(1f);
        Money += 1;
        StartCoroutine("addMoney");
    }

}
