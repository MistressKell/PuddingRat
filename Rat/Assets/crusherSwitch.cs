using UnityEngine;
public class crusherSwitch : MonoBehaviour
{
    public GameObject playerCrusher;
    public GameObject playerCrushed;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(playerCrusher, new Vector3(playerCrushed.transform.position.x, (playerCrushed.transform.position.y + 5), playerCrushed.transform.position.z), Quaternion.identity);
        }
    }
}
