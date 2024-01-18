using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    public float speed = 5f;

    public string movementAxisName = "Vertical";

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (isPlayer)
                  spriteRenderer.color = SavedController.Instance.colorPlayer;
        else
                  spriteRenderer.color = SavedController.Instance.colorEnemy;
        
    }

    void Update()
    {
        float moveInput = Input.GetAxis(movementAxisName);

        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

        transform.position = newPosition;

    }
}
