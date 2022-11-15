using UnityEngine;

public class Rocket : MonoBehaviour
{
    public static Rocket RocketScript;

    private void Awake()
    {
        if (RocketScript != null) Destroy(this);

            RocketScript = this;
    }
}
