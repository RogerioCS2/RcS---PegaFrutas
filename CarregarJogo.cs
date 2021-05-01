using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarJogo : MonoBehaviour{
	public float tempo;
        
    void Update(){
    	StartCoroutine(Carregar());     	 
    }    

    IEnumerator Carregar() {
    	yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene("CenarioPrincipal");                
    }    
}
