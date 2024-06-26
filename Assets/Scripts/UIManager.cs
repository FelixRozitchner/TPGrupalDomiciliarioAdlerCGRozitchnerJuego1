using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField input;
    int resultado;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckResp()
    {
        GameObject[] allProductos = GameObject.FindGameObjectsWithTag("tagProducto");
        for (int i = 0; i < allProductos.Length; i++)
        {
            if (allProductos[i].activeInHierarchy == true)
            {
                Producto producto = allProductos[i].GetComponent<Producto>();
                resultado += producto.valorProducto;
            }
        }

        if(input.text == Convert.ToString(resultado))
        {
            Debug.Log("correcto");
        }
    }
}
