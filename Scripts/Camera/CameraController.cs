using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public float Softness = 1f;
    public Vector3 ConstantOffSet = new Vector3(3, 3, 0);
    public bool UseMoveBasedOffset = true;
    public float MoveBasedOffsetMultiplier = 0.1f;
    public float MaxMoveBasedOffset = 2f;

    public Vector3 currentOffset;
    public Vector3 TargetOffset;
    public float OffsetSoftness = 1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetOffset = ConstantOffSet;
        if (UseMoveBasedOffset) {
            TargetOffset.x = TargetOffset.x + Mathf.Clamp(Target.gameObject.GetComponent<Rigidbody2D>().velocity.x * MoveBasedOffsetMultiplier, -MaxMoveBasedOffset, MaxMoveBasedOffset);
            TargetOffset.y = TargetOffset.y + Mathf.Clamp(Target.gameObject.GetComponent<Rigidbody2D>().velocity.y * MoveBasedOffsetMultiplier, -MaxMoveBasedOffset, MaxMoveBasedOffset);
        }
        currentOffset = currentOffset + ((TargetOffset-currentOffset) * OffsetSoftness);
        Vector3 diff = (Target.position+currentOffset)-transform.position;
        diff.z = 0;
        transform.position += diff * Softness;
    }
}
