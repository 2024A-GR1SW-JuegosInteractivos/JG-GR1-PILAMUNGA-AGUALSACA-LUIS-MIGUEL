// fantasmahorizontalcontroller
using UnityEngine;

public class Fantasmahorizontalcontroller : MonoBehaviour
{
    public float minMoveSpeed = 1f;
    public float maxMoveSpeed = 5f;
    public float leftPosition = -5f;
    public float rightPosition = 5f;
    public bool startMovingRight = true;

    private float _moveSpeed;
    private int _direction;

    private void Start()
    {
        _moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        _direction = startMovingRight ? 1 : -1;
    }

    private void Update()
    {
        float newXPosition = transform.position.x + _direction * _moveSpeed * Time.deltaTime;

        if (newXPosition > rightPosition || newXPosition < leftPosition)
        {
            _direction *= -1;
        }

        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}