using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController obj;
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

}
