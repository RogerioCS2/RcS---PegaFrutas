using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{
	public float velocidade;
	private Rigidbody2D personagemRB;
	public bool jogoPausado = false;
	private float resetaVelocidade;
	private int direcao; 	
    
    void Start(){
    	personagemRB = GetComponent<Rigidbody2D>();
    	resetaVelocidade = velocidade;
    }
   
    void Update(){
    	//MovimentoTeclado();
    	MovimentoAndroid();    	 
    }

    public void Direita(){
		direcao = 1;
	}
	public void Esquerda(){
		direcao = -1;		
	}	

    public void MovimentoAndroid(){
		float movimento = direcao;
		personagemRB.velocity = new Vector2(movimento * velocidade, personagemRB.velocity.y);
		ControleTela();    	
		PausarJogo();			
    }

    public void MovimentoTeclado(){
    	if(jogoPausado == false){
    		float direcaoX = Input.GetAxisRaw("Horizontal");
    		personagemRB.velocity = new Vector2(direcaoX, 0) * velocidade;    		
    	}
    	ControleTela();    	
		PausarJogo();			
	}

	public void ControleTela(){
		if(transform.position.x <= -2.80f){
			transform.position = new Vector2(2.08f, transform.position.y);
		}
		if(transform.position.x >= 2.80f){
			transform.position = new Vector2(-2.08f,  transform.position.y);
		}		
	}

	public void PausarJogo(){
		if(Input.GetKeyDown(KeyCode.G)){
			Debug.Log("Pause Ativado");			
			if(jogoPausado == false){				
				jogoPausado = true;
				velocidade = 0;	
				transform.position = new Vector2(0.04f, transform.position.y);			
			}else{
				jogoPausado = false;
				velocidade = resetaVelocidade;				
			} 
			GameController.iniciarClasse.PausarJogo();    
		}

		if(Input.GetKeyDown(KeyCode.F)){			
			GameController.iniciarClasse.Sair();
		}
	}
}
