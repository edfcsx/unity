//Comando utilizado para pegar os dados do componente transform do objeto.

using UnityEngine;
using System.Collections;

public class Estudo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print (transform.position);
		print (transform.rotation);
		print (transform.localScale);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
