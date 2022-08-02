using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregaFinal : MonoBehaviour
{

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Joystick1Button9))

        {

            carregaCena1("Final");
            print("apertei pra passar pro FINAL");
        }
    }


    public void carregaCena1(string Final)

    {


        SceneManager.LoadScene(Final);

    }
}
