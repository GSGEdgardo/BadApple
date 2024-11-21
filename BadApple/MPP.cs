using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using BadApple;
public class MPP
{
    private readonly List<Nodo> nodos;
    public int Ancho { get; }
    public int Alto { get; }

    public MPP(int ancho, int alto)
    {
        Ancho = ancho;
        Alto = alto;
        nodos = new List<Nodo>();
    }

    public void AgregarNodo(int x, int y, bool esBlanco)
    {
        nodos.Add(new Nodo(x, y, esBlanco));
    }

    public Nodo ObtenerNodo(int x, int y)
    {
        return nodos.Find(n => n.X == x && n.Y == y);
    }
}