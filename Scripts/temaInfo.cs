using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temaInfo : MonoBehaviour {

	private temaScene temaScene;


	[Header("Configuração do tema")]
	public 	int 			idTema;
	public 	string 			nomeTema;
	public 	Color 			corTema;

	[Header("Configuração das Estrelas")]
	public 	int 			notaMinima1Estrela;
	public 	int 			notaMinima2Estrelas;

	[Header("configuração do Botão")]
	public 	Text 			idTemaTxt;
	public 	GameObject[]	estrela;

	private 	int 			notaFinal;

	// Use this for initialization
	void Start () 
	{
		notaFinal = PlayerPrefs.GetInt ("notaFinal_" + idTema.ToString());

		temaScene = FindObjectOfType (typeof(temaScene)) as temaScene;

		idTemaTxt.text = idTema.ToString();


			
		estrelas (); //chama o metoto estelas que calcula quantas estrelas ganhamos
	}
	
	public void selecionarTema()
	{
		temaScene.nomeTemaTxt.text = nomeTema;
		temaScene.nomeTemaTxt.color = corTema;


		PlayerPrefs.SetInt ("idTema", idTema);
		PlayerPrefs.SetString ("nomeTema", nomeTema);
		PlayerPrefs.SetInt ("notaMinima1Estrela", notaMinima1Estrela);
		PlayerPrefs.SetInt ("notaMinima2Estrelas", notaMinima2Estrelas);


		temaScene.btnJogar.interactable = true;
	}



	public void estrelas()
	{
		


		foreach (GameObject e in estrela) 
		{
			e.SetActive(false);
		}

		int nEstrelas = 0;

		if 			(notaFinal == 10) 							{nEstrelas = 3;}
		else if 	(notaFinal >= notaMinima2Estrelas) 			{nEstrelas = 2;}
		else if 	(notaFinal >= notaMinima1Estrela)	 		{nEstrelas = 1;}



		for (int i = 0; i < nEstrelas; i++)
		{
			estrela [i].SetActive (true);
		}



	}





}
