using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    // Переменная для ссылки на объект, за которым будет следить камера
    public Transform target;

    // Вектор для смещения камеры относительно объекта
    public Vector3 offset;

    // Скорость, с которой камера будет следовать за объектом
    public float smoothSpeed = 0.125f;

    // Метод вызывается каждый кадр после всех обновлений
    void LateUpdate()
    {
        // Вычисляем желаемую позицию камеры с учетом смещения
        Vector3 desiredPosition = target.position + offset;

        // Плавно интерполируем между текущей позицией камеры и желаемой позицией
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        Vector3 smoothedPosition = desiredPosition;

        // Обновляем позицию камеры до вычисленной сглаженной позиции
        transform.position = smoothedPosition;

        // Поворачиваем камеру, чтобы она всегда смотрела на объект
        //transform.LookAt(target);
        Vector3 dir = target.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, smoothSpeed * Time.deltaTime);
    }
}
