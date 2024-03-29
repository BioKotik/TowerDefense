﻿using UnityEngine;
using UnityEngine.Tilemaps;

public class EnvironmentManager : MonoBehaviour
{
	[SerializeField] private Tilemap decayTilemap;
	[SerializeField] private Tilemap backgroundTilemap;
	private Path[] paths;

	public void Initialize(EnvironmentConfig config)
	{
		this.paths = config.Paths;
	}

	public void Release()
	{
		this.paths = null;
	}

	public Vector3 GetWorldPosition(Vector2Int cell)
	{
		return backgroundTilemap.GetCellCenterWorld(new Vector3Int(cell.x, cell.y, 0));
	}

	public Path GetRandomPath()
	{
		var index = Random.Range(0, paths.Length);
		return paths[index];
	}

	public Path GetPath(int index)
	{
		return paths[index];
	}

	public int GetPathCount()
	{
		return paths.Length;
	}
}
