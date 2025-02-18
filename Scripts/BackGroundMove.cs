using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    // Chữ cái từ đầu tiên vt THƯỜNG viết liền vs chữ cái từ tiếp theo vt HOA --> Hiển thị 1 dòng thuộc tính mới trong giao diện của đối tượng unity
    public float moveSpeed; // tạo thêm 1 thuộc tính cho đối tượng hiển thị ngay trong unity là: Move Speed (di chuyển background)
    public float moveRange; // khoảng cách chỉ định lặp lại di chuyển background từ điểm bắt đầu

    private Vector3 oldPosition;    // vị trí trc khi di chuyển
    private GameObject obj;
    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, transform.position.y, 0));

        if (Vector3.Distance(oldPosition, obj.transform.position) > moveRange ) {  // Distance(a,b): tính khoảng cách của 2 vector a và b
            obj.transform.position = oldPosition;
        }
    }
}
