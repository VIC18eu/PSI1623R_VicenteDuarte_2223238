using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using ProjetoFinal.Properties;

namespace ProjetoFinal
{
    public class ConfiguracoesApp
    {
        public bool ModoEscuro { get; set; } = false;
        public string Idioma { get; set; } = "Português";
        public string TamanhoFonte { get; set; } = "Média";
        public bool NotificacoesAtivas { get; set; } = true;
        public bool AtualizacoesAutomaticas { get; set; } = true;
        public bool ManterSessaoIniciada { get; set; } = false;
        public string UtilizadorAtual { get; set; } = string.Empty;
    }

    public static class ConfigManager
    {
        private static readonly string CaminhoFicheiro = "config.json";

        public static ConfiguracoesApp Configuracoes { get; private set; }

        // Carrega definições ou cria padrão
        public static void Carregar()
        {
            if (File.Exists(CaminhoFicheiro))
            {
                string json = File.ReadAllText(CaminhoFicheiro);
                Configuracoes = JsonConvert.DeserializeObject<ConfiguracoesApp>(json);
            }
            else
            {
                Configuracoes = new ConfiguracoesApp();
                Guardar(); // cria o ficheiro com defaults
            }
        }

        public static void Guardar()
        {
            string json = JsonConvert.SerializeObject(Configuracoes, Formatting.Indented);
            File.WriteAllText(CaminhoFicheiro, json);
        }

        public static ConfiguracoesApp Load()
        {
            if (!File.Exists(CaminhoFicheiro))
            {
                return new ConfiguracoesApp();
            }

            string json = File.ReadAllText(CaminhoFicheiro);
            return JsonConvert.DeserializeObject<ConfiguracoesApp>(json);
        }
    }


}
