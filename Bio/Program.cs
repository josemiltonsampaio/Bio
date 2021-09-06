using System;
using System.Collections.Generic;
using System.Linq;

namespace Bio
{
    class Program
    {
        static void Main(string[] args)
        {
            string gene1 = "ATCTACGTGCTGGTAATGAAACTCCACGCACCCAAAGACACG";
            string gene2 = "CTCGATATTGCAATTCGTGCTCTCCAAACCTCAAA";
            string gene3 = "AGAGAAACGTGATACCCAAGATGTAACTCGAC";
            string gene4 = "ACCCGTTATGCAACTCTTTCACGTACACAGAGGGGAA";

            List<string> genes = new List<string> { gene1, gene2, gene3, gene4 };
            
            string padrao = "TACGTGCT";

            procuraDiferencas(genes, padrao, 5);
        }

        private static int contaDiferencas (string janela, string padrao)
        {
            int diferencas = 0;
            
            for(int i = 0; i < janela.Length; i++)
            {
                if (janela[i] != padrao[i])
                {
                    diferencas += 1;
                }
            }

            return diferencas;
        }

        private static void procuraDiferencas(List<String> genes, string padrao, int diferencaMaxima)
        {
            int tamanhoPadrao = padrao.Length;
            int geneId = 0;

            foreach (string gene in genes)
            {
                geneId += 1;
                int tamanhoGene = gene.Length;

                for(int pos=0;pos < tamanhoGene - tamanhoPadrao + 1;pos++)
                {
                    string janela = gene.Substring(pos, tamanhoPadrao);
                    int diferencas = contaDiferencas(janela, padrao);

                    if (diferencas <= diferencaMaxima)
                    {
                        Console.WriteLine($"Gene {geneId} -> {janela}");
                        Console.WriteLine($"Padrão -> {padrao}");
                        Console.WriteLine($"Diferenças -> {diferencas}");
                        Console.WriteLine($"Localização no gene -> {pos}-{pos+tamanhoPadrao}");
                    }
                }
            }

        }
    }
}
