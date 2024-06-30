using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // variables
    [SerializeField] float steerSpeed = 0.10f;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float addSpeed = 1f;
    [SerializeField] float minSpeed = 2f;
    [SerializeField] float maxSpeed = 20f;
    [SerializeField] float initialSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * -1 * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        // rotar el objeto
        transform.Rotate(0, 0, steerAmount);
        // mover el objeto
        transform.Translate(0,  moveAmount, 0);

        // Verificar si el objeto se detuvo o dejó de moverse
        if (Mathf.Abs(moveAmount) < 0.001f)
        {
            moveSpeed = initialSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("rapido"))
        {
            moveSpeed = Mathf.Clamp(moveSpeed + addSpeed, minSpeed, maxSpeed);
            Debug.Log("Rapido " + moveSpeed);
        }

        if (collision.gameObject.CompareTag("lento"))
        {
            moveSpeed = Mathf.Clamp(moveSpeed - addSpeed, minSpeed, maxSpeed);
            Debug.Log("Lento" + moveSpeed);
        }
    }

}