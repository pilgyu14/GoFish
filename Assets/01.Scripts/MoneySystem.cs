using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneySystem : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI MoneyText;
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



    IEnumerator addMoney()
    {
        yield return new WaitForSeconds(1f);
        Money += 3;
        StartCoroutine("addMoney");
    }

}
