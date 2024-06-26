using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    /*ACLARACIÓN:
     Este script es una mezcla de lo que en nu momento fueron dos scripts, el script
     UIManager y el script ObjectManager.
     Tuve que combinarlos para asegurarme de que DeactivateAll() se ejecute *antes* de 
     WritePreciosEnTexts(), porque como estaba antes se estaba ejecutando WritePreciosEnTexts(), 
     haciendo que la UI muestre precios de productos que no son los activos.*/

    public GameObject[] objects;
    public InputField input;
    int resultado;
    public Text txtP1; public Text txtP2;
    public GameObject notiPanel;
    public Text txtRespuesta; //correcto/incorrecto
    byte currentP; //qué precio hay que setear ahora

    int rNum1; //porque voy a tener que referenciarlos para en AddRandomObjs()
    int rNum2;

    // Start is called before the first frame update
    void Start()
    {
        DeactivateAll();
        AddRandomObjs();
        WritePreciosEnTexts();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckResp()
    {
        notiPanel.SetActive(true);
        if (input.text == $"{resultado}")
        {
            //Debug.Log("correcto");
            txtRespuesta.text = "¡Correcto!";
        }
        else
        {
            txtRespuesta.text = "Incorrecto...";
        }
    }

    private void WritePreciosEnTexts()
    {
        currentP = 1;
        //GameObject[] allProductos = GameObject.FindGameObjectsWithTag("tagProducto");
        //for (int i = 0; i < allProductos.Length; i++)
        //{
        //    if (allProductos[i].activeInHierarchy == true)
        //    {
        //        Producto producto = allProductos[i].GetComponent<Producto>();
        //        Debug.Log(producto.name);
        //        if (currentP == 1)
        //        {
        //            txtP1.text = $"${producto.valorProducto}";
        //            currentP++;
        //        }
        //        else if (currentP == 2)
        //        {
        //            txtP2.text = $"${producto.valorProducto}";
        //            currentP++;
        //        }
        //        resultado += producto.valorProducto;
        //    }
        //}

        Producto producto1;
        producto1 = objects[rNum1].GetComponent<Producto>();
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

    void AddRandomObjs()
    {
        rNum1 = Random.Range(0, objects.Length);
        objects[rNum1].SetActive(true);
        objects[rNum1].transform.position = new Vector3(-7.16F, 0.37F, 0); //La ubicación que le puso Félix al modelo "Mayer_Ramiro_48792120"


        rNum2 = Random.Range(0, objects.Length);
        objects[rNum2].SetActive(true);
        objects[rNum2].transform.position = new Vector3(-1.91F, 0.48F, -0.82F); //La ubicación que le puso Félix al modelo "Corsunsky Gayá_Manuel_48592035"
    }

    public void ClickOtraVez()
    {
        DeactivateAll();
        AddRandomObjs();
        WritePreciosEnTexts();
        notiPanel.SetActive(false);
    }
}
