using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
	// Kuinka usein aseella voi ampua (sekunteina).
	public float CooldownTime = 0.5f;
	// Viittaus ammus-olioon, josta luodaan kopio aina ammuttaessa.
	public Projectile ProjectilePrefab;
	
	void Update ()
	{
		
	}
}
