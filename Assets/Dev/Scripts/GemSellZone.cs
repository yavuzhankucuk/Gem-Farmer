using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GemSellZone : MonoBehaviour
{    
    GameObject player;
    GameObject UIManager;
    GemStack Stack;
    PlayerStats Stats;
    UIManager manager;
    public bool isPlayerInSellZone = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UIManager = GameObject.FindGameObjectWithTag("UIManager");
        Stack = player.GetComponent<GemStack>();
        Stats = player.GetComponent<PlayerStats>();
        manager = UIManager.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInSellZone = true;
            StartCoroutine(SellGems());            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInSellZone = false;
        }
    }

    private IEnumerator SellGems()
    {
        while(isPlayerInSellZone && Stack.gemStack.Count>0)
        {
            for (int index = Stack.gemStack.Count - 1; index >= 0; index--)
            {
                Debug.Log("buraya girdi");
                GemCollider collider;
                float price;
                GameObject current = Stack.gemStack[index];
                collider = current.GetComponent<GemCollider>();
                price = collider.salePrice;
                Stats.RecalculateMoney(price);
                if (current.name == "Gem_Pink(Clone)")
                {
                    Stats.pinkGemCount++;
                    string pink = Stats.pinkGemCount.ToString();
                    manager.textPinkGemCount.text = "Pink Gems Collected: "+pink;
                }
                else if (current.name == "Gem_Yellow(Clone)")
                {
                    Stats.yellowGemCount++;
                    string yellow = Stats.yellowGemCount.ToString();
                    manager.textYellowGemCount.text = "Yellow Gems Collected: " + yellow;
                }
                else if(current.name == "Gem_Green(Clone)")
                {
                    Stats.greenGemCount++;
                    string green = Stats.greenGemCount.ToString();
                    manager.textGreenGemCount.text = "Green Gems Collected: " + green;                   
                }
                Stack.gemStack.Remove(current);
                Destroy(current);
                yield return new WaitForSeconds(0.1f);
            }
        }        
    }
}
