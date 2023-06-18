using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Coins _coins;
    public static GameManager instance;
    private int coins;

    [SerializeField] private GameObject TextGameObject;
    [SerializeField]private TextMeshProUGUI TextAnimation;
    private bool isRecogiendoMonedas = false;
    private int monedasAnimation;
    

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } 
        else 
        {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _coins = FindObjectOfType<Coins>();
    }
    
    public void SumCoin()
    {
        _coins.NumberCoins++;
        AnimationText();
    }
    
    
    

    public void AnimationText()
    {
        TextGameObject.SetActive(true);
        TextAnimation.text = "+ " + (++monedasAnimation);
        isRecogiendoMonedas = true;

        StartCoroutine(DenableAnimationText());
    }

    private IEnumerator DenableAnimationText()
    {
        float time = 0f;  // Mover la declaración y asignación de time fuera de la corrutina

        if (TextGameObject.activeSelf)
        {
            while (time < 5f)  // Utilizar un bucle while para incrementar time hasta que alcance 5
            {
                time += Time.deltaTime;
                yield return null;  // Esperar un frame antes de continuar el bucle
            }

            TextGameObject.SetActive(false);

            if (!isRecogiendoMonedas)
            {
                monedasAnimation = 0;
            }
        }

        isRecogiendoMonedas = false;
    }


}
