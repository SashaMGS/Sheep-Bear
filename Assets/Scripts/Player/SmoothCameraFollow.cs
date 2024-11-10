using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    // ���������� ��� ������ �� ������, �� ������� ����� ������� ������
    public Transform target;

    // ������ ��� �������� ������ ������������ �������
    public Vector3 offset;

    // ��������, � ������� ������ ����� ��������� �� ��������
    public float smoothSpeed = 0.125f;

    // ����� ���������� ������ ���� ����� ���� ����������
    void LateUpdate()
    {
        // ��������� �������� ������� ������ � ������ ��������
        Vector3 desiredPosition = target.position + offset;

        // ������ ������������� ����� ������� �������� ������ � �������� ��������
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        Vector3 smoothedPosition = desiredPosition;

        // ��������� ������� ������ �� ����������� ���������� �������
        transform.position = smoothedPosition;

        // ������������ ������, ����� ��� ������ �������� �� ������
        //transform.LookAt(target);
        Vector3 dir = target.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, smoothSpeed * Time.deltaTime);
    }
}
