using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Herramienta de editor para simetrizar filas de ladrillos.
/// Creada por qwen 3.8 max
/// </summary>
public static class BrickSymmetry
{
    // ====== DISEÑO DE TU CUADRÍCULA (en UNIDADES de mundo, no píxeles) ======
    // Patrón de grupos. El script lo hace palíndromo automáticamente.
    // Prueba estos y elige el que te guste:
    //   {1,2,1,2,1}  suelto-pareja-suelto-pareja-suelto
    //   {2,1,1,1,2}  pareja-suelto-suelto-suelto-pareja
    //   {2,2,2,2}    4 parejas  (-> requiere 8 ladrillos por fila)
    static readonly int[] GROUPS = { 1, 1, 1, 1, 1, 1, 1 };

    static readonly float BLOCK_W   = 0.78f; // ancho del bloque = pxSprite / PPU
    static readonly float INNER_GAP = 0.04f; // separación DENTRO de un grupo (pegados)
    static readonly float OUTER_GAP = 0.22f; // separación ENTRE grupos
    static readonly float CENTER_X  = 0f;    // eje de simetría (pon aquí la X de tu cámara)
    static readonly bool  FORCE_PARENT_X_TO_CENTER = true; // cuadra columnas entre filas
    // =======================================================================

    [MenuItem("Tools/Simetrizar Filas de Ladrillos")]
    static void Symmetrize()
    {
        var rows = Object.FindObjectsOfType<GameObject>()
                         .Where(g => g.name.StartsWith("Fila"))
                         .ToArray();

        if (rows.Length == 0)
        {
            EditorUtility.DisplayDialog("Filas",
                "No encontré GameObjects que empiecen por 'Fila'.", "OK");
            return;
        }

        int[] groups = MakePalindrome(GROUPS);
        int expected = groups.Sum();

        // Anchura de cada grupo y anchura total
        float[] groupW = groups.Select(n => n * BLOCK_W + (n - 1) * INNER_GAP).ToArray();
        float totalW = groupW.Sum() + (groups.Length - 1) * OUTER_GAP;

        // Posiciones X locales simétricas (centradas en CENTER_X)
        List<float> xs = new List<float>(expected);
        float cursor = CENTER_X - totalW * 0.5f;
        for (int g = 0; g < groups.Length; g++)
        {
            int n = groups[g];
            float gStart = cursor;
            for (int k = 0; k < n; k++)
            {
                // centro del bloque k dentro del grupo
                float x = gStart + k * (BLOCK_W + INNER_GAP) + BLOCK_W * 0.5f;
                xs.Add(x);
            }
            cursor += groupW[g] + OUTER_GAP;
        }

        // Aplicar a cada fila
        foreach (var row in rows)
        {
            var bricks = new List<Transform>();
            foreach (Transform t in row.transform) bricks.Add(t);
            bricks = bricks.OrderBy(t => t.localPosition.x).ToList(); // izq -> der

            if (bricks.Count != xs.Count)
            {
                Debug.LogWarning($"[BrickSymmetry] {row.name} tiene {bricks.Count} hijos " +
                                 $"pero el patrón suma {xs.Count}. Se omite esta fila.");
                continue;
            }

            for (int i = 0; i < bricks.Count; i++)
            {
                Undo.RecordObject(bricks[i], "Simetrizar ladrillos");
                bricks[i].localPosition = new Vector3(xs[i], 0f, bricks[i].localPosition.z);
                bricks[i].localRotation = Quaternion.identity;
            }

            if (FORCE_PARENT_X_TO_CENTER)
            {
                Undo.RecordObject(row.transform, "Centrar fila");
                var p = row.transform.localPosition;
                p.x = CENTER_X;
                row.transform.localPosition = p;
            }
        }

        Debug.Log($"✔ Filas simetrizadas: {rows.Length} | patrón final: [{string.Join(",", groups)}]");
    }

    // Fuerza el patrón a ser palíndromo reflejando la mitad izquierda.
    static int[] MakePalindrome(int[] g)
    {
        int n = g.Length;
        int[] r = (int[])g.Clone();
        for (int i = 0; i < n / 2; i++) r[n - 1 - i] = r[i];
        if (!r.SequenceEqual(g))
            Debug.Log($"[BrickSymmetry] Patrón no era palíndromo; se forzó a [{string.Join(",", r)}].");
        return r;
    }
}