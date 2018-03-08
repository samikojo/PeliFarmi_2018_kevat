using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
	// Kuinka usein aseella voi ampua (sekunteina).
	public float CooldownTime = 0.5f;
	// Viittaus ammus-olioon, josta luodaan kopio aina ammuttaessa.
	public Projectile ProjectilePrefab;
	
	private float cooldownTimer = 0f;
	
	private void Awake()
	{
		cooldownTimer = CooldownTime;
	}
	
	// Property, jonka arvon voi lukea, muttei asettaa. Mikäli propertyn arvo
	// halutaan asettaa, on myös setteri määritettävä.
	public bool CanShoot
	{
		get
		{
			return cooldownTimer >= CooldownTime;
		}
	}
	
	// Ampuu ammuksen. Jos ampuminen onnistuu, palauttaa true. Muuten false.
	public bool Shoot()
	{
		// Onnistuuko ampuminen vai ei?
		bool result = false;
		// Verrataan CanShoot propertyn arvoa arvoon 'true'. Mikäli CanShoot
		// on tosi, ampuminen onnistuu ja if-lohkon sisällä oleva koodi
		// suoritetaan.
		if ( CanShoot == true )
		{
			result = true;
			// Ampuminen onnistuu, luodaan ammus
			Projectile projectile = Instantiate( ProjectilePrefab,
				transform.position, transform.rotation );
			// transform.up osoittaa ylöspäin aseen koordinaatistossa. Maailman
			// koordinaatistossa suunta riippuu aseen rotaatiosta.
			projectile.Launch(transform.up);
			cooldownTimer = 0;
		}
		
		return result;
	}
	
	void Update ()
	{
		if(CanShoot == false)
		{
			// Ase on cooldown-tilassa, ampuminen ei onnistu.
			// Päivitä cooldownTimer muuttujaa.
			// cooldownTimer = cooldownTimer + Time.deltaTime;
			cooldownTimer += Time.deltaTime;
		}
	}
}
