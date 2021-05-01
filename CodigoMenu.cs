using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodigoMenu : MonoBehaviour{
	public GameObject imgOpcoes;
	public bool opcoesAtivado = false;
    
    public void IniciarJogo(){
    	//Debug.Log("Jogo Iniciado");
    	SceneManager.LoadScene("Animacao");  
    }

    public void Opcoes(){
    	if(opcoesAtivado == false){
    		opcoesAtivado = true;
    		imgOpcoes.SetActive(true);
    	}else{
    		opcoesAtivado = false;
    		imgOpcoes.SetActive(false);
    	}    	
    }
}
