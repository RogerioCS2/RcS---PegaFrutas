using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour{
	public static GameController iniciarClasse;
	public int pontuacaoTotal;    
	public GameObject[] frutas;
    public GameObject[] lancadores;
	public GameObject hard;
    public GameObject[] emotion;
    public GameObject ponto;

	public float tempo, tempo2, tempo3;   
	public bool hardAtivo = false;
    public bool coroAtacando = false;
    public bool venenoLiberado = false;
    public bool metaSuperada = false;    
    public Text pontuacaoUI;
    public Text recordUI;
    private int pontuacaoMaxima; 
    public GameObject pauseImg;
    public GameObject gameOverImg;
    public bool jogoPausado = false;   
	    
    void Start(){
        pontuacaoTotal = 1;
    	iniciarClasse = this; 
    	hard.SetActive(false);           
    }
   
    void Update(){
        AtualizaPontuacaoTela(); 
        Cronometro();
        VocePerdeu();            
    }

    public void Cronometro(){
        tempo += Time.deltaTime; 
        if(tempo >= 10){            
            tempo = 0;
            AtivaHard();                           
        } 

        tempo2 +=Time.deltaTime;
        if(coroAtacando == true){            
            if(tempo2 >= 5){ 
                tempo2 = 0;
                if(metaSuperada == false){
                    if(pontuacaoTotal > 0 && pontuacaoTotal <= 50){
                        TirarPontuacao(5);
                    }
                    if(pontuacaoTotal > 50 && pontuacaoTotal <= 150){
                        TirarPontuacao(10);
                    }
                    if(pontuacaoTotal > 150){
                        Debug.Log("Meta Superada");
                        TirarPontuacao(25);
                        metaSuperada = true;
                    }     
                }else{
                     TirarPontuacao(25);
                }                                    
            }          
        } 

        tempo3 += Time.deltaTime;
        if(venenoLiberado == true && jogoPausado == false){
            if(tempo3 >= 47){ 
                tempo3 = 0;                
                LiberandoVeneno();                             
            }  
        } 
    }

    public void ContadorFrutas(){    	
    	pontuacaoTotal++;
        AudioController.iniciarClasse.AtivandoSons(1, 0);
    }    

    public void TirarPontuacao(int pontos){
        if(jogoPausado == false && pontuacaoTotal > 1){
            pontuacaoTotal-= pontos;
        }    	
    }

    public void AtivaHard(){
        if(jogoPausado == false){
            switch(hardAtivo){
                case true:
                    hard.SetActive(false);
                    hardAtivo = false;              
                break;
                case false:
                    hard.SetActive(true);
                    hardAtivo = true;               
                break;          
            } 
        }    	
    }

    public void AtualizaPontuacaoTela(){        
        if(pontuacaoTotal < 0){pontuacaoTotal = 0;}       
        pontuacaoUI.text = pontuacaoTotal.ToString(); 
        GravaRecord();
    } 

    IEnumerator AtivaSinalizacaoCoro(){
        AudioController.iniciarClasse.AtivandoSons(0, 1);
        emotion[0].SetActive(true);
        yield return new WaitForSeconds(1f); 
        emotion[0].SetActive(false);              
    }

    IEnumerator AtivaSinalizacaoRcS(){
        AudioController.iniciarClasse.AtivandoSons(0, 1);
        emotion[1].SetActive(true);
        yield return new WaitForSeconds(1f); 
        emotion[1].SetActive(false);              
    }   

    public void LiberandoVeneno(){
        Vector3 posicao = new Vector3(Random.Range(-2.20f, 2.20f), ponto.transform.position.y, ponto.transform.position.y);
        GameObject objeto1 = Instantiate(frutas[6], posicao, ponto.transform.localRotation);                 
    } 

    public void GravaRecord(){
        pontuacaoMaxima =  PlayerPrefs.GetInt("pontuacaoMaxima");
        recordUI.text = pontuacaoMaxima.ToString();
        if(pontuacaoTotal > pontuacaoMaxima){            
            pontuacaoMaxima = pontuacaoTotal;           
            PlayerPrefs.SetInt("pontuacaoMaxima", pontuacaoMaxima);   
        }
    }  

    public void PausarJogo(){
        if(jogoPausado == false){
            jogoPausado = true;
            pauseImg.SetActive(true);
            for(int i = 0; i <= lancadores.Length -1; i++){
                Debug.Log("Inativando Lancaddores");
                lancadores[i].SetActive(false);
            }
            AudioController.iniciarClasse.PararMusicas();
        }else{
            pauseImg.SetActive(false);
            jogoPausado = false;
            for(int i = 0; i <= lancadores.Length -1; i++){
                Debug.Log("Ativando Lancadores");
                lancadores[i].SetActive(true);
            }
            AudioController.iniciarClasse.TocarMusicas();
        }       
    }

    public void VocePerdeu(){
        if(pontuacaoTotal <= 0){
            pontuacaoTotal = 0;
            pontuacaoUI.text = pontuacaoTotal.ToString(); 
            jogoPausado = true;
            gameOverImg.SetActive(true);
            for(int i = 0; i <= lancadores.Length -1; i++){
                lancadores[i].SetActive(false);
            }
            AudioController.iniciarClasse.PararMusicas();
        }            
    }

    public void ReiniciarFase(string fase){       
        SceneManager.LoadScene(fase);        
    } 

    public void Sair(){
        Application.Quit();
    }
}