using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    [SerializeField] private float _sensivitasMouse;


    private Transform _parent;

    // Start is called before the first frame update
    void Start()
    {
        _parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Rotasi();
    }
    private void Rotasi() 
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensivitasMouse * Time.deltaTime;

        _parent.Rotate(Vector3.up, mouseX);
    }
}
