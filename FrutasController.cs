using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutasController : MonoBehaviour{
	public float tempo;		
	public GameObject ponto;
	private int seleciona;
	private float tempoEspera;
    private float tipoFruta;

    void Start(){
        tipoFruta = tempo;        
    }
    
    void Update(){        	  
        CriandoFrutas();
    }

    public void CriandoFrutas(){
    	tempoEspera += Time.deltaTime;
    	if(tempoEspera >= tempo){    		
    		tempoEspera = 0;
            if(tipoFruta == 20){
                seleciona = Random.Range(3, 6); 
            }else{
                seleciona = Random.Range(0, 3); 
            }    		
    		Vector3 posicao = new Vector3(Random.Range(-2.20f, 2.20f), ponto.transform.position.y, ponto.transform.position.y);
    		GameObject objeto1 = Instantiate(GameController.iniciarClasse.frutas[seleciona], posicao, ponto.transform.localRotation);    		   			
    	}     	 	
    } 
}
