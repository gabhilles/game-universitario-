using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carrega1 : MonoBehaviour {

    private void Start()
    {
        DataGame.Jogador1 = 0;
        DataGame.Jogador2 = 0;

    }
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Joystick1Button9))

        {

            carregaCena1("nomeCena");
            print("apertei pra passar pro primeiro nivel");
        }
    }


    public void carregaCena1(string nomeCena)

    {

        
            SceneManager.LoadScene(1);
       
    }
}

