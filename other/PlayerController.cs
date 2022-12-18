using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MyGameObject
{
    public Camera camera;
    public float Speed;
    public float JumpForce;

    void FixedUpdate()
    {
        var is_move = Input.GetAxis("Horizontal");
        if (is_move != 0)
        {
            var direction = (is_move > 0) ? Vector2.right : Vector2.left;

            Move2D(direction, Speed);
        }

        var space_down = Input.GetKeyDown(KeyCode.Space);
        if (space_down)
        {
            Jump2D(JumpForce);
        }

        var fight_button_clicked = Input.GetMouseButtonDown(0);
        if(fight_button_clicked)
        {
            var gameobjects = SceneManager.GetActiveScene().GetRootGameObjects();
            var quaery = from GameObject gameobject in gameobjects
                         where gameobject.CompareTag("Enemy")
                         select gameobject.GetComponent<MyGameObject>();

            foreach (var obj in quaery)
            {
                if (obj == null) continue;

                if (Vector3.Distance(obj.transform.position, transform.position) < fight_collider.bounds.size.x)
                {
                    Fight2D(obj);
                }
            }
        }
    }
}
