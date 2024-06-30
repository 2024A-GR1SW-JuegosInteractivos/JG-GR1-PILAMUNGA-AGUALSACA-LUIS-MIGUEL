// fantasmaverticalcontroller
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fantasmaverticalcontroller : MonoBehaviour
{
    public float minMoveSpeed = 1f;
    public float maxMoveSpeed = 5f;
    public float topPosition = 5f;
    public float bottomPosition = -5f;
    public bool startMovingUp = true;

    private float _moveSpeed;
    private int _direction;
    private Tilemap _tilemap;
    private Vector3Int _tilePosition;

    private void Start()
    {
        _moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        _direction = startMovingUp ? 1 : -1;
        _tilemap = FindObjectOfType<Tilemap>();
        _tilePosition = GetTilePosition();
    }

    private void Update()
    {
        float newYPosition = transform.position.y + _direction * _moveSpeed * Time.deltaTime;

        if (newYPosition > topPosition || newYPosition < bottomPosition)
        {
            _direction *= -1;
        }

        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    private Vector3Int GetTilePosition()
    {
        Vector3 worldPosition = transform.position;
        worldPosition.x = Mathf.Round(worldPosition.x);
        worldPosition.y = Mathf.Round(worldPosition.y);
        return _tilemap.WorldToCell(worldPosition);
    }
}