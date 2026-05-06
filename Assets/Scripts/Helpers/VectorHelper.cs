using UnityEngine;

public class VectorHelper
{
    /// <summary>
    /// Путем скалярного перемножения и отбрасывания на плоскость находит находиться ли точка внутри прям-ка
    /// </summary>
    public static bool IsUnitRec(Vector3 unitCameraPosion, Vector3 userRectSelectOne, Vector3 userRectSelectTwo)
    {
        if (unitCameraPosion.z < 0)
            return false;

        // Задаем вектора в плоскости прям-ка
        Vector2 P = new Vector2(unitCameraPosion.x, unitCameraPosion.y);
        Vector2 A = userRectSelectOne;
        Vector2 C = userRectSelectTwo;

        // Находим вектора в сторону рамки
        Vector2 AB = new Vector2(C.x - A.x, 0);
        Vector2 AD = new Vector2(0, C.y - A.y);
        Vector2 AP = P - A;

        //Получаем проекции 
        float dotAP_AB = AP.x * AB.x + AP.y * AB.y;
        float dotAP_AD = AP.x * AD.x + AP.y * AD.y;

        float dotAB_AB = AB.x * AB.x + AB.y * AB.y;
        float dotAD_AD = AD.x * AD.x + AD.y * AD.y;

        // Финальная проверка
        return (dotAP_AB >= 0 && dotAP_AB <= dotAB_AB) &&
               (dotAP_AD >= 0 && dotAP_AD <= dotAD_AD);
    }

    /// <summary>
    /// Сравнивание двух векторов , но с учетом погрешности 
    /// К примеру (0,1) и (0,2) - будут считаться одним вектором, при установки threshold
    /// </summary>

    public static bool IsSameVector(Vector3 vectorOne, Vector3 vectorTwo, float threshold = 1f)
    {
        // Находим разницу между векторами
        float dx = vectorOne.x - vectorTwo.x;
        float dy = vectorOne.y - vectorTwo.y;

        // Считаем квадрат расстояния
        float sqrDistance = (dx * dx) + (dy * dy);

        // Сравниваем с квадратом порога
        return sqrDistance < (threshold * threshold);
    }
}
