using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float shooting_force = 400f;

    [Header("Timers")]
    [SerializeField] private float max_aming_time = 2f;
    [SerializeField] private float reload_time = .5f;

    private bool aming = false;
    private bool shooting = false;

    private float aming_timer = 0f;
    private float reload_timer = 0f;

    Vector2 touch_pos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ManageTouchInput();
        if (aming && reload_timer >= reload_time)
        {
            if (shooting || aming_timer >= max_aming_time)
            {
                Vector2 shoot_direction = touch_pos - (Vector2)transform.position;
                Shoot(shoot_direction);

                aming_timer = 0f;
                reload_timer = 0f;

                aming = false;
                shooting = false;
            }
            else
            {
                touch_pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                aming_timer += Time.unscaledDeltaTime;
            }
        }
        else
        {
            aming = false;
            shooting = false;
        }

        reload_timer += Time.unscaledDeltaTime;
    }

    private void Shoot(Vector2 dir)
    {
        Debug.Log("Shooting");
        dir.Normalize();
        dir *= shooting_force;

        rb.velocity = Vector2.zero;
        rb.AddForce(-dir);
    }

    private void ManageTouchInput()
    {
        Touch input;
        if (Input.touchCount > 0)
        {
            input = Input.GetTouch(0);

            switch (input.phase)
            {
                case TouchPhase.Began:
                    aming = true;
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                        shooting = true;
                    break;
                case TouchPhase.Canceled:
                    shooting = true;
                    break;
                default:
                    break;
            }
        }
    }
}
