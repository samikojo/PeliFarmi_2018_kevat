using UnityEngine;

public class Health : MonoBehaviour
{
	public int StartingHealth;
	public int MaxHealth;

	private int currentHealth;

	public int CurrentHealth
	{
		get { return currentHealth; }
		// Mathf.Clamp pitää huolen siitä, että arvo on aina minimi ja 
		// maksimiarvon välillä.
		// Private määre setterin edessä tarkoittaa sitä, että propertyn
		// arvoa ei voi asettaa luokan ulkopuolelta.
		private set { currentHealth = Mathf.Clamp( value, 0, MaxHealth ); }
	}

	private void Awake()
	{
		CurrentHealth = StartingHealth;
	}

	/// <summary>
	/// Kasvattaa hitpointien määrää parametrin amount verran. Arvo ei voi
	/// koskaan kasvaa suuremmaksi kuin MaxHealth.
	/// </summary>
	/// <param name="amount">Määrä jolla hitpointeja kasvatetaan.</param>
	public void IncreaseHealth( int amount )
	{
		//CurrentHealth = CurrentHealth + amount;
		CurrentHealth += amount;
	}

	/// <summary>
	/// Vähentää hitpointeja parametrin amount verran. Arvo ei voi koskaan
	/// mennä pienemmäksi kuin 0.
	/// </summary>
	/// <param name="amount">Määrä, jolla hitpointeja vähennetään.</param>
	/// <returns>True, jos hahmo säilyy hengissä. False muuten.</returns>
	public bool DecreaseHealth( int amount )
	{
		CurrentHealth -= amount;
		return CurrentHealth > 0;
	}
}
