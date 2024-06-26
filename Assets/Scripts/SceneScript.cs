using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    /*ACLARACIÓN:
     Este script es una mezcla de lo que en nu momento fueron dos scripts, el script
     UIManager y el script ObjectManager.
     Tuve que combinarlos para asegurarme de que DeactivateAll() se ejecute *antes* de 
     WritePreciosEnTexts(), porque como estaba antes se estaba ejecutando WritePreciosEnTexts(), 
     haciendo que la UI muestre precios de productos que no son los activos.
                                    ---
    La consigna dice: "Si el input está vacío, se muestra un panel con la leyenda 
    “Debes ingresar un resultado” con un botón que permite cerrar el panel. 
    Si contiene un valor, se chequea que la cuenta sea correcta y se muestra el Panel de 
    Notificaciones indicando si el resultado es correcto o incorrecto."
    
    Según lo entendimos en ningún momento se prohíbe reciclar el panel de notificaciones
    para cuando una respuesta está vacía.*/

    public GameObject[] objects;
    public InputField input;
    int resultado;
    public Text txtP1; public Text txtP2;
    public GameObject notiPanel;

    public Text txtRespuesta; 
    // Texto del notiPanel que dice "¡Correcto!", "Incorrecto..." o "Debes ingresar un resultado."

    int rNum1; int rNum2;
    //a nivel clase porque voy a tener que referenciarlos para en AddRandomObjs()

    public GameObject btnOK;
    /*el botón OK del notiPanel reciclado si la respuesta está vacía.
    Intenté hacerlo de tipo Button pero no tenía ActiveInHierarchy así que no podía
    desactivarlo cuando la respuesta no está vacía.*/

    public GameObject[] btnsNE; /*Los botones que deben ser desactivados si vamos a reciclar el 
                                notiPanel para respuesta vacía.*/

    void Start()
    {
        DeactivateAll();
        AddRandomObjs();
        WritePreciosEnTexts();
    }

    public void CheckResp()
    {
        notiPanel.SetActive(true);
        if (input.text == $"{resultado}")
        {
            txtRespuesta.text = "¡Correcto!";
            btnOK.SetActive(false);
            btnsNE[0].SetActive(true);
            btnsNE[1].SetActive(true);
        }
        else if(input.text == string.Empty) 
            //la consigna no decía hacer un panel nuevo, y reciclar es sano para el planeta
        {
            txtRespuesta.text = "Debes ingresar un resultado.";
            btnOK.SetActive(true);
            btnsNE[0].SetActive(false);
            btnsNE[1].SetActive(false);
        }
        else
        {
            txtRespuesta.text = "Incorrecto...";
            btnOK.SetActive(false);
            btnsNE[0].SetActive(true);
            btnsNE[1].SetActive(true);
        }
    }

    private void WritePreciosEnTexts() //+ asignar el resultado correcto
    {
        Producto producto1;
        producto1 = objects[rNum1].GetComponent<Producto>();
        txtP1.text = $"${producto1.valorProducto}";

        Producto producto2;
        producto2 = objects[rNum2].GetComponent<Producto>();
        txtP2.text = $"${producto2.valorProducto}";

        resultado = producto1.valorProducto + producto2.valorProducto;
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

        if (btnOK.activeInHierarchy == true)
        {
            btnOK.SetActive(false);
        }

        else if (btnsNE[0].activeInHierarchy == false && btnsNE[1].activeInHierarchy== false)
        {
            btnsNE[0].SetActive(true);
            btnsNE[1].SetActive(true);
        }

        notiPanel.SetActive(false);
    }

    void AddRandomObjs()
    {
        rNum1 = Random.Range(0, objects.Length);
        objects[rNum1].SetActive(true);
        objects[rNum1].transform.position = new Vector3(-7.16F, 0.37F, 0); //La ubicación que le puso Félix al modelo "Mayer_Ramiro_48792120"
        Debug.Log(objects[rNum1].name);

        rNum2 = Random.Range(0, objects.Length);
        objects[rNum2].SetActive(true);
        objects[rNum2].transform.position = new Vector3(-1.91F, 0.48F, -0.82F); //La ubicación que le puso Félix al modelo "Corsunsky Gayá_Manuel_48592035"
        Debug.Log(objects[rNum2].name);
    }

    public void ClickOtraVez()
    {
        DeactivateAll();
        AddRandomObjs();
        WritePreciosEnTexts();
    }

    public void ClickOK()
    {
        notiPanel.SetActive(false);
    }

    public void LoadSeleccionarJuegos()
    {
        SceneManager.LoadScene("SeleccionarJuegos");
    }
}
