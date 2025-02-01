using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerForms : MonoBehaviour
{

    public bool isChanging = false;

    public Player player;
    public crusherSwitch cs;

    // Start is called before the first frame update
    void Start()
    {
        cs = GetComponent<crusherSwitch>();
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
        if (Input.GetKeyDown(KeyCode.Alpha0))
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
            cs.Crush();
            isChanging = true;
            player.canMove = false;
            switch (num)
            {
                case 1: StartCoroutine(Accordion());
                    break;
                case 2: StartCoroutine(Ball());
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
        //Animation Spin. Acceleration. (Acceleration Done)
        yield return new WaitForSeconds(2f);
        player.gravity = false;
        player.Gravity();
        player.speed = 2.5f;
        player.accelerate = true;
        player.jumpForce = 100f;
        player.canMove = true;
        isChanging = false;
        
    }

    IEnumerator Accordion()
    {
        //Child to Ground
        yield return new WaitForSeconds(2f);
        player.gravity = false;
        player.Gravity();
        player.speed = 5f;
        player.jumpForce = 100f;
        player.accelerate = false;
        player.canMove = true;
        isChanging = false;
    }

    IEnumerator Spring()
    {
        //Increase JumpForce. Decreased Spring Mobility (Done)
        yield return new WaitForSeconds(2f);
        player.gravity = false;
        player.Gravity();
        player.speed = 1f;
        player.jumpForce = 300f;
        player.accelerate = false;
        player.canMove = true;
        isChanging = false;
    }

    IEnumerator Disk()
    {
        // Gliding. Lower gravity. (Done)
        yield return new WaitForSeconds(2f);
        player.gravity = true;
        player.Gravity();
        player.speed = 2.5f;
        player.jumpForce = 50f;
        player.accelerate = false;
        player.canMove = true;
        isChanging = false;
    }

    IEnumerator Normal()
    {
        yield return new WaitForSeconds(2f);
        player.gravity = false;
        player.Gravity();
        player.speed = 5f;
        player.jumpForce = 100f;
        player.accelerate = false;
        player.canMove = true;
        isChanging = false;
    }
}
