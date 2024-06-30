using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carritocontroller : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f; // Establecer la velocidad de rotación en 500 grados por segundo
    [SerializeField] private float moveSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal");
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;

        // Calcular la rotación sin usar Time.deltaTime
        transform.Rotate(0, 0, -steerAmount * rotationSpeed);

        // Realizar el movimiento
        transform.Translate(0, moveAmount * Time.deltaTime, 0);
    }
}