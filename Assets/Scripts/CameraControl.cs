using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _normalRotateSpeed=10;
    private bool _isCamInState = true;

    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.OnSelectedPlayerChaned += PlayerManager_OnSelectedPlayerChaned;
    }

    private void PlayerManager_OnSelectedPlayerChaned(object sender, System.EventArgs e)
    {
        _isCamInState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isCamInState)
        {
            RotateCam();
            CamZoom();
        }
        else
        {
            GoCamToSelectedObject();
        }

    }

    private void GoCamToSelectedObject()
    {
        if (PlayerManager.Instance.GetSelectedPlayer() != null)
        { 
            Transform selectedPlayerTM = PlayerManager.Instance.GetSelectedPlayer().transform;
            Vector3 direction = (selectedPlayerTM.position - transform.position).normalized;
            if (Vector3.Distance(transform.position, selectedPlayerTM.position) > .4f)
            {
                transform.position += Time.deltaTime * direction * 10f;
            }
            else
            {
                //finish moving camera to selected object
                _isCamInState = true;
            }
        }
    }

    private void RotateCam()
    {
        float rotateSpeed = _normalRotateSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rotateSpeed = _normalRotateSpeed * 5;
        }
        else
        {
            rotateSpeed = _normalRotateSpeed;
        }
        float axix = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * axix * rotateSpeed);
    }

    private void CamZoom()
    {
        Camera.main.fieldOfView += Input.mouseScrollDelta.y * Time.deltaTime * 5f;
    }
}
