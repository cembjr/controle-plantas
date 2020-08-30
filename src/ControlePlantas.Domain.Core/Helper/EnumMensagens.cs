using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ControlePlantas.Domain.Core.Helper
{

    public static class MensagemPadrao
    {
        public static string NaoDeveSerVazio(string campo) => string.Format("{0} não deve ser vazio", campo);

        public static string DeveSerMaiorQueZero(string campo) => string.Format("{0} deve ser maior que zero", campo);

        public static string DeveSerDefinido(string campo) => string.Format("{0} deve ser definido", campo);

        public static string DeveSerInformado(string campo) => string.Format("{0} deve ser informado", campo);

        public static string DeveSerMaiorQue(string campo, string referencia) => string.Format("{0} deve ser maior que {1}", campo, referencia);

        public static string DeveConterMaisQueXCaracteres(string campo, int qtdCaracteres) => string.Format("{0} deve conter mais que {1} caracteres", campo, qtdCaracteres);

        public static string DeveConterXCaracteres(string campo, int qtdCaracteres) => string.Format("{0} deve conter {1} caracteres", campo, qtdCaracteres);
    }
}
