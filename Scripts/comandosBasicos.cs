using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comandosBasicos : MonoBehaviour {






    public void carregaCena(string nomeCena)

    {
       
        
            SceneManager.LoadScene(nomeCena);
        
    }








    public void sair()// só funciona para mobile e pc
	{
		Application.Quit ();
	}

	public void jogarNovamente()
	{
		int idCena = PlayerPrefs.GetInt ("idTema");

		if (idCena != 0)
		{
			SceneManager.LoadScene (idCena.ToString());
		}

	}



}
	