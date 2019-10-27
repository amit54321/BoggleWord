
using UnityEngine;

public class Loader : MonoBehaviour
{
   public void Load()
    {
        gameObject.SetActive(true);
    }

    public void UnLoad()
    {
        gameObject.SetActive(false);
    }
}
