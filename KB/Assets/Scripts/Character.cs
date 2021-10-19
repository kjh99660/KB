using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject userCharacter;
    public GameObject MainCharacter;
    [Header("�ؽ���(��)_�׽�Ʈ")]
    public Material[] clothes;
    [Space(20)]
    private UIManager UM;
    private SkinnedMeshRenderer character;
    private SkinnedMeshRenderer character_main;
    private int clothes_up;
    
    
    /// <summary>
    /// ĳ���� �� UI ��ư
    public void ChangeClothesRight()
    {
        int MaxSize = clothes.Length - 1;
        clothes_up++;
        if (clothes_up > MaxSize) clothes_up = 0;
        Debug.Log(clothes_up);
        character.material = clothes[clothes_up];
        character_main.material = clothes[clothes_up];

    }
    public void ChangeClothesLeft()
    {
        clothes_up--;
        if (clothes_up < 0) clothes_up = clothes.Length - 1;
        Debug.Log(clothes_up);
        character.material = clothes[clothes_up];
        character_main.material = clothes[clothes_up];
    }
    public void EnterGame()
    {
        UM.OpenCanvas(2);
        UM.MoveFirstFloor();
    }
    /// ĳ���� �� UI ��ư
    /// </summary>
    public void MoveMain()
    {
        UM.OpenCanvas(0);
        UM.OpenCanvasBack(0);
    }
    public void MoveChangeCharacter()
    {
        UM.OpenCanvas(1);
        UM.OpenCanvasBack(1);
    }
    private void OnEnable()
    {
        Init();
        UM = UIManager.Instance;
        MoveMain();      
    }
    private void Init()
    {
        character = userCharacter.GetComponent<SkinnedMeshRenderer>();
        character_main = MainCharacter.GetComponent<SkinnedMeshRenderer>();
        clothes_up = 0;
    }
}
