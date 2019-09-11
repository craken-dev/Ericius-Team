using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class UccelloAlieno : MonoBehaviour
{
    [Range(.1f, 5f)] [SerializeField] private float speed = 1f;
    [SerializeField] private Transform[] posizioni;

    private int next_pos_index = 0;
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, posizioni[next_pos_index].position, speed * Time.deltaTime);
        if(transform.position == posizioni[next_pos_index].position)
        {
            next_pos_index++;
            if (next_pos_index == posizioni.Length)
            {
                next_pos_index = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            GameManagerController.obj.EndGame();
        }   
    }

    private void OnDrawGizmosSelected()
    {
        for(int i = 0; i < posizioni.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(posizioni[i].position, .5f);
            int next = i + 1;
            if(next == posizioni.Length)
            {
                next = 0;
            }

            Gizmos.DrawLine(posizioni[i].position, posizioni[next].position);
        }
    }
}
