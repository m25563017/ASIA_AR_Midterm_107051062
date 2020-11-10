using UnityEngine;

public class Gamemanger : MonoBehaviour
{
    [Header("粉")]
    public Transform pink;
    [Header("藍")]
    public Transform blue;
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("旋轉速度"), Range(0.1f, 5f)]
    public float turn = 2f;
    [Header("縮放"), Range(0f, 3f)]
    public float size = 0.5f;
    [Header("粉動畫控制")]
    public Animator anipink;
    [Header("藍動畫控制")]
    public Animator aniblue;

    private void Start()
    {
        print("STATR");
    } 
    private void Update()
    {
        print("更新事件");
        print(joystick.Vertical);              

        pink.Rotate(0, joystick.Horizontal * turn, 0);          
        blue.Rotate(0, joystick.Horizontal * turn, 0);

       
        pink.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;                 
        pink.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(pink.localScale.x, 0.5f, 5f); 

        blue.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;
        blue.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(blue.localScale.x, 0.5f, 5f);

       
    }

    public void PlayAnimation(string aniName)
    {
        print(aniName);
        anipink.SetTrigger(aniName);
        aniblue.SetTrigger(aniName);
    }
}