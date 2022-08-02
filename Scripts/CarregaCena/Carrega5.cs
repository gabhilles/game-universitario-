using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carrega5 : MonoBehaviour
{

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Joystick1Button9))

        {

            carregaCena1("nomeCena");
            print("apertei pra passar pro nivel 5");
        }
    }


    public void carregaCena1(string nomeCena)

    {


        SceneManager.LoadScene(5);

    }
}
