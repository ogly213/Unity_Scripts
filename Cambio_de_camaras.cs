using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambio_de_camaras : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    private int contador;
    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        cam4.enabled = false;
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            contador++;
            switch (contador)
            {
                case 0 :
                    cam1.enabled = true;
                    cam2.enabled = false;
                    cam3.enabled = false;
                    cam4.enabled = false;
                    break;
                case 1:
                    cam1.enabled = false;
                    cam2.enabled = true;
                    cam3.enabled = false;
                    cam4.enabled = false;
                    break;
                case 2:
                    cam1.enabled = false;
                    cam2.enabled = false;
                    cam3.enabled = true;
                    cam4.enabled = false;
                    break;
                case 3:
                    cam1.enabled = false;
                    cam2.enabled = false;
                    cam3.enabled = false;
                    cam4.enabled = true;
                    break;
                case 4:
                    cam1.enabled = true;
                    cam2.enabled = false;
                    cam3.enabled = false;
                    cam4.enabled = false;
                    contador = 0;
                    break;
            }
        }
    }
}
