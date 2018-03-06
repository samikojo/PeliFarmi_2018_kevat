using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour {

	// Jäsenmuuttuja, näkyy kaikille luokan metodeille.
	int sum;
	
	// Jäsenmuuttuja, jonka tyyppi on Mover ja nimi mover.
	Mover mover;

	// Use this for initialization
	void Start () {
		// Metodi palauttaa lopputuloksen ja se tallennetaan
		// muuttujaan nimeltä sum.
		sum = Sum(1, 2);
		
		// Hakee Mover-tyyppista samasta GameObjectista, johon tämä
		// PlayerSpaceship-komponentti on kytketty.
		mover = GetComponent<Mover>();
	}
	
	// Metodi, jonka Unity suorittaa automaattisesti kerran framen aikana.
	void Update () {
		Vector3 input = ReadInput();
		Debug.Log(input);
		
		// Mover liikuttaa alusta kerran framessa siihen suuntaan, johon
		// kayttäjä haluaa aluksen liikkuvan.
		mover.Move(input);
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
	
	// Metodi, joka laskee kaksi lukua yhteen.
	// Palauttaa lopputuloksen metodin suorittajalle.
	int Sum ( int first, int second ) 
	{
		int sum = first + second;
		return sum;
	}
}
