using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController obj;

    [SerializeField] private float slow_time_factor = 0.04f;
    private bool is_time_slowed = false;
    private void Awake()
    {
        if(obj == null)
        {
            obj = this;
        }
        else if(obj != this)
        {
            Destroy(gameObject);
        }
    }

    public void SlowTime()
    {
        if (!is_time_slowed)
        {
            Time.timeScale = slow_time_factor;
            Time.fixedDeltaTime = 1 / 50 * slow_time_factor;
            is_time_slowed = true;
        }
    }

    public void NormalTime()
    {
        if (is_time_slowed)
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 1 / 50;
            is_time_slowed = false;
        }
    }


}
