using UnityEngine;
using System.Collections;

public class Estudo : MonoBehaviour {

	//privacidade tipo nome
	private SpriteRenderer PlayerSpriteRender;
	private Rigidbody2D PlayerRigidBody;
	public Sprite NovoSprite;
	private float horizontal;
	public float velocidade, velocidadeBase, adicionalVelocidade, forcaPulo;

	// Use this for initialization
	void Start () {
		//Para iniciar componentes
		//PlayerSpriteRender = GetComponent<SpriteRenderer> ();
		PlayerRigidBody = GetComponent<Rigidbody2D> ();
		velocidade = velocidadeBase;
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxisRaw ("Horizontal");

		if (Input.GetButtonDown ("Correr")) {
			velocidade = velocidadeBase + adicionalVelocidade;
		}
		if (Input.GetButtonUp ("Correr")) {
			velocidade = velocidadeBase;
		}
		if(Input.GetButtonDown("Pulo")){
			PlayerRigidBody.AddForce (new Vector2 (0, forcaPulo));
		}


	}

	void FixedUpdate(){
		PlayerRigidBody.velocity = new Vector2 (horizontal * velocidade, PlayerRigidBody.velocity.y);
	}

}
