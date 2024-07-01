using OpenCvSharp;
using System;

namespace TP4;

public class HoughCircle
{
    public static Mat ProcessImage(Mat img)
    {
        // Aplica un desenfoque gaussiano a la imagen para reducir el ruido
        Cv2.GaussianBlur(img, img, new OpenCvSharp.Size(9, 9), 2, 2);

        // Detecta círculos en la imagen utilizando la Transformada de Hough para círculos
        CircleSegment[] circles = Cv2.HoughCircles(
            img,
            HoughModes.Gradient,
            1,
            20,
            param1: 50,  // Aumentar umbral superior para el detector de bordes de Canny
            param2: 40,   // Aumentar umbral de acumulación para el centro de los círculos
            minRadius: 0,  // Establecer un tamaño mínimo para los círculos detectados
            maxRadius: 90  // Establecer un tamaño máximo para los círculos detectados
        );

        // Convierte la imagen en escala de grises a una imagen en color (BGR)
        Mat cimg = new Mat();
        Cv2.CvtColor(img, cimg, ColorConversionCodes.GRAY2BGR);

        // Dibuja los círculos detectados en la imagen en color
        if (circles != null)
        {
            foreach (var circle in circles)
            {
                // Dibuja el contorno del círculo en rojo
                Cv2.Circle(cimg, (int)circle.Center.X, (int)circle.Center.Y, (int)circle.Radius, Scalar.Red, 2);
                // Dibuja el centro del círculo en rojo
                Cv2.Circle(cimg, (int)circle.Center.X, (int)circle.Center.Y, 2, Scalar.Red, 3);
            }
        }

        // Retorna la imagen procesada
        return cimg;
    }
}
