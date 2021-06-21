using UnityEngine;

public class Enemy : MonoBehaviour
{
	public event System.Action OnDead;
	public event System.Action OnStop;

	[SerializeField] private int hp;
	[SerializeField] private float movementSpeed;
	[SerializeField] private int reward;

	[SerializeField] private Path path;
	[SerializeField] private int currentPositionIndex;

	public bool IsDead()
	{
		return hp == 0;
	}

	public void OnHit(int damage)
	{
		hp -= damage;

		if (hp <= 0)
		{
			hp = 0;
			gameObject.SetActive(false);
			OnDead?.Invoke();
		}
	}

	public int GetDeathReward()
	{
		return reward;
	}

	public void Construct(EnemyConfig config)
	{
		this.hp = config.Hp;
		this.movementSpeed = config.MovementSpeed;
		this.reward = config.Reward;
		ResetMovement();
	}

	public void SetPath(Path path)
	{
		this.path = path;
	}

	public void OnUpdate()
	{
		if (path == null || IsDead())
		{
			return;
		}

		MoveAlongPath(Time.deltaTime);
	}

	public void MoveAlongPath(float deltaTime)
	{
		while (deltaTime > 0f)
		{
			var destination = path[currentPositionIndex];
			var distance = Vector3.Distance(transform.position, destination);
			var timeToReachPoint = distance / movementSpeed;

			if (timeToReachPoint < deltaTime)
			{
				deltaTime -= timeToReachPoint;
				++currentPositionIndex;

				if (currentPositionIndex >= path.Length)
				{
					ResetMovement();
					OnStop?.Invoke();
					return;
				}

				continue;
			}

			destination.z = transform.position.z;

			var direction = (destination - transform.position).normalized;

			transform.rotation = QuaternionUtility.LookRotation2D(direction);
			transform.position += (direction * movementSpeed * deltaTime);

			deltaTime = 0f;
		}
	}

	private void ResetMovement()
	{
		this.path = null;
		this.currentPositionIndex = 0;
	}
}
