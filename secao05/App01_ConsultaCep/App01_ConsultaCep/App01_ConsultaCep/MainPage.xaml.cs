using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultaCep.Servico.Modelo;
using App01_ConsultaCep.Servico;

namespace App01_ConsultaCep
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;


		}
        private void BuscarCEP(object sender, EventArgs args)
        {
            //todo lógica do programa


            //todo Validações

            string cep = CEP.Text.Trim();

            if (IsValidaCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);

                    if(end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2} de {3} {0},{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O CEP informado não foi localizado :" + cep, "OK");
                    }

                   
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
                
            }
        }

        private bool IsValidaCEP(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {

                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                //erro
                valido = false;
            }
            int NovoCEP;
            if(!int.TryParse(cep, out NovoCEP))
            {
                //erro
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas por números", "OK");
                valido = false;
            }
            return valido;
        }
        
	}
}
