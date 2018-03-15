public class EnemySpaceship : Spaceship
{
	private void Start()
	{
		// Vihollisalus tuhoutuu automaattisesti sekunnin kuluttua sen luomisesta.
		Destroy(gameObject, 1f);
	}

	protected void Update()
	{
		Shoot();
		// Move down
		Mover.Move(transform.up * -1);
	}
}
