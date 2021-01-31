using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PickItemFromScene : MonoBehaviour
{
    [SerializeField] int layerNumberToPick = 8;

    PlayerController player;
    PlayerControls controls;
    ItemController prevItem = null;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Action1.performed += _ => {
            ItemController item = pickItem();
            if (item != null)
                player.Action1(item);
        };
        controls.Player.Action2.performed += _ => {
            ItemController item = pickItem();
            if (item != null)
                player.Action2(item);
        };

        controls.Player.Quit.performed += _ =>
        {
            SceneManager.LoadScene(0);
        };
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    ItemController pickItem()
    {
        Vector3 dir = Camera.main.transform.forward;
        Vector3 pos = Camera.main.transform.position;
        int layerMask = 1 << layerNumberToPick;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(pos, dir, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(pos, dir * hit.distance, Color.yellow);
            return hit.transform.gameObject.GetComponent<ItemController>();
        }
        else
        {
            Debug.DrawRay(pos, dir * hit.distance, Color.white);
        }

        return null;
    }

    void Update()
    {
        ItemController item = pickItem();
        if(prevItem == null && item != null)
        {
            // Item highlight
            item.highlight();
        }
        else if(prevItem != null && item == null)
        {
            // Item unhighlinght
            prevItem.unHighlight();
        }
        prevItem = item;
    }
}
