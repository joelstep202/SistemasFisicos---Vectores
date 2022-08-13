using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBolita : MonoBehaviour
{
    public Camera camera;
    private MyVector position;
    private MyVector displacement;
    [SerializeField] private MyVector velocity;

    // Start is called before the first frame update
    void Start()
    {
        position = new MyVector(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        position.Draw(Color.blue);
        displacement.Draw(Color.red);

        Move();
    }

    public void Move()
    {
        position = position + velocity * Time.deltaTime;

        if(Mathf.Abs(transform.position.x) > camera.orthographicSize)
        {
            displacement.x = displacement.x * -1;
            position.x = Mathf.Sign(position.x) * camera.orthographicSize;
        }
        if (Mathf.Abs(transform.position.y) > camera.orthographicSize)
        {
            displacement.y = displacement.y * -1;
            position.y = Mathf.Sign(position.y) * camera.orthographicSize;
        }
        transform.position = new Vector3(position.x, position.y);
    }
}
