using UnityEngine;

public class VectorHelper
{
    /// <summary>
    /// Упрощенным способом ищем юнит ли в рамке
    /// </summary>

    public static bool IsUnitRec(Vector3 unitCameraPosion, Vector3 userRectSelectOne, Vector3 userRectSelectTwo)
    {
        if (unitCameraPosion.z < 0) return false;

        float xMin = Mathf.Min(userRectSelectOne.x, userRectSelectTwo.x);
        float xMax = Mathf.Max(userRectSelectOne.x, userRectSelectTwo.x);
        float yMin = Mathf.Min(userRectSelectOne.y, userRectSelectTwo.y);
        float yMax = Mathf.Max(userRectSelectOne.y, userRectSelectTwo.y);

        Rect selectionRect = new Rect(xMin, yMin, xMax - xMin, yMax - yMin);

        return selectionRect.Contains(unitCameraPosion);
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
