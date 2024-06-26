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

    void DeactivateAll()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].activeInHierarchy == true)
            {
                objects[i].SetActive(false);
            }
        }
    }
    void addRandomObjs()
    {
        int rNum1 = Random.Range(0, objects.Length);
        objects[rNum1].SetActive(true);
        objects[rNum1].transform.position = new Vector3(-7.16F, 0.37F, 0); //La ubicación que le puso Félix al modelo "Mayer_Ramiro_48792120"



        int rNum2 = Random.Range(0, objects.Length);
        objects[rNum2].SetActive(true);
        objects[rNum2].transform.position = new Vector3(-1.91F, 0.48F, -0.82F); //La ubicación que le puso Félix al modelo "Corsunsky Gayá_Manuel_48592035"
    }
}
