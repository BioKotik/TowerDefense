using UnityEngine;

public static class QuaternionUtility
{
	public static Quaternion LookRotation2D(Vector3 direction)
	{
		var rotatedDirection = Quaternion.Euler(0, 0, 90) * direction;
		return Quaternion.LookRotation(Vector3.forward, rotatedDirection);
	}
}
