using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private int maxHealth = 100;
    
    private Vector2 _direction;
    private Rigidbody2D _rb;
    private int _currentHealth;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentHealth = maxHealth;
    }

    public void ReduceSpeed()
    {
        moveSpeed = 1f;
    }

    public void IncreaseSpeed()
    {
        moveSpeed = 5f;
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        _direction = new Vector2(horizontalInput, verticalInput).normalized;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * (moveSpeed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("fantasma"))
        {
            _currentHealth -= 5;
            if (_currentHealth <= 0)
            {
                // Game Over
                Debug.Log("Game Over");
                // Aquí puedes agregar la lógica para terminar el juego o reiniciar el nivel
            }
            else
            {
                Debug.Log("Player collided with fantasma" + _currentHealth);
            }
        }
    }
}