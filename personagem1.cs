using UnityEngine;
using System.Collections;

public class Estudo : MonoBehaviour {

	//privacidade tipo nome

	private Animator 	playerAnimator;
	private Rigidbody2D playerRigidBody;
	private float 		horizontal,vertical;
	public 	float 		velocidade, velocidadeBase, adicionalVelocidade, forcaPulo, forcaDash;
	public Transform 	groundCheck;
	private bool 		grounded,walk,olhandoEsquerda,inversaoGravidade;
	public LayerMask 	whatIsGround; //define quais camadas o groundCheck deve colidir

	// Use this for initialization
	void Start () {
		//Para iniciar componentes
		playerRigidBody = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();
		velocidade = velocidadeBase;
	}
	
	// Update is called once per frame
	void Update () {

		/* A função overlap cria um collisor dinamicamente retornando true ou false
		 * iremos utilizar para a criação do groundcheck
		 */
		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.02f, whatIsGround);
		//como o raio do circulo e float se faz necessario colocar um f ao final.
		//fim do overlap

		horizontal = Input.GetAxisRaw ("Horizontal");
		if(horizontal != 0){ walk = true; } else { walk = false; } //pegando o valor para a animacao

		//Invertendo o personagem , o valor de um booleano começa com padrão com false
		if(horizontal > 0 && olhandoEsquerda == true){
			Flip ();
		}else if(horizontal < 0 && olhandoEsquerda == false){
			Flip ();
		}

		//Invertendo a gravidade
		vertical = Input.GetAxisRaw ("Vertical");
		if(vertical > 0 && inversaoGravidade == false && grounded == true){
			inverterGravidade ();
		}else if(vertical < 0 && inversaoGravidade == true && grounded == true){
			inverterGravidade ();
		}
			
		if (Input.GetButtonDown ("Correr")) {
			velocidade = velocidadeBase + adicionalVelocidade;
		}
		if (Input.GetButtonUp ("Correr")) {
			velocidade = velocidadeBase;
		}

		if(Input.GetButtonDown("Pulo") && grounded == true){
			playerRigidBody.AddForce (new Vector2 (0, forcaPulo));	
		}

		if(Input.GetButtonDown("Fire1")){
			playerRigidBody.AddForce (new Vector2 (forcaDash, 10));
		}

		/*Atualiza o animator
		 * e bom por no final pois caso exista mais algum parametro que altere isso 
		 * ele sera passado no final de todo o codigo
		 */
		playerAnimator.SetBool ("walkAnimator", walk);
		//Fim do atualiza Animator
	}

	void FixedUpdate(){
		playerRigidBody.velocity = new Vector2 (horizontal * velocidade, playerRigidBody.velocity.y);
	}

	void Flip(){
		//responsavel por virar o personagem
		olhandoEsquerda = !olhandoEsquerda; // ! significa que ira inverter o valor de um booleano
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		forcaDash *= -1;
	}

	void inverterGravidade(){
		//responsavel por trocar a gravidade
		inversaoGravidade = !inversaoGravidade;
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;
		playerRigidBody.gravityScale *= -1;
		forcaPulo *= -1;
	}
}
