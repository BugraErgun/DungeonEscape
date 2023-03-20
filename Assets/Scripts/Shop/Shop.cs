using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] public int currentSelectedItem;
    public int currentItemCost;
    public Player player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            if (player != null)
            {
                UIManager.UIinstance.OpenShop(player.diamonds);
            }
            shopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }
    public void SelectItem(int item)
    {
        
        Debug.Log(" " + item);
        switch (item)
        {
            case 0:
                UIManager.UIinstance.UpdateShopSelection(85);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
                case 1:
                UIManager.UIinstance.UpdateShopSelection(-25);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2:
                UIManager.UIinstance.UpdateShopSelection(-135);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }
    public void BuyItem()
    {   
        if (player.diamonds >= currentItemCost)
        {
            if (currentSelectedItem == 2)
            {
                GameManager.Instance.hasKeyToCastle = true;
            }
            player.diamonds -= currentItemCost;
            shopPanel.SetActive(false);
        }
        else
        {
            shopPanel.SetActive(false);
        }
    }
}
