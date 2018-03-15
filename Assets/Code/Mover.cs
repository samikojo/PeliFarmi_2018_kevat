using UnityEngine;

public class Mover : MonoBehaviour
{
	// Jäsenmuuttuja, joka määrittää aluksen nopeuden.
	// public-määre tekee muuttujasta muokattavan Unityn puolella.
	public float Speed;

	public void Move( Vector3 direction )
	{
		// Aluksen tämänhetkinen sijainti pelimaailmassa
		Vector3 position = transform.position;

		// Normalisoidaan suuntavektori, jotta sitä voidaan käyttää
		// laskuissa. Normalisoitu vektori on alkuperäisen vektorin
		// kanssa samaan suuntaan osoittava yhden mittainen vektori.
		direction = direction.normalized;

		// Uusi sijainti on vanha sijainti + suunta * vauhti (nopeus).
		// Nopeus pitää kertoa Time.deltaTimella (ajalla, joka on kulunut
		// edellisen framen suorittamisesta), jotta liikuttaisimme alusta
		// yksikköä/s eikä yksikköä/frame. Uusi sijainti sijoitetaan position
		// muuttujaan, jolloin se korvaa vanhan sijainnin arvon.
		position = position + direction * Speed * Time.deltaTime;

		// Kerrotaan Unitylle uusi sijainti sijoittamalla laskun tulos
		// transform.position muuttujaan.
		transform.position = position;
	}
}
