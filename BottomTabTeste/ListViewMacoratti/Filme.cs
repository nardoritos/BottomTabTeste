using System;

namespace BottomTabTeste.ListViewMacoratti
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public DateTime DataLancamento { get; set; }
        public override string ToString()
        {
            return Titulo + " por " + Diretor;
        }
    }
}