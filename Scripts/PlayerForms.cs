using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerForms : MonoBehaviour
{

    public bool isChanging = false;

    public Player player;
    public GameObject p;
    public Transform parent;
    public crusherSwitch cs;
    public CharacterController characterController;
    public Camera camera;

    public GameObject normalRat;
    public GameObject longRat;
    public GameObject ballRat;
    public GameObject springRat;
    public GameObject flatRat;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cs = GetComponent<crusherSwitch>();
        camera = GetComponent<Camera>();
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
            camera.canMove = false;
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

        DestroyRat();
        Instantiate(ballRat, new Vector3(p.transform.position.x, p.transform.position.y, p.transform.position.z), Quaternion.identity, parent);
        //ballRat.transform.position = new Vector3(p.transform.position.x, p.transform.position.y + 1, p.transform.position.z);

        player.gravity = false;
        player.Gravity();
        player.speed = 2.5f;
        player.accelerate = true;
        player.jumpForce = 100f;
        player.canMove = true;
        camera.canMove = true;
        isChanging = false;

    }

    IEnumerator Accordion()
    {
        //Child to Ground
        yield return new WaitForSeconds(2f);

        DestroyRat();
        Instantiate(longRat, new Vector3(p.transform.position.x, p.transform.position.y, p.transform.position.z), Quaternion.identity, parent);
        //longRat.transform.position = new Vector3(p.transform.position.x, p.transform.position.y + 1, p.transform.position.z);

        player.gravity = false;
        player.Gravity();
        player.speed = 5f;
        player.jumpForce = 100f;
        player.accelerate = false;
        player.canMove = true;
        camera.canMove= true;
        isChanging = false;

    }

    IEnumerator Spring()
    {
        //Increase JumpForce. Decreased Spring Mobility (Done)
        yield return new WaitForSeconds(2f);

        DestroyRat();
        Instantiate(springRat, new Vector3(p.transform.position.x, p.transform.position.y, p.transform.position.z), Quaternion.identity, parent);
        //springRat.transform.position = new Vector3(p.transform.position.x, p.transform.position.y + 1, p.transform.position.z);

        player.gravity = false;
        player.Gravity();
        player.speed = 1f;
        player.jumpForce = 300f;
        player.accelerate = false;
        player.canMove = true;
        camera.canMove = true;
        isChanging = false;

    }

    IEnumerator Disk()
    {
        // Gliding. Lower gravity. (Done)
        yield return new WaitForSeconds(2f);

        DestroyRat();
        Instantiate(flatRat, new Vector3(p.transform.position.x, p.transform.position.y, p.transform.position.z), Quaternion.identity, parent);
        //flatRat.transform.position = new Vector3(p.transform.position.x, p.transform.position.y + 1, p.transform.position.z);

        player.gravity = true;
        player.Gravity();
        player.speed = 2.5f;
        player.jumpForce = 50f;
        player.accelerate = false;
        player.canMove = true;
        camera.canMove = true;
        isChanging = false;

    }

    IEnumerator Normal()
    {
        yield return new WaitForSeconds(2f);

        DestroyRat();
        Instantiate(normalRat, new Vector3(p.transform.position.x, p.transform.position.y, p.transform.position.z), Quaternion.identity, parent);
        //normalRat.transform.position = new Vector3(p.transform.position.x, p.transform.position.y + 1, p.transform.position.z);

        player.gravity = false;
        player.Gravity();
        player.speed = 5f;
        player.jumpForce = 100f;
        player.accelerate = false;
        player.canMove = true;
        camera.canMove = true;
        isChanging = false;

    }

    void DestroyRat()
    {
        GameObject[] rats = GameObject.FindGameObjectsWithTag("Rat");
        foreach (GameObject rat in rats)
        {
            Destroy(rat);
        }
    }
}
