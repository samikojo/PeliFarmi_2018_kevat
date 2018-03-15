using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Bomb : MonoBehaviour, IDestroyable
{
	public Health HitPoints
	{
		get; private set;
	}

	private void Awake()
	{
		HitPoints = GetComponent<Health>();
	}

	public void Die()
	{
		// TODO: Tee vahinkoa lähellä oleviin aluksiin
		gameObject.SetActive(false);
	}
}
