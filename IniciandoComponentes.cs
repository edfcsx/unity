using UnityEngine;
using System.Collections;

public class Estudo : MonoBehaviour {

	//privacidade tipo nome
	public SpriteRenderer PlayerSpriteRender;

	// Use this for initialization
	void Start () {
		//Para iniciar componentes
		PlayerSpriteRender = GetComponent<SpriteRenderer> ();

		PlayerSpriteRender.enabled = false;
		PlayerSpriteRender.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
