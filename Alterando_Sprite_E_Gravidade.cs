using UnityEngine;
using System.Collections;

public class Estudo : MonoBehaviour {

	//privacidade tipo nome
	private SpriteRenderer PlayerSpriteRender;
	private Rigidbody2D PlayerRigidBody;
	public Sprite NovoSprite;

	// Use this for initialization
	void Start () {
		//Para iniciar componentes
		PlayerSpriteRender = GetComponent<SpriteRenderer> ();
		PlayerRigidBody = GetComponent<Rigidbody2D> ();
		PlayerRigidBody.gravityScale = -1;
		PlayerSpriteRender.flipY = true;

		PlayerSpriteRender.sprite = NovoSprite;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
