
public class Player
{
	public Player(PlayerConfig config)
	{
		this.Health = config.Health;
		this.Coins = config.Coins;
	}

	public int Health;
	public int Coins;
}
