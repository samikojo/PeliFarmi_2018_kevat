using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	// Paljonko vahinkoa ammus tuottaa
	public int Damage;
	// Ammuksen nopeus (yksikköä/s)
	public float Speed;
	
	// Avainsana private tarkoittaa sitä, että muuttuja ei näy luoka
	// ulkopuolelle. Private on jäsenmuuttujan oletusnäkyvyysalue, joten
	// sitä ei välttämättä tarvitse kirjoittaa muuttujan eteen.
	private new Rigidbody2D rigidbody;
	
	// Ensimmäinen metodi, jonka Unity suorittaa oliolle, kun peli
	// käynnistetään tai kun olio luodaan pelin aikana.
	private void Awake()
	{
		// GetComponent hakee viittauksen siihen Rigidbody2D komponenttiin,
		// joka on liitetty tähän GameObjectiin.
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Laukaisee ammuksen matkaan 'direction' muuttujan osoittamaan 
	// suuntaan
	public void Launch( Vector2 direction )
	{
		Vector2 velocity = direction.normalized * Speed;
		rigidbody.velocity = velocity;
	}
	
	// Kutsutaan automaattisesti törmäyksen sattuessa.
	private void OnCollisionEnter2D( Collision2D collision )
	{
		// Tuhoaa sen GameObjectin, johon tämä komponentti on liitetty.
		Destroy(gameObject);
	}
}
