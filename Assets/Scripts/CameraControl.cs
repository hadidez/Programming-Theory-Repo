using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    private GameObject selectedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.OnSelectedPlayerChaned += PlayerManager_OnSelectedPlayerChaned;
    }

    private void PlayerManager_OnSelectedPlayerChaned(object sender, System.EventArgs e)
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        float rotateSpeed = _rotateSpeed;
        if(PlayerManager.Instance.GetSelectedPlayer()!=null)
        {
            Transform selectedPlayerTM = PlayerManager.Instance.GetSelectedPlayer().transform;
            Vector3 direction = (selectedPlayerTM.position - transform.position).normalized;
            if(Vector3.Distance(transform.position,selectedPlayerTM.position)>.4f)
            {
                transform.position += Time.deltaTime * direction * 10f;
            }
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            rotateSpeed = _rotateSpeed * 5;
        }
        else
        {
            rotateSpeed = _rotateSpeed;
        }
        float axix = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * axix * rotateSpeed);

        Camera.main.fieldOfView += Input.mouseScrollDelta.y * Time.deltaTime * 5f;

       
    }
}
