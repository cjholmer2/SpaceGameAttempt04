using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public static int numberOfEnemies = 0;
    public Text numberOfEnemiesText;
    public static Sprite playerShip;
    public static int playerCash;
    public Text playerCashText;

    // Use this for initialization
    void Start ()
    {
        //numberOfEnemiesText = GameObject.FindGameObjectWithTag("NumberOfEnemies").GetComponent<Text>();
        UpdateEnemies();
        //playerCashText = GameObject.FindGameObjectWithTag("PlayerCash").GetComponent<Text>();
        UpdateCash();
    }
	
    public void UpdateEnemies()
    {
        //numberOfEnemiesText.text = "" + numberOfEnemies;
    }

    public void UpdateCash()
    {
       //playerCashText.text = "" + playerCash;
    }
}
