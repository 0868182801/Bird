using UnityEngine;

public class WallMove : MonoBehaviour
{
    // Chữ cái từ đầu tiên vt THƯỜNG viết liền vs chữ cái từ tiếp theo vt HOA --> Hiển thị 1 dòng thuộc tính mới trong giao diện của đối tượng unity
    public float moveSpeed; // tạo thêm 1 thuộc tính cho đối tượng hiển thị ngay trong unity là: Move Speed (di chuyển background)
    public float minY;
    public float maxY;
    public float oldPosition;    // vị trí trc khi di chuyển
    private GameObject obj;
    void Start()
    {
        obj = gameObject;
        oldPosition = 13;
        moveSpeed = 2;
        minY = -1;
        maxY = 1;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag.Equals("ResetWall"))
            obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);
    }
}
