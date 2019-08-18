using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController obj;

    [Range(1, 0)] [SerializeField] private float slow_time_factor = .4f;
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
        Time.timeScale = slow_time_factor;
        Time.fixedDeltaTime = .02f * Time.timeScale;
    }

    public void NormalTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = .02f;
    }

}
