using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipButton : MonoBehaviour
{
    public Sprite ship;
    public string shipName;
    public int shipCost;
    public GameObject sr;
    public Text shipNameText;
    public Text shipCostText;
    public GameObject costIcon;
    public bool shopIcon = false;
    public bool apply = false;
    private GameObject player;
    private GameObject gm;
    private bool owned = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gm = GameObject.FindGameObjectWithTag("GM");
    }
    
    void OnValidate()
    {
        if(apply == true)
        {
            sr.GetComponent<Image>().sprite = ship;
            shipNameText.text = shipName;
            shipCostText.text = "" + shipCost;
            costIcon.SetActive(shopIcon);
            apply = false;
        }
    }

    public void BuyShip()
    {
        if (owned == false && GM.playerCash >= shipCost)
        {
            owned = true;
            shipCostText.text = "Owned";
            GM.playerCash -= shipCost;
            gm.SendMessage("UpdateCash");
        }
    }
    
    public void SetPlayerSprite()
    {
        player.SendMessage("SetSprite", ship);
    }

}
