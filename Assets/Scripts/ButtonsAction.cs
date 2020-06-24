
using UnityEngine;

public class ButtonsAction : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
    }
}
 