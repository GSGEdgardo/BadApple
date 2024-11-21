using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using BadApple;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

public class MenuImplementation : IMenu
{
    public bool HandleOption(string option)
    {
        switch (option)
        {
            case "1":
                Console.WriteLine("Mostrando video...");
                MostrarVideo(@"C:\Users\edgar\source\repos\BadApple\BadApple\frames", 220, 165, fps: 24);
                break;

            case "2":
                Console.WriteLine("Saliendo del programa...");
                return false;

            default:
                Console.WriteLine("Opción no válida, inténtalo de nuevo.");
                break;
        }
        return true;
    }

    private void MostrarVideo(string carpetaFrames, int ancho, int alto, int fps = 24)
    {
        if (!Directory.Exists(carpetaFrames))
        {
            Console.WriteLine($"La carpeta '{carpetaFrames}' no existe. Verifica la ruta.");
            return;
        }

        // Obtener la lista de archivos JPG ordenados
        string[] archivos = Directory.GetFiles(carpetaFrames, "*.jpg");
        Array.Sort(archivos);

        Console.WriteLine($"Se han encontrado {archivos.Length} frames.");
        Console.WriteLine("Presiona cualquier tecla para iniciar la reproducción...");
        Console.ReadKey();

        // Preprocesar los frames a ASCII
        var frames = PreprocesarFrames(archivos, ancho, alto);

        // Configurar dimensiones de la consola
        Console.SetWindowSize(ancho, alto / 2);
        Console.SetBufferSize(ancho, alto / 2);
        Console.Clear();

        // Configurar temporizador
        double frameTime = 1000.0 / fps;
        var stopwatch = Stopwatch.StartNew();

        Console.CursorVisible = false;

        // Reproducción de frames
        for (int i = 0; i < frames.Count; i++)
        {
            double elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            double expectedTime = i * frameTime;

            // Sincronización de FPS
            if (elapsedMilliseconds < expectedTime)
            {
                Thread.Sleep((int)(expectedTime - elapsedMilliseconds));
            }

            // Dibujar el frame actual
            DibujarFrame(frames[i]);
        }

        Console.CursorVisible = true;
        Console.Clear();
        Console.WriteLine("Reproducción finalizada.");
    }

    private List<string> PreprocesarFrames(string[] archivos, int ancho, int alto)
    {
        var frames = new List<string>();

        foreach (var archivo in archivos)
        {
            frames.Add(ConvertirAASCII(archivo, ancho, alto));
        }

        return frames;
    }

    private string ConvertirAASCII(string rutaArchivo, int ancho, int alto)
    {
        using (Image<Rgba32> image = Image.Load<Rgba32>(rutaArchivo))
        {
            var sb = new StringBuilder();
            char[] chars = { ' ', '.', ':', '-', '=', '+', '*', '#', '%', '@' };

            for (int y = 0; y < alto; y++)
            {
                for (int x = 0; x < ancho; x++)
                {
                    int px = x * image.Width / ancho;
                    int py = y * image.Height / alto;

                    Rgba32 pixel = image[px, py];
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;

                    int index = gray * (chars.Length - 1) / 255;
                    sb.Append(chars[index]);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

    private void DibujarFrame(string frame)
    {
        Console.SetCursorPosition(0, 0);
        Console.Write(frame);
    }
}
