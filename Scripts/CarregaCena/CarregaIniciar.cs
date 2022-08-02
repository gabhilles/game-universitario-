using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregaIniciar : MonoBehaviour
{
   
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Joystick1Button9))

        {

            carregaCena1("Iniciar");
            print("apertei enter");
        }
    }


    public void carregaCena1(string Iniciar)

    {


        SceneManager.LoadScene(Iniciar);

    }
}
