﻿using System;
using System.Text.RegularExpressions;

namespace IGotUScraper.Utilities
{
    public static class ExtrairDadosPath
    {
        public static string ObterNomeProduto(string caminho, int segmento)
        {
            var uri = new UriBuilder(caminho).Uri;
            var capturarSegmento = uri.Segments[segmento];

            return capturarSegmento.Replace("-", " ").Replace("/", "").ToLower();
        }

        public static string ObterCaminhoBase(string caminho)
        {
            var uri = new UriBuilder(caminho).Uri;

            return uri.Authority;
        }
    }
}
