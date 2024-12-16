using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class Fisicas : MonoBehaviour
{
    [SerializeField] private float fuerza;
    private float fuerzaSalto;
    [SerializeField] private float saltoMaximo;
    private Rigidbody rb;
    private float hInput, vInput;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        hInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        vInput = UnityEngine.Input.GetAxisRaw("Vertical");


        if (UnityEngine.Input.GetKey(KeyCode.Space))
        {
            fuerzaSalto += 10 * Time.deltaTime;
            fuerzaSalto = Mathf.Min(fuerzaSalto, saltoMaximo);

        }

        if (UnityEngine.Input.GetKeyUp(KeyCode.Space)){
            rb.AddForce(Vector3.up.normalized * fuerzaSalto, ForceMode.Impulse);
            fuerzaSalto = 0f;
        }

        if(gameObject.transform.position.y <= -10)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(hInput, 0, vInput).normalized * fuerza, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coleccionable")
        {
            Destroy(other.gameObject);
        }
    }
}
