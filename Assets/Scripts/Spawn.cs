using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField] private List<GameObject> obstacles;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstanceGameObjects", 2, 5);
    }

    private void InstanceGameObjects()
    {
        GameObject ObjectInstanciate = Pooling.instance.ReturnObstacle();
        ObjectInstanciate.transform.position = transform.position;
    }
}
