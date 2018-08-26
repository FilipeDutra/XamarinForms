using System;
using System.Collections.Generic;
using System.Text;
using System.Net; //classe de pesquisa na internet
using App01_ConsultaCep.Servico.Modelo;
using Newtonsoft.Json;  



namespace App01_ConsultaCep.Servico
{
    public class ViaCepServico
    {

        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";


        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string novoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            String Conteudo = wc.DownloadString(novoEnderecoURL);

            Endereco end =JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return end;

        }




    }
}
