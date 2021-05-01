using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frutas : MonoBehaviour{	
	private Rigidbody2D personagemRB;	
	public float velocidade;	
	public int tipoFruta;    
    private SpriteRenderer spriteRender; 
    public bool frutasBoas;  
    	   
    void Start(){ 
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        personagemRB = gameObject.GetComponent<Rigidbody2D>(); 
    }
   
    void Update(){       
        AtivarInvulnerabilidade();
    	TiraPontos();           
    }

    void OnCollisionEnter2D(Collision2D colisao)    {
        if (colisao.gameObject.tag == "Player"){           
        	GameController.iniciarClasse.pontuacaoTotal++;
            frutasBoas = (tipoFruta == 1)||(tipoFruta == 2)||(tipoFruta == 3);
        	if(frutasBoas){               
        		GameController.iniciarClasse.ContadorFrutas();                
        	}            
            if(tipoFruta == 20){              
                GameController.iniciarClasse.StartCoroutine("AtivaSinalizacaoCoro");
                GameController.iniciarClasse.coroAtacando = true; 
                GameController.iniciarClasse.venenoLiberado = true;                                                      
            } 
            if(tipoFruta == 7){
                GameController.iniciarClasse.StartCoroutine("AtivaSinalizacaoRcS");
                GameController.iniciarClasse.ContadorFrutas();    
                GameController.iniciarClasse.venenoLiberado = false; 
                GameController.iniciarClasse.coroAtacando = false;
            }                      
            Destroy(gameObject);
        }
    } 

    public void TiraPontos(){       
    	if(transform.position.y < -6f){            
    		if(GameController.iniciarClasse.pontuacaoTotal >= 0 || tipoFruta != 20){
    			GameController.iniciarClasse.TirarPontuacao(5);
    		}
            Destroy(gameObject);           		
    	}         
    }

    public void AtivarInvulnerabilidade(){       
        if(tipoFruta == 20){
            StartCoroutine("Invuneravel");    
        }       
    }

    IEnumerator Invuneravel() {
        for(float i = 0f; i < 1f; i += 0.1f ){
            spriteRender.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRender.enabled = true;
        }       
    }    
}
