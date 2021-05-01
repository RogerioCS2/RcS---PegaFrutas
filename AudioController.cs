
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour{
	public AudioClip[] clips;
    public AudioClip[] sons;
	private AudioSource musicas;
    public AudioSource barulhos;
    public AudioSource toast;
	public static AudioController iniciarClasse;    
    
    void Start(){    	
    	musicas = GetComponent<AudioSource>();              
    }

    void Awake(){
    	if(iniciarClasse == null){
    		iniciarClasse = this;
    		//DontDestroyOnLoad(this.gameObject);
    	}else{
    		Destroy(gameObject);
    	}
    }
   
    void Update(){
        Musicas();        
    }

    public void Musicas(){
        if(!musicas.isPlaying){
            musicas.clip = MusicasRandomicas();
            musicas.Play();             
        } 
    }    

    AudioClip MusicasRandomicas(){
    	return clips[Random.Range(0, clips.Length)];
    }

    public void AtivandoSons(int posicao, int som){
        if(som == 1){
            toast.clip = sons[posicao]; 
            toast.Play();
        }else{
            barulhos.clip = sons[posicao]; 
            barulhos.Play();
        }         
    }

    public void PararMusicas(){     
        gameObject.GetComponent<AudioSource>().enabled = false;  
        gameObject.GetComponent<AudioListener>().enabled = false; 
    }
    public void TocarMusicas(){
        gameObject.GetComponent<AudioSource>().enabled = true;  
        gameObject.GetComponent<AudioListener>().enabled = true; 
    }
}
