using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lifes : MonoBehaviour
{
    [SerializeField] int lives;
    [SerializeField] private GameObject[] hearts;
    
    public int NumberLive
    {
        get => lives;
        set
        {
            lives = value;

            UpdateLives();
            RestLives();
            PlayerPrefs.SetInt("lives", lives);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            lives = hearts.Length;
            PlayerPrefs.SetInt("lives", lives);
        }
        else
        {
            lives = PlayerPrefs.GetInt("lives", 0);
        }
        
        UpdateLives();
        RestLives();
    }

    void UpdateLives()
    {

        switch (lives)
        {
            case 1: hearts[0].SetActive(true);
                break;
            case 2: hearts[1].SetActive(true);
                hearts[0].SetActive(true);
                break;
            case 3: hearts[2].SetActive(true);
                hearts[1].SetActive(true);
                hearts[0].SetActive(true);
                break;
            case >3: lives = 3;
                break;
        }
    }

    void RestLives()
    {
        switch (lives)
        {
            case <1: hearts[0].SetActive(false);
                SceneManager.LoadScene(0);
                break;
            case <2: hearts[1].SetActive(false); 
                     hearts[2].SetActive(false);

                break;
            case <3: hearts[2].SetActive(false);
                break;
        }

    }
    
}
