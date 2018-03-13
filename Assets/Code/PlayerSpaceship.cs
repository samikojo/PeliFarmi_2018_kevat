using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : Spaceship
{
	// Metodi, jonka Unity suorittaa automaattisesti kerran framen aikana.
	void Update ()
    {
		Vector3 input = ReadInput();
		
		// Mover liikuttaa alusta kerran framessa siihen suuntaan, johon
		// kayttäjä haluaa aluksen liikkuvan.
		Mover.Move(input);
		
		if( Input.GetButton("Fire1") )
		{
			Shoot();
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
