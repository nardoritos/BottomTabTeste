using System;
using System.Collections.Generic;

namespace BottomTabTeste.ListViewMacoratti
{
    public static class FilmesRepositorio
    {
        public static List<Filme> Filmes { get; private set; }
        static FilmesRepositorio()
        {
            Filmes = new List<Filme>();
            for (int i = 0; i < 10; i++)
            {
                AddFilmes();
            }
        }
        private static void AddFilmes()
        {
            Filmes.Add(new Filme
            {
                Id = 1,
                Titulo = "A New Hope",
                Diretor = "George Lucas",
                DataLancamento = new DateTime(1977, 05, 25)
            });
            Filmes.Add(new Filme
            {
                Id = 2,
                Titulo = "The Empire Strikes Back",
                Diretor = "George Lucas",
                DataLancamento = new DateTime(1980, 05, 17)
            });
            Filmes.Add(new Filme
            {
                Id = 3,
                Titulo = "O Reterono de Jedi",
                Diretor = "George Lucas",
                DataLancamento = new DateTime(1983, 05, 25)
            });
            Filmes.Add(new Filme
            {
                Id = 4,
                Titulo = "A ameaça fantasma",
                Diretor = "George Lucas",
                DataLancamento = new DateTime(1999, 05, 19)
            });
            Filmes.Add(new Filme
            {
                Id = 5,
                Titulo = "A vingança dos Sith",
                Diretor = "George Lucas",
                DataLancamento = new DateTime(2005, 05, 19)
            });
            Filmes.Add(new Filme
            {
                Titulo = "Marte",
                Diretor = "J.J. Abrams",
                DataLancamento = new DateTime(2015, 12, 11)
            });
        }
    }
}