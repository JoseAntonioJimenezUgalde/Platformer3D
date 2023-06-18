using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour
{
    [SerializeField] int coins;
    [SerializeField] TextMeshProUGUI TextMeshPro;

    public int NumberCoins
    {
        get => coins;
        set
        {
            coins = value;
            TextMeshPro.text = "= " + coins.ToString();
            PlayerPrefs.SetInt("coins", coins);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        if (SceneManager.GetActiveScene().name == "SampleScene1")
        {
            coins = PlayerPrefs.GetInt("coins", 0);
        }
        TextMeshPro.text = coins.ToString();

    }

   
}
