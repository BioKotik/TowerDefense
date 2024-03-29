﻿
using System;
using UnityEngine;

public class Game
{
	public event System.Action OnLevelPassed;
	public event System.Action OnLevelFailed;

	private Player player;
	private World world;
	private InvasionPlayer invasionPlayer;
	private bool isActive;

	public bool IsActive()
	{
		return isActive;
	}

	public void Play(Level level)
	{
		Reset();

		player = new Player(level.PlayerConfig);
		world = new World();

		world.Initialize(level.LevelViewConfig);
		world.EnemyManager.OnEnemyStop += OnEnemyPassedHandler;

		invasionPlayer = new InvasionPlayer();
		invasionPlayer.Initialize(level.InvasionConfig, world);
		invasionPlayer.SetCallback(OnLevelPassedHandler);
		invasionPlayer.Play();

		isActive = true;
	}

	private void OnEnemyDeadHandler(Enemy enemy)
	{
		AddReward(enemy);
	}

	private void AddReward(Enemy enemy)
	{
		player.Coins += enemy.GetDeathReward();
		Debug.Log(player.Coins);
	}

	public void OnUpdate()
	{
		if (isActive)
		{
			invasionPlayer.OnUpdate();
			world.OnUpdate();
		}
	}

	private void Reset()
	{
		if (world != null)
		{
			world.EnemyManager.OnEnemyDead -= OnEnemyDeadHandler;
			world.EnemyManager.OnEnemyStop -= OnEnemyPassedHandler;
			world.Release();
			world = null;
		}

		invasionPlayer?.Release();
		invasionPlayer = null;
		player = null;
		isActive = false;
	}

	private void OnEnemyPassedHandler(Enemy enemy)
	{
		--player.Health;

		if (player.Health <= 0)
		{
			OnLevelFailed?.Invoke();
			Reset();
		}
	}

	private void OnLevelPassedHandler()
	{
		OnLevelPassed?.Invoke();
	}
}
