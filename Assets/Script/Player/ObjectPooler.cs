using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject preFab;
    public int poolSize = 10;
    private List<GameObject> pool;
    // Start is called before the first frame update
    void Start()
    {
        InitializePool();   
    }
    private void InitializePool()
    {
        pool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            CreateNewObj();
        }
    }
    public GameObject GetGameObject()
    {
        foreach(GameObject obj in pool)
        {
            //Check for inactive object
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        //If no, create new object for adding to pool
        return CreateNewObj();
    }
    private GameObject CreateNewObj()
    {
        GameObject obj = Instantiate(preFab, transform);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }
}
