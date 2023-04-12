using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
//����������
public class PlayerCNTRL : MonoBehaviour
{
    //���������� ��� ����������� �����
    public Text text;
    //�������� �������� ������
    public float speed = 5f;
    //���������� � ������� ������� ����� ����������
    Rigidbody _rb;
    //������� ����
    private int _score = 0;

    private void Awake()
    {
        //�������� ��������� ��� ������������
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //3 ������ ���� �������� �� ������������
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        _rb.AddForce(new Vector3(h, 0, v) * speed);
    }
    private void OnTriggerEnter(Collider other)
    {   //����� �� ������� �������(�����) �� ��������� � ��� ������������ ���� :)
        if (other.gameObject.tag == "AddScore")
        {
            Destroy(other.gameObject);
            _score++;
            if (_score != 4)
             text.text = "Score" + _score;
            else
                text.text = "Ur win GG:" + _score; // :)
            
        }
    }
}
