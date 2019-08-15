using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{

    [SerializeField] private float shooting_force = 10f;

    Touch input;
    private bool aming = false;
    private bool shooting = false;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            input = Input.GetTouch(0);
            switch (input.phase)
            {
                case TouchPhase.Began:
                    aming = true;
                    break;
                case TouchPhase.Ended:
                    shooting = true;
                    break;
                default:
                    break;
            }
        }

        if (aming)
        {
            Vector2 aming_target = Camera.main.ScreenToWorldPoint((Vector2) input.position);

            GameManagerController.obj.SlowTime();

            if (shooting)
            {
                Vector2 aming_vector = aming_target - (Vector2)transform.position;
                aming_vector.Normalize();
                aming_vector *= shooting_force;
                rb.velocity = Vector2.zero;
                rb.velocity = -aming_vector;

                GameManagerController.obj.NormalTime();

                aming = false;
                shooting = false;
            }
        }
    }
}
