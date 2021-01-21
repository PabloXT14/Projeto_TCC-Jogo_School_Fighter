using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Conversa : MonoBehaviour
{

    public int sex;
    public GameObject caixaDi;
    public TextAsset arquivoF;
    public TextAsset arquivo;
    public string[] dialogo;
    public TextMeshProUGUI textoMes;
    public static bool continua;
    private int fimdaLinha;
    private int linha_Atual;
    public bool Ativo;
    public bool controle;
    string convert;
    char TextoSaida;
    string mensagem = "";
    public TextMeshProUGUI TextoFinal;

    public static string NomePRo = "";
    public TextMeshProUGUI caixa_nome;
    public TextMeshProUGUI caixaReserva;
    private string escreve;
    public string[] Nomes;
    private int nome_Atual;
    private int nome_fim;
    public GameObject caixaNo;
    public static int cut;
    private int veterano;
    public static bool endChat;

    public static Conversa current;


    void Start()
    {
        if( (PlayerPrefs.GetInt("Veterano") != null) && (PlayerPrefs.GetInt("Veterano") != -10) )
        {
            veterano = PlayerPrefs.GetInt("Veterano");
        }
        else
        {
            veterano = EscolhaVet.vet;
        }

        if( (PlayerPrefs.GetInt("Sexo") != null) && (PlayerPrefs.GetInt("Sexo") != -10) )
        {
            sex = PlayerPrefs.GetInt("Sexo");
        }
        else
        {
            sex = EscolhaSX.sexo;
        }
       


        if ((arquivo != null ) && (arquivoF != null))
        {
            if (sex == 0)
            {
                dialogo = (arquivo.text.Split('\n'));
            }
            if (sex == 1)
            {
                dialogo = (arquivoF.text.Split('\n'));
            }
        }
        
        if (fimdaLinha == 0)
        {
            fimdaLinha = dialogo.Length;
            
        }
        convert = textoMes.text;
        if (controle)
        {
            //Chama TypeWriter
            StartCoroutine(TypeRight());
        }

        if (nome_fim == 0)
        {
            nome_fim = Nomes.Length;
        }

        if( (PlayerPrefs.GetString("Nome") != null) && (PlayerPrefs.GetString("Nome") != "-10") )
        {
            NomePRo = PlayerPrefs.GetString("Nome");
        }
        else
        {
            NomePRo = nome.protagonista;
        }

      

        if (caixa_nome.text == "protagonista")
        {
            caixa_nome.text = NomePRo;
        }
        if (caixa_nome.text == "veterano")
        {
            if(veterano == 0)
            {
                caixa_nome.text = "Daniboy";
            }
            if (veterano == 1)
            {
                caixa_nome.text = "Brown";
            }

        }
        if (nome_Atual > nome_fim)
        {
            nome_Atual = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        current = this;
            
        caixaDi.SetActive(Ativo);
        if ((Input.GetKeyUp(KeyCode.Return)) && (continua == true))
        {
            
            continua = false;
            controle = true;
            if (linha_Atual < fimdaLinha)
            {
                textoMes.text = dialogo[linha_Atual];
                convert = textoMes.text;
            }
                
            if (caixaDi.activeSelf)
            {
                linha_Atual += 1;
            }
            if (controle)
            {
                //Chama TypeWriter
                StartCoroutine(TypeRight());
            }

            if (nome_Atual < nome_fim)
            {
                caixaReserva.text = Nomes[nome_Atual];
                escreve = caixaReserva.text;
            }
            if (caixaNo.activeSelf)
            {
                nome_Atual += 1;
            }

            if (escreve == "protagonista")
            {
                caixa_nome.text = NomePRo;
            }
            if (escreve == "veterano")
            {
                if (veterano == 0)
                {
                    caixa_nome.text = "Daniboy";
                }
                if (veterano == 1)
                {
                    caixa_nome.text = "Brown";
                }
            }

            if((escreve != "protagonista") && (escreve != "veterano"))
            {
                caixa_nome.text = escreve;
            }
        }
       

        if (linha_Atual == fimdaLinha)
        {
            
               Desabilitar();
            
        }
    }

    IEnumerator TypeRight()
    {
        continua = false;
        //Desliga o controle para que ele não se inicialize a cada frame da função Update()
        controle = false;
        mensagem = "";
      
            for (int i = 0; i < convert.Length; i++)
        {
            
            //Pega Caracter por Caracter da string TextoEntrada
            TextoSaida = convert[i];
            //Agrupa todos os caracteres da String a cada Loop
            mensagem += TextoSaida;
            if (mensagem == "Eu sou seu veterano, pode me chamar de veterano")
            {
                if (veterano == 0)
                {
                    mensagem = "Eu sou seu veterano, pode me chamar de DaniBoy";
                }
                if (veterano == 1)
                {
                    mensagem = "Eu sou seu veterano, pode me chamar de Brown";

                }
                if (veterano == 2)
                {
                    mensagem = "Eu sou seu veterano, pode me chamar de Mogli";

                }
            }
                TextoFinal.text = mensagem;
            //Cria um Tempo de 1 milessimos de segundos
            yield return new WaitForSeconds(0.04f);      
        }

        StartCoroutine(delay());
        
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.3f);
        continua = true;
    }


    public void Desabilitar()
    {
        endChat = true;
        caixaDi.SetActive(false);
    }
   
}
