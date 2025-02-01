using UnityEngine;
using System.Collections;
public class crusherSwitch : MonoBehaviour
{
    public GameObject playerCrusher;
    public GameObject playerCrushed;
    private GameObject clone;
    public void Crush()
    {
            clone = Instantiate(playerCrusher, new Vector3(playerCrushed.transform.position.x, (playerCrushed.transform.position.y + 5), playerCrushed.transform.position.z), Quaternion.identity);
            Destroy(clone, 3f);
    }
}
