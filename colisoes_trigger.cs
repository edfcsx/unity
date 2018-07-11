using UnityEngine;
using System.Collections;

public class Colisoes : MonoBehaviour {

	/* Existem 6 função 
	 * 3 para colisão
	 * 3 para trigger
	*/

	//Para saber quando uma colisão começou
	void OnTriggerEnter2D(Collider2D col){

		switch(col.gameObject.tag){
		case "objeto":
			print (col.gameObject.name);
			break;
		case "tomarDano":
			print ("ai");
			break;
		}
	}
	//para saber quando saiu de uma colisão
	void OnTriggerExit2D(){
		
	}
	//para saber se você está colidindo, se usar o stay é importante usar o never sleep no motor
	//de fisica para que ele não desligue
	void OnTriggerStay2D(){
		
	}
}
