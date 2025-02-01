using UnityEngine;
using System.Collections;
public class crusherSwitch : MonoBehaviour
{
    public GameObject playerCrusher;
    public GameObject playerCrushed;
    private GameObject clone;
    IEnumerator DestroyBox(GameObject box)
    {
        yield return new WaitForSeconds(.5f);
        Destroy(box);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            clone = Instantiate(playerCrusher, new Vector3(playerCrushed.transform.position.x, (playerCrushed.transform.position.y + 5), playerCrushed.transform.position.z), Quaternion.identity);
            DestroyBox(clone);
        }
    }
}
