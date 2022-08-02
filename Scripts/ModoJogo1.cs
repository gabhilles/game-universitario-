using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class ModoJogo1 : MonoBehaviour
{

    [Header("Configuração dos Textos")]
    public Input Name;
    public Text nomeTemaTxt;

    public Text pergntaTxt;
    public Image perguntaIMG;
    public Text infoRespostasTxt;

    public Text msg1Txt;
    public Text msg2Txt;
    [Header("Configuração da Pontuação")]

    public Text notaJogador1;
    public Text notaJogador2;

    [Header("Configuração dos Textos Alternativas")]

    public Text altATxt;
    public Text altBTxt;
    public Text altCTxt;
    public Text altDTxt;




    [Header("Configuração das Barras")]

    public GameObject barraProgresso;
    public GameObject barraTempo;

    [Header("Configuração dos Botões")]

    public Button[] botoesResposta;
    public Color corAcerto, corErro;

    [Header("Configuração do Modo do Jogo")]


    public bool perguntaComImg;
    public bool perguntasAleatorias;
    public bool utilizarAlternativas;
    public bool jogarComTempo;
    public float tempoResponder;
    public bool mostrarCorreta;
    public int QuantidadePiscar;



    [Header("Configuração das Perguntas")]

    public string[] perguntas;
    public Sprite[] perguntasIMG;
    public string[] correta;


    public int quantidadePerguntas;
    public List<int> listaPerguntas;

    [Header("Configuração das Alternativas")]

    public string[] alternativaA;
    public string[] alternativaB;
    public string[] alternativaC;
    public string[] alternativaD;


    [Header("Configuração dos paineis")]

    public GameObject[] paineis;
    public GameObject[] estrela;

    [Header("Configuração das Mensagens")]

    public string[] mensagem1;
    public string[] mensagem2;
    public Color[] corMensagem;


    // - -- - -- --- -- - - - - - -- -- - - -

    public float notaFinal;
    public int qntAcertosJogador1, qntAcertorJogador2, nEstrelas;
    private int idResponder, notaMinima1Estrela, notaMinima2Estrelas, idTema, idBtnCorreto;
    private float percProgresso, qntRespondida, percTempo, valorQuestao, tempTime;
    private bool exibindoCorreta;


    // Use this for initialization
    void Start()
    { //                                                                                                            START  VOID



        qntAcertosJogador1 = DataGame.Jogador1;
        qntAcertorJogador2 = DataGame.Jogador2;
        AdicionarPontuação();

        idTema = PlayerPrefs.GetInt("idTema");
        notaMinima1Estrela = PlayerPrefs.GetInt("notaMinima1Estrela");
        notaMinima2Estrelas = PlayerPrefs.GetInt("notaMinima2Estrelas");

        nomeTemaTxt.text = PlayerPrefs.GetString("nomeTema");



        if (perguntaComImg == true)
        {
            montarListaPerguntaIMG();
        }
        else
        {
            montarListaPergunta();
        }


        progressaoBarra();


        controleBarraTempo();
        barraTempo.SetActive(false);





        paineis[0].SetActive(true);
        paineis[1].SetActive(false);
        paineis[2].SetActive(false);
        paineis[3].SetActive(false);
        paineis[4].SetActive(false);
        paineis[5].SetActive(false);





    }

    // Update is called once per frame
    void Update() //                                                                                                     UPDATE VOID
    {







        // JOGAOR 1 BOTOES
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            print("apertei KEY BUTON 0");
            responder("A");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            print("apertei KEY BUTON 1");
            responder("B");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            print("apertei KEY BUTON 2");
            responder("C");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            print("apertei KEY BUTON 3");
            responder("D");
        }
        // JOGADOR 2 BOTOES
        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            print("JOGAOR 2 KEY BUTON 4");
            responderao("A");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            print("JOGAOR 2 KEY BUTON 5");
            responderao("B");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            print("JOGAOR 2 KEY BUTON 6");
            responderao("C");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            print("JOGAOR 2 KEY BUTON 07");
            responderao("D");
        }// TESTE
        














        if (jogarComTempo == true && exibindoCorreta == false)
        {
            tempTime += Time.deltaTime;
            controleBarraTempo();
            if (tempTime >= tempoResponder) { proximaPergunta(); }
        }
    }


    //        ESSA FUNCAO É RESPOSAVEL POR MONTAR A LISTA DE PERGUNTAS COM TEXTOS A SEREM RESPONDIDAS
    public void montarListaPergunta() //                                                                                 MONTAR LISTA PERGUNTA  VOID
    {
        if (quantidadePerguntas > perguntas.Length) { quantidadePerguntas = perguntas.Length; }
        valorQuestao = 10 / (float)quantidadePerguntas;

        //EM CASO DE MODO DE JOGO COM PERGUNTAS ALEATORIAS----------------------------------------------------------
        if (perguntasAleatorias == true)
        {

            bool addPergunta = true;

            if (quantidadePerguntas > perguntas.Length) { quantidadePerguntas = perguntas.Length; }
            valorQuestao = 10 / (float)quantidadePerguntas;


            while (listaPerguntas.Count < quantidadePerguntas)
            {
                addPergunta = true;

                int rand = Random.Range(0, perguntas.Length);

                foreach (int idP in listaPerguntas)
                {
                    if (idP == rand)
                    {
                        addPergunta = false;
                    }
                }
                if (addPergunta == true) { listaPerguntas.Add(rand); }

            }
        } //EM CASO DE MODO DE JOGO ONDE AS PERGUNTAS NÃO SÃO ALEATÓRIAS --------------------------------------------------------
        else
        {

            for (int i = 0; i < quantidadePerguntas; i++)
            {
                listaPerguntas.Add(i);
            }

        }

        pergntaTxt.text = perguntas[listaPerguntas[idResponder]];

        if (utilizarAlternativas == true)
        {
            altATxt.text = alternativaA[listaPerguntas[idResponder]];
            altBTxt.text = alternativaB[listaPerguntas[idResponder]];
            altCTxt.text = alternativaC[listaPerguntas[idResponder]];
            altDTxt.text = alternativaD[listaPerguntas[idResponder]];
        }
    }

    //        ESSA FUNCAO É RESPOSAVEL POR MONTAR A LISTA DE PERGUNTAS COM IMAGENS A SEREM RESPONDIDAS
    public void montarListaPerguntaIMG() //                                                                                 MONTAR LISTA DE IMAGENS PARA PERGUNTA  VOID
    {
        if (quantidadePerguntas > perguntasIMG.Length) { quantidadePerguntas = perguntasIMG.Length; }
        valorQuestao = 10 / (float)quantidadePerguntas;



        //         EM CASO DE MODO DE JOGO COM PERGUNTAS ALEATORIAS----------------------------------------------------------
        if (perguntasAleatorias == true)
        {

            bool addPergunta = true;
            // FAZ A VALIDACAO DA QUANTIDADE DE PERGUNTAS PARA O TESTE EM RELACAO A QUANTIDADE DE PERGUNTAS EXISTENTES


            while (listaPerguntas.Count < quantidadePerguntas)
            {
                addPergunta = true;

                int rand = Random.Range(0, perguntasIMG.Length);

                foreach (int idP in listaPerguntas)
                {
                    if (idP == rand)
                    {
                        addPergunta = false;
                    }
                }

                if (addPergunta == true)
                {
                    listaPerguntas.Add(rand);
                }

            }
        }



        //         EM CASO DE MODO DE JOGO ONDE AS PERGUNTAS NÃO SÃO ALEATÓRIAS --------------------------------------------------------
        else
        {

            for (int i = 0; i < quantidadePerguntas; i++)
            {
                listaPerguntas.Add(i);
            }

        }

        perguntaIMG.sprite = perguntasIMG[listaPerguntas[idResponder]];



        if (utilizarAlternativas == true)
        {
            altATxt.text = alternativaA[listaPerguntas[idResponder]];
            altBTxt.text = alternativaB[listaPerguntas[idResponder]];
            altCTxt.text = alternativaC[listaPerguntas[idResponder]];
            altDTxt.text = alternativaD[listaPerguntas[idResponder]];
        }
    }

    public void responder(string alternativa) //                                                                            RESPONDER VOID

    {
        print("JOGAOR 1 RESPONDEU");
        // VERIFICA SE NO MODO DE JOGO ESTÁ SETADO PARA EXIBIR AS ALTERNATIVAS CORRETA, CASO ESTEJA, ELE RETORNA EM CASO DE MAIS DE UM CLICK.
        if (exibindoCorreta == true) { return; } // quando estiver piscando a correta ele bloqueia os botoes.


        // FAZ A VERIFICAÇÃO DE SE A RESPOSTA ESTA CORRETA E ADICONA UM NA QUANTIDADE DE ACERTOS

        if (correta[listaPerguntas[idResponder]] == alternativa)
        {
            print("jogaor 1 acertou");
            DataGame.Jogador1 += 1;
            paineis[0].SetActive(false);
            paineis[1].SetActive(false);
            paineis[2].SetActive(false);
            paineis[3].SetActive(false);
            paineis[4].SetActive(true);
            paineis[5].SetActive(false);
        }
        else
        {

            print("jogaor 1 errou");
            DataGame.Jogador2 += 1;

            paineis[0].SetActive(false);
            paineis[1].SetActive(false);
            paineis[2].SetActive(true);
            paineis[3].SetActive(false);
            paineis[4].SetActive(false);
            paineis[5].SetActive(false);
        }

        // - - -- - - - - -- - - -
        // EM CASO DO MODO DE JOGO COM EXIBICAO DA CORRETA, INDICA QUAL BOTAO CONTEM A RESPOSTA CORRETA
        switch (correta[listaPerguntas[idResponder]])
        {

            case "A":
                idBtnCorreto = 0;
                break;
            case "B":
                idBtnCorreto = 1;
                break;
            case "C":
                idBtnCorreto = 2;
                break;
            case "D":
                idBtnCorreto = 3;
                break;
        }



        // EM CASO DE MODO DE JOGO EXIBINDO A RESPOSTA CORRETA, ALTERA A COR DOS BOTOES E FAZ A CHAMADA DA FUNCAO DE ANIMACAO; (PISCA)
        if (mostrarCorreta == true)
        {
            foreach (Button b in botoesResposta)
            {
                b.image.color = corErro;
            }
            exibindoCorreta = true;
            botoesResposta[idBtnCorreto].image.color = corAcerto;
            StartCoroutine("mostrarAlternativaCorreta");
        }
        else // CASO O MODO DE JOGO NÃO ESTEJA PARA EXIBIR A CORRETA CHAMA A PROXIMA PERGUNTA
        {
            proximaPergunta();
        }

    }

    // JOGAOR DOIS


    public void responderao(string alternativa) //                                                                            RESPONDER VOID

    {
        print("JOGAOR 2 RESPONDEU");
        // VERIFICA SE NO MODO DE JOGO ESTÁ SETADO PARA EXIBIR AS ALTERNATIVAS CORRETA, CASO ESTEJA, ELE RETORNA EM CASO DE MAIS DE UM CLICK.
        if (exibindoCorreta == true) { return; } // quando estiver piscando a correta ele bloqueia os botoes.


        // FAZ A VERIFICAÇÃO DE SE A RESPOSTA ESTA CORRETA E ADICONA UM NA QUANTIDADE DE ACERTOS

        if (correta[listaPerguntas[idResponder]] == alternativa)
        {
            print("jogaor 2 acertou");
            DataGame.Jogador2 += 1;

            paineis[0].SetActive(false);
            paineis[1].SetActive(false);
            paineis[2].SetActive(false);
            paineis[3].SetActive(false);
            paineis[4].SetActive(false);
            paineis[5].SetActive(true);
        }
        else
        {

            print("jogaor 2 errou");
            DataGame.Jogador1 += 1;

            paineis[0].SetActive(false);
            paineis[1].SetActive(false);
            paineis[2].SetActive(false);
            paineis[3].SetActive(true);
            paineis[4].SetActive(false);
            paineis[5].SetActive(false);
        }

        // - - -- - - - - -- - - -
        // EM CASO DO MODO DE JOGO COM EXIBICAO DA CORRETA, INDICA QUAL BOTAO CONTEM A RESPOSTA CORRETA
        switch (correta[listaPerguntas[idResponder]])
        {

            case "A":
                idBtnCorreto = 0;
                break;
            case "B":
                idBtnCorreto = 1;
                break;
            case "C":
                idBtnCorreto = 2;
                break;
            case "D":
                idBtnCorreto = 3;
                break;
        }



        // EM CASO DE MODO DE JOGO EXIBINDO A RESPOSTA CORRETA, ALTERA A COR DOS BOTOES E FAZ A CHAMADA DA FUNCAO DE ANIMACAO; (PISCA)
        if (mostrarCorreta == true)
        {
            foreach (Button b in botoesResposta)
            {
                b.image.color = corErro;
            }
            exibindoCorreta = true;
            botoesResposta[idBtnCorreto].image.color = corAcerto;
            StartCoroutine("mostrarAlternativaCorreta");
        }
        else // CASO O MODO DE JOGO NÃO ESTEJA PARA EXIBIR A CORRETA CHAMA A PROXIMA PERGUNTA
        {
            proximaPergunta();
        }

    }


    //       FUNCAO RESPONSAVEL POR PROCESSAR AS PERGUNTAS, FAZ A CHAMADA DE UMA NOVA OU ENCERRA O TESTE. 
    public void proximaPergunta() //                                                                                               PROXIMA PERGUNTA VOID
    {
        idResponder += 1;
        tempTime = 0;

        qntRespondida += 1;

        progressaoBarra();
        // CASO AINDA HAJA PERGUNTAS A SEREM RESPONDIDA, PROCESSA A NOVA PERGUNTA
        if (idResponder < listaPerguntas.Count)
        {
            if (perguntaComImg == true)
            {

                perguntaIMG.sprite = perguntasIMG[listaPerguntas[idResponder]];

            }
            else

            {

                pergntaTxt.text = perguntas[listaPerguntas[idResponder]];

            }



            if (utilizarAlternativas == true)
            {
                altATxt.text = alternativaA[listaPerguntas[idResponder]];
                altBTxt.text = alternativaB[listaPerguntas[idResponder]];
                altCTxt.text = alternativaC[listaPerguntas[idResponder]];
                altDTxt.text = alternativaD[listaPerguntas[idResponder]];

            }



        }
        else // CASO O TESTE TENHA FINALIZADO, CHAMA A FUNCAO QUE CALCULA A NOTA FINAL.
        {
            calcularNotaFinal();
        }
    }
    // FUNÇÃO QUE CONTROLA A BARRA DE PROGRESSO DO JOGO
    void progressaoBarra()//                                                                                               PROGRESSO BARRA VOID
    {
        infoRespostasTxt.text = "Respondeu " + (qntRespondida) + " de " + listaPerguntas.Count + " perguntas";
        print("barra progresso");
        percProgresso = qntRespondida / listaPerguntas.Count;
        barraProgresso.transform.localScale = new Vector3(percProgresso, 1, 1);
    }
    // FUNÇÃO QUE CONTROLA A BARRA DE TEMPO EM CASO DE MODO DE TEMPO.

    void controleBarraTempo()
    {
        if (jogarComTempo == true) { barraTempo.SetActive(true); }
        percTempo = ((tempTime - tempoResponder) / tempoResponder) * -1;

        if (percTempo < 0) { percTempo = 0; }

        barraTempo.transform.localScale = new Vector3(percTempo, 1, 1);
    }
    //  FUÃO RESPONSAVEL POR CALCULAR E GRAVAR A NOTA FINAL DO TESTE
    void calcularNotaFinal()//                                                                                               CALCULAR NOTA FINAL VOID
    {



        notaFinal = Mathf.RoundToInt(valorQuestao);


        if (notaFinal > PlayerPrefs.GetInt("notaFinal_" + idTema.ToString()))
        {
            PlayerPrefs.SetInt("notaFinal_" + idTema.ToString(), (int)notaFinal);
        }







        print(notaFinal);

        if (notaFinal == 10) { nEstrelas = 3; }
        else if (notaFinal >= notaMinima2Estrelas) { nEstrelas = 2; }
        else if (notaFinal >= notaMinima1Estrela) { nEstrelas = 1; }



        msg1Txt.text = mensagem1[nEstrelas];
        msg1Txt.color = corMensagem[nEstrelas];
        msg2Txt.text = mensagem2[nEstrelas];



        foreach (GameObject e in estrela)
        {
            e.SetActive(false);
        }



        for (int i = 0; i < nEstrelas; i++)
        {
            estrela[i].SetActive(true);
        }


        paineis[0].SetActive(false);
        paineis[1].SetActive(false);
    }


    void mostrarAlternativaCorrea()
    {




    }
    // CORROUTINE QUE FAZ A ANIMAÇAO DE PISCAR O BOTAO DA ALTERNATIVA CORRETA
    IEnumerator mostrarAlternativaCorreta()//                                                                             MOSTRAR ALTERNATIVA CORRETA VOID
    {

        for (int i = 0; i < QuantidadePiscar; i++)
        {
            botoesResposta[idBtnCorreto].image.color = corAcerto;
            yield return new WaitForSeconds(0.1f);
            botoesResposta[idBtnCorreto].image.color = Color.white;
            yield return new WaitForSeconds(0.1f);

        }

        foreach (Button b in botoesResposta)
        {
            b.image.color = Color.white;
        }
        exibindoCorreta = false;

        proximaPergunta();
    }

    public void ApertarBotoes()
    {



    }
    public void AdicionarPontuação()
    {
        notaJogador1.text = "" + qntAcertosJogador1;
        notaJogador2.text = "" + qntAcertorJogador2;
    }
}
