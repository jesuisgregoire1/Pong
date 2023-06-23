using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float vertical = 1;
    [SerializeField] private float speed;
    private float paddleMinY = 8.8f;
    private float paddleMaxY = 17.4f;
    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        float posy = Mathf.Clamp(transform.position.y + (vertical * Time.deltaTime * speed), paddleMinY,
            paddleMaxY);
        this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, posy);
    }
}
