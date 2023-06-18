using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public static Pooling instance;
    [SerializeField] private GameObject[] obstacle;
    private int numberOfObstacle = 10;
    [SerializeField] private List<GameObject> obstacleList;

    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
            AddObstacleToList(numberOfObstacle);
            
    }

    public void AddObstacleToList(int foods)
    {
        for (int i = 0; i < foods; i++)
        {
            GameObject obstacleInstanciate = Instantiate(obstacle[i]);
            obstacleInstanciate.SetActive(false);
            obstacleList.Add(obstacleInstanciate);
            obstacleInstanciate.transform.parent = transform;
        }
    }
    public GameObject ReturnObstacle()
    {
        int RandomObstacle = Random.Range(0, obstacleList.Count);
        
        if (!obstacleList[RandomObstacle].activeSelf)
        {
            obstacleList[RandomObstacle].SetActive(true);
            return obstacleList[RandomObstacle].gameObject;
        }
        else
        {
            for (int i = 0; i < obstacleList.Count; i++)
            {
                if (!obstacleList[i].activeSelf)
                {
                    obstacleList[i].SetActive(true);
                    return obstacleList[i].gameObject;
                }
            }
        }
        return null;
    }
    
}
