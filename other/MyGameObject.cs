using UnityEngine;

public class MyGameObject : MonoBehaviour
{
    protected Rigidbody2D rigidbody;
    protected BoxCollider2D collider;
    public GameObject usability_collider_object;
    public GameObject fight_collider_object;

    protected BoxCollider2D usability_collider;
    protected CircleCollider2D fight_collider;

    public float MaxHealth = 100;
    public float Health = 100;
    public float Strenght = 10;

    public void Start()
    {
        this.rigidbody = gameObject.GetComponent<Rigidbody2D>();
        this.collider = gameObject.GetComponent<BoxCollider2D>();
        this.usability_collider = usability_collider_object.GetComponent<BoxCollider2D>();
        this.fight_collider = fight_collider_object.GetComponent<CircleCollider2D>();
    }

    public void Move2D(Vector2 direction, float Speed)
    {
        transform.Translate(direction.x * Speed * Time.deltaTime, 0, 0);
    }
    public void Jump2D(float Force, float eps = 0.1f)
    {
        var start_pos = transform.position - new Vector3(0, transform.localScale.y / 2 + 0.1f);
        var distance_to_the_graund = Physics2D.Raycast(start_pos, Vector2.down);

        if (distance_to_the_graund.collider == null) return;
        if (distance_to_the_graund.distance < eps)
        {
            rigidbody.AddForce(Vector2.up * Force);
        }
    }
    public static void Kill(MyGameObject target)
    {
        Destroy(target.gameObject);
    }
    public void Fight2D(MyGameObject target)
    {
        if (target == null) return;

        target.Health -= this.Strenght;

        if (target.Health <= 0)
        {
            Kill(target);
        }
    }
}
