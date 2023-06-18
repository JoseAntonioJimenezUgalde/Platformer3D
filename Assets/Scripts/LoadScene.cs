using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] int scene;

   
    
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Scens(scene);
        }
    }

    void Scens(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
