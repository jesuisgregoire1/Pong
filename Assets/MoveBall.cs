using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class MoveBall : MonoBehaviour
{
	private Vector3 ballStartPosition;
	private Rigidbody2D rb;
	private float speed = 400;
	public AudioSource blip;
	public AudioSource blop;
	private int scorePlayer = 0, scoreAi=0;

	private void OnGUI()
	{
		print("height = " + Screen.height + "width = " + Screen.width);
		GUI.Label(new Rect(10, 10, 100, 20), "Score : " + scorePlayer );
		GUI.Label(new Rect(Screen.width-100, 10, 100, 20), "Score : " + scoreAi);
		print("HEre");

	}

	private void Start()
	{
		//ballStartPosition = new Vector3(Screen.width / 2, Screen.height / 2, this.transform.position.z);
		rb = gameObject.GetComponent<Rigidbody2D>();
		ballStartPosition = this.transform.position;
		ResetBall();
	}

	private void ResetBall()
	{
		this.transform.position = ballStartPosition;
		rb.velocity = Vector2.zero;
		Vector2 dir = new Vector2(Random.Range(100, 300), Random.Range(-100, 100)).normalized;
		rb.AddForce(dir * speed);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Respawn"))
		{
			ResetBall();
			blop.Play();
		}
		else if(collision.gameObject.CompareTag("Player"))
		{
			scoreAi++;
		}
		else if(collision.gameObject.CompareTag("Ai"))
		{
			scorePlayer++;
		}
		else
		{
			blip.Play();
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			ResetBall();
		}
	}
}
