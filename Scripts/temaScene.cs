using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class temaScene : MonoBehaviour {


	public Text nomeTemaTxt;
	public Button btnJogar;


	// Use this for initialization
			void 					Start () 
	{


			btnJogar.interactable = false;

		
	}

	public	void				 jogar()
	{


		int idCena = PlayerPrefs.GetInt ("idTema");

		if (idCena != 0)
		{
			SceneManager.LoadScene (idCena.ToString());
		}




	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
