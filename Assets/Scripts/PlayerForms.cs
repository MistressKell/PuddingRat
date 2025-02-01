using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerForms : MonoBehaviour
{

    public bool isChanging = false;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Change(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Change(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Change(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Change(4);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Change(0);
        }
    }

    public Coroutine Change(int num)
    {
        if(isChanging)
        {
            return null;
        }
        else
        {
            isChanging = true;
            player.canMove = false;
            switch (num)
            {
                case 1: StartCoroutine(Ball());
                    break;
                case 2: StartCoroutine(Accordion());
                    break;
                case 3: StartCoroutine(Spring());
                    break;
                case 4: StartCoroutine(Disk());
                    break;
                default: StartCoroutine(Normal());
                    break;
            }
        }

        return null;
    }

    IEnumerator Ball()
    {
        yield return new WaitForSeconds(2f);
        player.speed = 2.5f;
        player.jumpForce = 100f;
        player.canMove = true;
        isChanging = false;
        
    }

    IEnumerator Accordion()
    {
        yield return new WaitForSeconds(2f);
        player.speed = 5f;
        player.jumpForce = 100f;
        player.canMove = true;
        isChanging = false;
    }

    IEnumerator Spring()
    {
        yield return new WaitForSeconds(2f);
        player.speed = 4f;
        player.jumpForce = 300f;
        player.canMove = true;
        isChanging = false;
    }

    IEnumerator Disk()
    {
        yield return new WaitForSeconds(2f);
        player.speed = 2.5f;
        player.jumpForce = 50f;
        player.canMove = true;
        isChanging = false;
    }

    IEnumerator Normal()
    {
        yield return new WaitForSeconds(2f);
        player.speed = 5f;
        player.jumpForce = 100f;
        player.canMove = true;
        isChanging = false;
    }
}
