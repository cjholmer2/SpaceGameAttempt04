using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public static int numberOfEnemies = 5;
    public Text numberOfEnemiesText;

    // Use this for initialization
    void Start ()
    {
        numberOfEnemiesText = GameObject.FindGameObjectWithTag("NumberOfEnemies").GetComponent<Text>();
        UpdateEnemies();
    }
	
    public void UpdateEnemies()
    {
        numberOfEnemiesText.text = "" + numberOfEnemies;
    }

    void OnValidate()
    {
        if(numberOfEnemiesText == null)
        {
            numberOfEnemiesText = GameObject.FindGameObjectWithTag("NumberOfEnemies").GetComponent<Text>();
        }
        UpdateEnemies();
    }
}
