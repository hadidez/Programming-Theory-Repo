using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    private Player _selectedPlayer;
    [SerializeField] private LayerMask _playerLayerMask;
    public static PlayerManager Instance { get; private set; }
    public event EventHandler OnSelectedPlayerChaned;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Multiple Instance!");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //left mouse button clicked!
        if(Input.GetMouseButtonDown(0))
        {
            DoActionBySelectObject();
        }
        //right mouse button clicked!
        if(Input.GetMouseButtonDown(1))
        {
            DeSelectAll();
        }
    }

    private void DoActionBySelectObject()
    {
        RaycastHit hitedObject = SelectObject();
        if (hitedObject.transform.gameObject == null)
            return;
        switch (hitedObject.transform.gameObject.tag)
        {
            //select player
            case "Player":
                TrySelectPlayer(hitedObject);
                break;
            //move player
            case "Ground":
                TryMoveOnTarget(hitedObject);
                break;
        }
    }

    private void TrySelectPlayer(RaycastHit hitedObject)
    {
        if(hitedObject.transform.TryGetComponent<Player>(out Player candidatePlayer))
        {
            if (candidatePlayer != _selectedPlayer)
            {
                DeSelectAll();
                //set indicator for selected player
                candidatePlayer.Select();
                _selectedPlayer = candidatePlayer;
            }
        }
        
    }

    //try to move player
    private void TryMoveOnTarget(RaycastHit hitedObject)
    {
        if (_selectedPlayer == null)
            return;
        _selectedPlayer.Move(hitedObject.point);
    }



    //ray from camera to screen on mouse position..........
    private RaycastHit SelectObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        return hit;
    }

    private void DeSelectAll()
    {
        //deactive all players indicators ...
        OnSelectedPlayerChaned?.Invoke(this, EventArgs.Empty);
        _selectedPlayer = null;
    }

    public GameObject GetSelectedPlayer()
    {
        if (_selectedPlayer != null)
            return _selectedPlayer.gameObject;
        else
            return null;
    }
}
