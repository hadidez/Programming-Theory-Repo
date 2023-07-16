using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    private bool _isAllPlayerInHome;
    private GameObject _selectedPlayerGO;
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
        if(Input.GetMouseButtonDown(0))
        {
            TrySelectPlayer();
        }
    }

    //check is all player in home.
    public bool isAllPlayerInHome()
    {
        return _isAllPlayerInHome;
    }


    private void TrySelectPlayer()
    {
        Player selectedPlayer = CamToRay();
        if (selectedPlayer != null || selectedPlayer != _selectedPlayerGO)
        {
            //deactive all players indicators ...
            OnSelectedPlayerChaned?.Invoke(this, EventArgs.Empty);
            //set indicator for selected player
            selectedPlayer.Select();
            _selectedPlayerGO = selectedPlayer.gameObject;
        }
    }

    //ray from camera to screen on mouse position..........
    private Player CamToRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Debug.Log(hit);
        GameObject hitedGO = hit.transform.gameObject;
        if (hitedGO.TryGetComponent<Player>(out Player player))
        {
            return player;
        }
        return null;
    }

    public GameObject GetSelectedPlayer()
    {
        return _selectedPlayerGO;
    }
}
