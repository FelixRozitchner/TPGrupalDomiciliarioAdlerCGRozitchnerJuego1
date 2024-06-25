using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJECTMANAGER : MonoBehaviour
{
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        DeactivateAll();
        addRandomObjs();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void DeactivateAll()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if(objects[i].activeInHierarchy == true)
            {
                objects[i].SetActive(false);
            }
        }
    }
    void addRandomObjs()
    {
        int rNum1 = Random.Range(0, objects.Length);
        objects[rNum1].SetActive(true);

        int rNum2 = Random.Range(0, objects.Length);
        while(rNum1 == rNum2)
        {
            rNum2 = Random.Range(0, objects.Length);
        }
        objects[rNum2].SetActive(true);
    }
}
