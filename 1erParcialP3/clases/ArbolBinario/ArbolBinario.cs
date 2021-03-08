using System;
using System.Collections.Generic;
using System.Text;

namespace _1erParcialP3.clases.ArbolBinario
{
    class ArbolBinario
    {
        protected Nodo raiz;

        public ArbolBinario()
        {
            raiz = null;
        }

        public ArbolBinario(Nodo ValorRaiz)
        {
            this.raiz = ValorRaiz;
        }
        public Nodo raizArbol()
        {
            return raiz;
        }

        bool esVacio()
        {
            return raiz == null;
        }

        public static Nodo nuevoArbol(Nodo ramaIzqda, object dato, Nodo ramaDrcha)
        {
            return new Nodo(ramaIzqda, dato, ramaDrcha);
        }
    }
}
