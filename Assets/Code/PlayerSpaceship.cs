using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour {
	
	// Jäsenmuuttuja, jonka tyyppi on Mover ja nimi mover.
	Mover mover;
	
	// Taulukollinen ase-olioita. Tähän taulukkoon tallennataan viittaukset
	// kaikista aluksen aseista.
	private Weapon[] weapons;

	// Use this for initialization
	void Start () {
		
		// Hakee Mover-tyyppista samasta GameObjectista, johon tämä
		// PlayerSpaceship-komponentti on kytketty.
		mover = GetComponent<Mover>();
		
		// Haetaan viittaukset kaikkiin ase-olioihin, jotka on liitetty tähän
		// GameObjectiin ja sen lapsiin.
		weapons = GetComponentsInChildren<Weapon>();
	}
	
	// Metodi, jonka Unity suorittaa automaattisesti kerran framen aikana.
	void Update () {
		Vector3 input = ReadInput();
		
		// Mover liikuttaa alusta kerran framessa siihen suuntaan, johon
		// kayttäjä haluaa aluksen liikkuvan.
		mover.Move(input);
		
		if( Input.GetButton("Fire1") )
		{
			Shoot();
		}
	}
	
	private void Shoot()
	{
		// For-silmukka käy läpi kaikki weapons-taulukkoon tallennetut aseet.
		// Taulukon indeksointi alkaa nollasta. Ensimmäisen alkion indeksi on
		// siis nolla.
		for ( int i = 0; i < weapons.Length; i++ )
		{
			Weapon weapon = weapons[i];
			weapon.Shoot();
		}
	}
	
	// Metodi, joka lukee käyttäjän syötteen.
	// Syöte luetaan Horizontal ja Vertical akseleilta
	// ja lopputulos palautetaan Vector3-tyyppisessä oliossa.
	Vector3 ReadInput () {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		Vector3 result = new Vector3(horizontal, vertical, 0);
		return result;
	}
}
