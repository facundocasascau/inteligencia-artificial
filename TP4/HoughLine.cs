using OpenCvSharp;

namespace TP4;

public class HoughLine
{
    public static Mat ProcessImage(Mat img)
    {
        // Aplica un desenfoque gaussiano a la imagen para reducir el ruido
        Cv2.GaussianBlur(img, img, new OpenCvSharp.Size(9, 9), 2, 2);

        // Realiza la detección de bordes utilizando el detector de bordes de Canny
        Mat edges = new Mat();
        Cv2.Canny(img, edges, 50, 150);

        // Detecta líneas en la imagen utilizando la Transformada de Hough Probabilística
        LineSegmentPoint[] lines = Cv2.HoughLinesP(
            edges,
            1, // Resolución de rho en píxeles
            Cv2.PI / 180, // Resolución de theta en radianes
            10, // Umbral de acumulador, cuanto mayor sea este valor, menos líneas serán detectadas
            minLineLength: 1, // Longitud mínima de la línea. Las líneas más cortas que esta longitud serán rechazadas.
            maxLineGap: 0 // Máxima distancia entre segmentos de línea conectados para tratarlos como una sola línea.
        );

        // Convierte la imagen en escala de grises a una imagen en color (BGR)
        Mat cimg = new Mat();
        Cv2.CvtColor(img, cimg, ColorConversionCodes.GRAY2BGR);

        // Dibuja las líneas detectadas en la imagen en color
        foreach (var line in lines)
        {
            Cv2.Line(cimg, line.P1, line.P2, Scalar.Red, 2);
        }

        // Devuelve la imagen procesada
        return cimg;
    }
}