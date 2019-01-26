using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwapField : MonoBehaviour
{
    [SerializeField]
    List<GameObject> fields;

    public void ChangeLeftPlatform()
    {
        float newPosX = fields.Find(f => f.transform.position.x == fields.Min(p => p.transform.position.x)).transform.position.x - 12.5f;

        GameObject field = fields.Find(f => f.transform.position.x == fields.Max(p => p.transform.position.x));

        field.transform.position = new Vector3(newPosX, field.transform.position.y, field.transform.position.z);
    }

    public void ChangeRightPlatform()
    {
        float newPosX = fields.Find(f => f.transform.position.x == fields.Max(p => p.transform.position.x)).transform.position.x + 12.5f;

        GameObject field = fields.Find(f => f.transform.position.x == fields.Min(p => p.transform.position.x));

        field.transform.position = new Vector3(newPosX, field.transform.position.y, field.transform.position.z);
    }
}
